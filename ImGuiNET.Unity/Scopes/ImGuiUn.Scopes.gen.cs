namespace ImGuiNET
{
    public class WindowScope : ImGuiScope
    {
        #region Constructors
        public WindowScope(string name, ref bool p_open, ImGuiWindowFlags flags)
        {
            returnValue = ImGui.Begin(name, ref p_open, flags);
        }
        #endregion

        #region Class Methods
        protected override void CloseScope()
        {
            ImGui.End();
        }
        #endregion
    }

    public static partial class ImGuiUn
    {
        #region Class Methods
        public static WindowScope ScopeBegin(string name, ref bool p_open, ImGuiWindowFlags flags)
        {
            return new WindowScope(name, ref p_open, flags);
        }
        #endregion
    }
}
