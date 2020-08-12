#define INTERNAL_MAINTENANCE

#if INTERNAL_MAINTENANCE

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This goes through the ImGui.gen.cs file and transform all the Begin/End (or approx) to C# scopes.
/// This is .... very rough and not very portable, because done in 3H a Tuesday evening.
/// Still, it works.
/// </summary>
public class ScopeGeneratorEditor : EditorWindow
{
    #region Static and Constants
    private const string TAG_SCOPE_CLASS = "#SCOPE_CLASS#";
    private const string TAG_SCOPE_STATIC = "#SCOPE_STATIC#";
    private const string TAG_BEGIN = "#BEGIN#";
    private const string TAG_END = "#END#";
    private const string TAG_CLASSNAME = "#CLASSNAME#";
    private const string TAG_SCOPE_CALL = "#SCOPE_CALL#";
    private const string TAG_RETURN_PROP = "#RETURN_VALUE_PROP#";
    private const string TAG_RETURN_SET = "#RETURN_VALUE_SET#";
    private const string TAG_PARAM_DECL = "#PARAM_DECL#";
    private const string TAG_PARAM_PASS = "#PARAM_PASS#";
    private const string TAG_CTOR = "#CTOR#";

    private const char PARAMETER_SEPARATOR = ',';
    #endregion

    #region Fields
    private string[] sourcePaths =
    {
        "../dear-imgui-touky/ImGuiNET/Wrapper/Generated/ImGui.gen.cs"
    };

    private string classPath = "../dear-imgui-touky/ImGuiNET.Unity/Scopes/ImGuiUn.Scopes.gen.cs";

    private string returnProperty = @"        public bool ReturnValue { get; }
";

    private string returnSet = "ReturnValue = ";

    private string fileCode =
        $@"namespace ImGuiNET
{{
    using System;
    using UnityEngine;

{TAG_SCOPE_CLASS}

    public static partial class ImGuiUn
    {{
{TAG_SCOPE_STATIC}
    }}
}}
";

    private string ctorCode = $@"        public {TAG_CLASSNAME}({TAG_PARAM_DECL}) {{ {TAG_RETURN_SET}ImGui.{TAG_BEGIN}({TAG_PARAM_PASS}); }}
";

    private string classCode =
        $@"    public class {TAG_CLASSNAME} : ImGuiScope
    {{
{TAG_RETURN_PROP}{TAG_CTOR}        protected override void CloseScope() {{ ImGui.{TAG_END}(); }}
    }}

";

    private string methodCode =
        $@"        public static {TAG_CLASSNAME} {TAG_SCOPE_CALL}({TAG_PARAM_DECL})
        {{ return new {TAG_CLASSNAME}({TAG_PARAM_PASS}); }}
";

    private List<DetectionBlock> detectionBlock = new List<DetectionBlock>
    {
        new DetectionBlock
        {
            concatenateEnd = false,
            namePrefix = "Tree",
            begin = new Regex("([a-z]+)(?: )+(Tree)([a-zA-Z]+)*\\("),
            end = "([a-z]+)(?: )+(TreePop)\\("
        },
        new DetectionBlock
        {
            concatenateEnd = false,
            namePrefix = "Popup",
            begin = new Regex("([a-z]+)(?: )+(BeginPopup)([a-zA-Z]+)*\\("),
            end = "([a-z]+)(?: )+(EndPopup)\\("
        },
        new DetectionBlock
        {
            concatenateEnd = false,
            defaultName = "Indent",
            begin = new Regex("([a-z]+)(?: )+(Indent)([a-zA-Z]+)*\\("),
            end = "([a-z]+)(?: )+(Unindent)\\("
        },
        new DetectionBlock
        {
            concatenateEnd = true,
            defaultName = "Window",
            begin = new Regex("([a-z]+)(?: )+(Begin)([a-zA-Z]+)*\\("),
            end = "([a-z]+)(?: )+(End)#REPLACE#\\("
        },
    };

    private Regex parameterRegex = new Regex("([a-zA-Z][a-zA-Z0-9]+)");
    private bool exportCode = false;
    private bool exportCommented = false;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        // Reference to the root of the window.
        VisualElement root = rootVisualElement;

        // Creates our button and sets its Text property.
        Button myButton = new Button {text = "Generate scope code"};
        myButton.clickable.clicked += Export;

