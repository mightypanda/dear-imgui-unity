#define INTERNAL_MAINTENANCE

#if INTERNAL_MAINTENANCE

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ScopeGeneratorEditor : EditorWindow
{
    private string[] sourcePaths =
    {
        "../dear-imgui-touky/ImGuiNET/Wrapper/Generated/ImGui.gen.cs"
    };

    private struct DetectionBlock
    {
        public bool concatenateEnd;
        public string defaultName;
        public string namePrefix;
        public Regex begin;
        public Regex end;
    }

    private List<DetectionBlock> detectionBlock = new List<DetectionBlock>()
    {
        new DetectionBlock()
        {
            concatenateEnd = true,
            defaultName = "Window",
            begin = new Regex("([a-z]+)(?: )+Begin([a-zA-Z]+)+\\("),
            end = new Regex("([a-z]+)(?: )+End([a-zA-Z]+)+\\(")
        },
        new DetectionBlock()
        {
            concatenateEnd = false,
            namePrefix = "Tree",
            begin = new Regex("([a-z]+)(?: )+Tree([a-zA-Z]+)+\\("),
            end = new Regex("([a-z]+)(?: )+TreePop([a-zA-Z]+)+\\(")
        },
        new DetectionBlock()
        {
            concatenateEnd = false,
            defaultName = "Indent",
            begin = new Regex("([a-z]+)(?: )+Indent([a-zA-Z]+)+\\("),
            end = new Regex("([a-z]+)(?: )+Unindent([a-zA-Z]+)+\\(")
        },
    };

    [MenuItem("DearImGui/Scope maintenance")]
    public static void ShowWindow()
    {
        var window = GetWindow<ScopeGeneratorEditor>();
        window.Focus();
        window.titleContent = new GUIContent("Scope maintenance");
    }

    private bool exportCode = false;
    private bool exportCommented = false;

    private void OnEnable()
    {
        // Reference to the root of the window.
        var root = rootVisualElement;

        // Creates our button and sets its Text property.
        var myButton = new Button() { text = "Generate scope code" };
        myButton.clickable.clicked += Export;

        // Adds it to the root.
        root.Add(myButton);
    }

    private void Export()
    {
        foreach (var sourcePath in sourcePaths)
        {
            var path = Path.Combine(Application.dataPath, sourcePath);
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Debug.LogError($"File {sourcePath} does not exist");
                continue;
            }

            var content = File.ReadAllText(fileInfo.FullName);
            foreach (DetectionBlock block in detectionBlock)
            {
                var beginMatch = block.begin.Match(content);
                while (beginMatch.Success)
                {

                    var returnValue = beginMatch.Groups[1].Value;
                    var methodName = beginMatch.Groups[2].Value;

                    var parametersBegin = beginMatch.Index + beginMatch.Length;
                    var parametersEnd = content.IndexOf(')', beginMatch.Index + beginMatch.Length);
                    if (parametersEnd < 0)
                    {
                        Debug.LogError("HUH !?! WHAT !?!?");
                        return;
                    }

                    var parameters = string.Empty;
                    if ((parametersBegin - parametersEnd) > 0)
                    {
                        parameters = content.Substring(parametersBegin, parametersEnd - parametersBegin);
                    }

                    Debug.Log($"{returnValue} {methodName} ({parameters})");
                }
            }
        }
    }
}
#endif