        // Adds it to the root.
        root.Add(myButton);
    }
    #endregion

    #region Class Methods
    [MenuItem("DearImGui/Scope maintenance")]
    public static void ShowWindow()
    {
        ScopeGeneratorEditor window = GetWindow<ScopeGeneratorEditor>();
        window.Focus();
        window.titleContent = new GUIContent("Scope maintenance");
    }

    private void Export()
    {
        List<ScopeInfos> scopesInfos = new List<ScopeInfos>();
        foreach (string sourcePath in sourcePaths)
        {
            string path = Path.Combine(Application.dataPath, sourcePath);
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Debug.LogError($"File {sourcePath} does not exist");
                continue;
            }

            HashSet<string> detectedMethods = new HashSet<string>();
            string content = File.ReadAllText(fileInfo.FullName);
            foreach (DetectionBlock block in detectionBlock)
            {
                Match beginMatch = block.begin.Match(content);
                while (beginMatch.Success)
                {
                    string returnValue = beginMatch.Groups[1].Value;
                    string originalPrefix = beginMatch.Groups[2].Value;
                    string methodName = beginMatch.Groups[3].Value;

                    string endString = block.concatenateEnd ? block.end.Replace("#REPLACE#", methodName) : block.end;
                    Regex endRegex = new Regex(endString);
                    Match endMatch = endRegex.Match(content);
                    if (!endMatch.Success)
                    {
                        Debug.LogError($"FAILED: ({beginMatch.ToString()}) -> ({endRegex.ToString()})");
                        beginMatch = beginMatch.NextMatch();
                        continue;
                    }

                    int parametersBegin = beginMatch.Index + beginMatch.Length;
                    int parametersEnd = content.IndexOf(')', beginMatch.Index + beginMatch.Length);
                    if (parametersEnd < 0)
                    {
                        Debug.LogError("HUH !?! WHAT !?!?");
                        beginMatch = beginMatch.NextMatch();
                        continue;
                    }

                    string parameters = string.Empty;
                    if (parametersEnd - parametersBegin > 0)
                    {
                        parameters = content.Substring(parametersBegin, parametersEnd - parametersBegin);
                    }

                    if (detectedMethods.Contains(beginMatch.Value + parameters))
                    {
                        beginMatch = beginMatch.NextMatch();
                        continue;
                    }

                    detectedMethods.Add(beginMatch.Value + parameters);

                    ScopeInfos scopeInfos = new ScopeInfos {parameters = new List<List<Parameter>>()};

                    scopeInfos.returnValue = returnValue == "void" ? string.Empty : returnValue;
                    scopeInfos.originalBegin = originalPrefix + methodName;
                    scopeInfos.originalEnd = endMatch.Groups[2] + (block.concatenateEnd ? methodName : string.Empty);
                    if (string.IsNullOrEmpty(methodName))
                    {
                        scopeInfos.className = "Scope" + block.namePrefix + block.defaultName;
                    }
                    else
                    {
                        scopeInfos.className = "Scope" + block.namePrefix + methodName;
                    }

                    List<Parameter> foundParams = new List<Parameter>();
                    string[] parameterList = parameters.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string p in parameterList)
                    {
                        Parameter parameterInfos = new Parameter();
                        string[] ps = p.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        if (ps[i] == "ref")
                        {
                            parameterInfos.isRef = true;
                            i++;
                        }

                        parameterInfos.type = ps[i++];
                        parameterInfos.name = ps[i++];

                        foundParams.Add(parameterInfos);
                    }

                    int index = scopesInfos.FindIndex(x =>
                    {
                        return x.className == scopeInfos.className;
                    });

                    if (index < 0)
                    {
                        scopeInfos.parameters.Add(foundParams);
                        scopesInfos.Add(scopeInfos);
                    }
                    else
                    {
                        ScopeInfos other = scopesInfos[index];
                        other.parameters.Add(foundParams);
                        scopesInfos[index] = other;
                    }

                    beginMatch = beginMatch.NextMatch();
                }
            }
        }

        string scopeCode = string.Empty;
        string scopeCall = string.Empty;
        foreach (ScopeInfos infos in scopesInfos)
        {
            infos.parameters.Sort((a, b) => { return a.Count - b.Count; });

            string methods = string.Empty;
            string ctor = string.Empty;
            foreach (List<Parameter> parameters in infos.parameters)
            {
                methods += methodCode;
                ctor += ctorCode;
                string paramDecl = string.Empty;
                string paramPass = string.Empty;
                foreach (Parameter parameter in parameters)
                {
                    if (!string.IsNullOrEmpty(paramDecl))
                    {
                        paramDecl += ", ";
                        paramPass += ", ";
                    }

                    if (parameter.isRef)
                    {
                        paramDecl += "ref ";
                        paramPass += "ref ";
                    }

                    paramDecl += $"{parameter.type} {parameter.name}";
                    paramPass += parameter.name;
                }

                ctor = ctor.Replace(TAG_PARAM_DECL, paramDecl);
                ctor = ctor.Replace(TAG_PARAM_PASS, paramPass);
                methods = methods.Replace(TAG_PARAM_DECL, paramDecl);
                methods = methods.Replace(TAG_PARAM_PASS, paramPass);
            }

            string code = classCode;
            code = code.Replace(TAG_CTOR, ctor);
            code = code.Replace(TAG_CLASSNAME, infos.className);
            code = code.Replace(TAG_BEGIN, infos.originalBegin);
            code = code.Replace(TAG_END, infos.originalEnd);
            code = code.Replace(TAG_RETURN_SET, string.IsNullOrEmpty(infos.returnValue) ? string.Empty : returnSet);
            code = code.Replace(TAG_RETURN_PROP, string.IsNullOrEmpty(infos.returnValue) ? string.Empty : returnProperty);

            methods = methods.Replace(TAG_CLASSNAME, infos.className);
            methods = methods.Replace(TAG_SCOPE_CALL, infos.className);

            scopeCode += code;
            scopeCall += methods;
        }

        string finalCode = fileCode.Replace(TAG_SCOPE_CLASS, scopeCode).Replace(TAG_SCOPE_STATIC, scopeCall);

        FileInfo destination = new FileInfo(Path.Combine(Application.dataPath, classPath));
        if (!destination.Exists)
        {
            return;
        }

        File.WriteAllText(destination.FullName, finalCode);
    }
    #endregion

    #region Nested type: DetectionBlock
    private struct DetectionBlock
    {
        public bool concatenateEnd;
        public string defaultName;
        public string namePrefix;
        public Regex begin;
        public string end;
    }
    #endregion

    #region Nested type: Parameter
    private struct Parameter
    {
        public bool isRef;
        public string type;
        public string name;
    }
    #endregion

    #region Nested type: ScopeInfos
    private struct ScopeInfos
    {
        public string returnValue;
        public string originalBegin;
        public string originalEnd;
        public string className;
        public List<List<Parameter>> parameters;
    }
    #endregion
}
#endif
