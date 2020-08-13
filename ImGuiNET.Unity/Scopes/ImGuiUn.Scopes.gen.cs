namespace ImGuiNET
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginChild / ImGui.EndChild
    /// </summary>
    public class ScopeChild : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeChild(string str_id) { IsOpen = ImGui.BeginChild(str_id); }
        public ScopeChild(string str_id, Vector2 size) { IsOpen = ImGui.BeginChild(str_id, size); }
        public ScopeChild(string str_id, Vector2 size, bool border) { IsOpen = ImGui.BeginChild(str_id, size, border); }
        public ScopeChild(string str_id, Vector2 size, bool border, ImGuiWindowFlags flags) { IsOpen = ImGui.BeginChild(str_id, size, border, flags); }
        public ScopeChild(uint id) { IsOpen = ImGui.BeginChild(id); }
        public ScopeChild(uint id, Vector2 size) { IsOpen = ImGui.BeginChild(id, size); }
        public ScopeChild(uint id, Vector2 size, bool border) { IsOpen = ImGui.BeginChild(id, size, border); }
        public ScopeChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags) { IsOpen = ImGui.BeginChild(id, size, border, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndChild(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginChildFrame / ImGui.EndChildFrame
    /// </summary>
    public class ScopeChildFrame : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeChildFrame(uint id, Vector2 size) { IsOpen = ImGui.BeginChildFrame(id, size); }
        public ScopeChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags) { IsOpen = ImGui.BeginChildFrame(id, size, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndChildFrame(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginCombo / ImGui.EndCombo
    /// </summary>
    public class ScopeCombo : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeCombo(string label, string preview_value) { IsOpen = ImGui.BeginCombo(label, preview_value); }
        public ScopeCombo(string label, string preview_value, ImGuiComboFlags flags) { IsOpen = ImGui.BeginCombo(label, preview_value, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndCombo(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginDragDropSource / ImGui.EndDragDropSource
    /// </summary>
    public class ScopeDragDropSource : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeDragDropSource() { IsOpen = ImGui.BeginDragDropSource(); }
        public ScopeDragDropSource(ImGuiDragDropFlags flags) { IsOpen = ImGui.BeginDragDropSource(flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndDragDropSource(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginDragDropTarget / ImGui.EndDragDropTarget
    /// </summary>
    public class ScopeDragDropTarget : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeDragDropTarget() { IsOpen = ImGui.BeginDragDropTarget(); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndDragDropTarget(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginGroup / ImGui.EndGroup
    /// </summary>
    public class ScopeGroup : GUI.Scope
    {
        public ScopeGroup() { ImGui.BeginGroup(); }
        protected override void CloseScope() { ImGui.EndGroup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.Indent / ImGui.Unindent
    /// </summary>
    public class ScopeIndent : GUI.Scope
    {
        public ScopeIndent() { ImGui.Indent(); }
        public ScopeIndent(float indent_w) { ImGui.Indent(indent_w); }
        protected override void CloseScope() { ImGui.Unindent(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginMainMenuBar / ImGui.EndMainMenuBar
    /// </summary>
    public class ScopeMainMenuBar : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeMainMenuBar() { IsOpen = ImGui.BeginMainMenuBar(); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndMainMenuBar(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginMenu / ImGui.EndMenu
    /// </summary>
    public class ScopeMenu : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeMenu(string label) { IsOpen = ImGui.BeginMenu(label); }
        public ScopeMenu(string label, bool enabled) { IsOpen = ImGui.BeginMenu(label, enabled); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndMenu(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginMenuBar / ImGui.EndMenuBar
    /// </summary>
    public class ScopeMenuBar : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeMenuBar() { IsOpen = ImGui.BeginMenuBar(); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndMenuBar(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginPopup / ImGui.EndPopup
    /// </summary>
    public class ScopePopup : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopePopup(string str_id) { IsOpen = ImGui.BeginPopup(str_id); }
        public ScopePopup(string str_id, ImGuiWindowFlags flags) { IsOpen = ImGui.BeginPopup(str_id, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndPopup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginPopupContextItem / ImGui.EndPopup
    /// </summary>
    public class ScopePopupContextItem : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopePopupContextItem() { IsOpen = ImGui.BeginPopupContextItem(); }
        public ScopePopupContextItem(string str_id) { IsOpen = ImGui.BeginPopupContextItem(str_id); }
        public ScopePopupContextItem(string str_id, ImGuiMouseButton mouse_button) { IsOpen = ImGui.BeginPopupContextItem(str_id, mouse_button); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndPopup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginPopupContextVoid / ImGui.EndPopup
    /// </summary>
    public class ScopePopupContextVoid : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopePopupContextVoid() { IsOpen = ImGui.BeginPopupContextVoid(); }
        public ScopePopupContextVoid(string str_id) { IsOpen = ImGui.BeginPopupContextVoid(str_id); }
        public ScopePopupContextVoid(string str_id, ImGuiMouseButton mouse_button) { IsOpen = ImGui.BeginPopupContextVoid(str_id, mouse_button); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndPopup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginPopupContextWindow / ImGui.EndPopup
    /// </summary>
    public class ScopePopupContextWindow : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopePopupContextWindow() { IsOpen = ImGui.BeginPopupContextWindow(); }
        public ScopePopupContextWindow(string str_id) { IsOpen = ImGui.BeginPopupContextWindow(str_id); }
        public ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button) { IsOpen = ImGui.BeginPopupContextWindow(str_id, mouse_button); }
        public ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button, bool also_over_items) { IsOpen = ImGui.BeginPopupContextWindow(str_id, mouse_button, also_over_items); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndPopup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginPopupModal / ImGui.EndPopup
    /// </summary>
    public class ScopePopupModal : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopePopupModal(string name) { IsOpen = ImGui.BeginPopupModal(name); }
        public ScopePopupModal(string name, ref bool p_open) { IsOpen = ImGui.BeginPopupModal(name, ref p_open); }
        public ScopePopupModal(string name, ref bool p_open, ImGuiWindowFlags flags) { IsOpen = ImGui.BeginPopupModal(name, ref p_open, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndPopup(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginTabBar / ImGui.EndTabBar
    /// </summary>
    public class ScopeTabBar : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeTabBar(string str_id) { IsOpen = ImGui.BeginTabBar(str_id); }
        public ScopeTabBar(string str_id, ImGuiTabBarFlags flags) { IsOpen = ImGui.BeginTabBar(str_id, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndTabBar(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginTabItem / ImGui.EndTabItem
    /// </summary>
    public class ScopeTabItem : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeTabItem(string label) { IsOpen = ImGui.BeginTabItem(label); }
        public ScopeTabItem(string label, ref bool p_open) { IsOpen = ImGui.BeginTabItem(label, ref p_open); }
        public ScopeTabItem(string label, ref bool p_open, ImGuiTabItemFlags flags) { IsOpen = ImGui.BeginTabItem(label, ref p_open, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.EndTabItem(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.BeginTooltip / ImGui.EndTooltip
    /// </summary>
    public class ScopeTooltip : GUI.Scope
    {
        public ScopeTooltip() { ImGui.BeginTooltip(); }
        protected override void CloseScope() { ImGui.EndTooltip(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.TreeNode / ImGui.TreePop
    /// </summary>
    public class ScopeTreeNode : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeTreeNode(IntPtr ptr_id, string fmt) { IsOpen = ImGui.TreeNode(ptr_id, fmt); }
        public ScopeTreeNode(string label) { IsOpen = ImGui.TreeNode(label); }
        public ScopeTreeNode(string str_id, string fmt) { IsOpen = ImGui.TreeNode(str_id, fmt); }
        protected override void CloseScope() { if (IsOpen) ImGui.TreePop(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.TreeNodeEx / ImGui.TreePop
    /// </summary>
    public class ScopeTreeNodeEx : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeTreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt) { IsOpen = ImGui.TreeNodeEx(ptr_id, flags, fmt); }
        public ScopeTreeNodeEx(string label) { IsOpen = ImGui.TreeNodeEx(label); }
        public ScopeTreeNodeEx(string label, ImGuiTreeNodeFlags flags) { IsOpen = ImGui.TreeNodeEx(label, flags); }
        public ScopeTreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt) { IsOpen = ImGui.TreeNodeEx(str_id, flags, fmt); }
        protected override void CloseScope() { if (IsOpen) ImGui.TreePop(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.TreePop / ImGui.TreePop
    /// </summary>
    public class ScopeTreePop : GUI.Scope
    {
        public ScopeTreePop() { ImGui.TreePop(); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.TreePush / ImGui.TreePop
    /// </summary>
    public class ScopeTreePush : GUI.Scope
    {
        public ScopeTreePush() { ImGui.TreePush(); }
        public ScopeTreePush(IntPtr ptr_id) { ImGui.TreePush(ptr_id); }
        public ScopeTreePush(string str_id) { ImGui.TreePush(str_id); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    /// <summary>
    /// Implement a C# scope for this call set: ImGui.Begin / ImGui.End
    /// </summary>
    public class ScopeWindow : GUI.Scope
    {
        public bool IsOpen { get; }
        public ScopeWindow(string name) { IsOpen = ImGui.Begin(name); }
        public ScopeWindow(string name, ref bool p_open) { IsOpen = ImGui.Begin(name, ref p_open); }
        public ScopeWindow(string name, ref bool p_open, ImGuiWindowFlags flags) { IsOpen = ImGui.Begin(name, ref p_open, flags); }
        protected override void CloseScope() { if (IsOpen) ImGui.End(); }
    }



    public static partial class ImGuiUn
    {
        public static ScopeChild ScopeChild(string str_id)
        { return new ScopeChild(str_id); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size)
        { return new ScopeChild(str_id, size); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size, bool border)
        { return new ScopeChild(str_id, size, border); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size, bool border, ImGuiWindowFlags flags)
        { return new ScopeChild(str_id, size, border, flags); }
        public static ScopeChild ScopeChild(uint id)
        { return new ScopeChild(id); }
        public static ScopeChild ScopeChild(uint id, Vector2 size)
        { return new ScopeChild(id, size); }
        public static ScopeChild ScopeChild(uint id, Vector2 size, bool border)
        { return new ScopeChild(id, size, border); }
        public static ScopeChild ScopeChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags)
        { return new ScopeChild(id, size, border, flags); }
        public static ScopeChildFrame ScopeChildFrame(uint id, Vector2 size)
        { return new ScopeChildFrame(id, size); }
        public static ScopeChildFrame ScopeChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags)
        { return new ScopeChildFrame(id, size, flags); }
        public static ScopeCombo ScopeCombo(string label, string preview_value)
        { return new ScopeCombo(label, preview_value); }
        public static ScopeCombo ScopeCombo(string label, string preview_value, ImGuiComboFlags flags)
        { return new ScopeCombo(label, preview_value, flags); }
        public static ScopeDragDropSource ScopeDragDropSource()
        { return new ScopeDragDropSource(); }
        public static ScopeDragDropSource ScopeDragDropSource(ImGuiDragDropFlags flags)
        { return new ScopeDragDropSource(flags); }
        public static ScopeDragDropTarget ScopeDragDropTarget()
        { return new ScopeDragDropTarget(); }
        public static ScopeGroup ScopeGroup()
        { return new ScopeGroup(); }
        public static ScopeIndent ScopeIndent()
        { return new ScopeIndent(); }
        public static ScopeIndent ScopeIndent(float indent_w)
        { return new ScopeIndent(indent_w); }
        public static ScopeMainMenuBar ScopeMainMenuBar()
        { return new ScopeMainMenuBar(); }
        public static ScopeMenu ScopeMenu(string label)
        { return new ScopeMenu(label); }
        public static ScopeMenu ScopeMenu(string label, bool enabled)
        { return new ScopeMenu(label, enabled); }
        public static ScopeMenuBar ScopeMenuBar()
        { return new ScopeMenuBar(); }
        public static ScopePopup ScopePopup(string str_id)
        { return new ScopePopup(str_id); }
        public static ScopePopup ScopePopup(string str_id, ImGuiWindowFlags flags)
        { return new ScopePopup(str_id, flags); }
        public static ScopePopupContextItem ScopePopupContextItem()
        { return new ScopePopupContextItem(); }
        public static ScopePopupContextItem ScopePopupContextItem(string str_id)
        { return new ScopePopupContextItem(str_id); }
        public static ScopePopupContextItem ScopePopupContextItem(string str_id, ImGuiMouseButton mouse_button)
        { return new ScopePopupContextItem(str_id, mouse_button); }
        public static ScopePopupContextVoid ScopePopupContextVoid()
        { return new ScopePopupContextVoid(); }
        public static ScopePopupContextVoid ScopePopupContextVoid(string str_id)
        { return new ScopePopupContextVoid(str_id); }
        public static ScopePopupContextVoid ScopePopupContextVoid(string str_id, ImGuiMouseButton mouse_button)
        { return new ScopePopupContextVoid(str_id, mouse_button); }
        public static ScopePopupContextWindow ScopePopupContextWindow()
        { return new ScopePopupContextWindow(); }
        public static ScopePopupContextWindow ScopePopupContextWindow(string str_id)
        { return new ScopePopupContextWindow(str_id); }
        public static ScopePopupContextWindow ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button)
        { return new ScopePopupContextWindow(str_id, mouse_button); }
        public static ScopePopupContextWindow ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button, bool also_over_items)
        { return new ScopePopupContextWindow(str_id, mouse_button, also_over_items); }
        public static ScopePopupModal ScopePopupModal(string name)
        { return new ScopePopupModal(name); }
        public static ScopePopupModal ScopePopupModal(string name, ref bool p_open)
        { return new ScopePopupModal(name, ref p_open); }
        public static ScopePopupModal ScopePopupModal(string name, ref bool p_open, ImGuiWindowFlags flags)
        { return new ScopePopupModal(name, ref p_open, flags); }
        public static ScopeTabBar ScopeTabBar(string str_id)
        { return new ScopeTabBar(str_id); }
        public static ScopeTabBar ScopeTabBar(string str_id, ImGuiTabBarFlags flags)
        { return new ScopeTabBar(str_id, flags); }
        public static ScopeTabItem ScopeTabItem(string label)
        { return new ScopeTabItem(label); }
        public static ScopeTabItem ScopeTabItem(string label, ref bool p_open)
        { return new ScopeTabItem(label, ref p_open); }
        public static ScopeTabItem ScopeTabItem(string label, ref bool p_open, ImGuiTabItemFlags flags)
        { return new ScopeTabItem(label, ref p_open, flags); }
        public static ScopeTooltip ScopeTooltip()
        { return new ScopeTooltip(); }
        public static ScopeTreeNode ScopeTreeNode(IntPtr ptr_id, string fmt)
        { return new ScopeTreeNode(ptr_id, fmt); }
        public static ScopeTreeNode ScopeTreeNode(string label)
        { return new ScopeTreeNode(label); }
        public static ScopeTreeNode ScopeTreeNode(string str_id, string fmt)
        { return new ScopeTreeNode(str_id, fmt); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt)
        { return new ScopeTreeNodeEx(ptr_id, flags, fmt); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string label)
        { return new ScopeTreeNodeEx(label); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string label, ImGuiTreeNodeFlags flags)
        { return new ScopeTreeNodeEx(label, flags); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt)
        { return new ScopeTreeNodeEx(str_id, flags, fmt); }
        public static ScopeTreePop ScopeTreePop()
        { return new ScopeTreePop(); }
        public static ScopeTreePush ScopeTreePush()
        { return new ScopeTreePush(); }
        public static ScopeTreePush ScopeTreePush(IntPtr ptr_id)
        { return new ScopeTreePush(ptr_id); }
        public static ScopeTreePush ScopeTreePush(string str_id)
        { return new ScopeTreePush(str_id); }
        public static ScopeWindow ScopeWindow(string name)
        { return new ScopeWindow(name); }
        public static ScopeWindow ScopeWindow(string name, ref bool p_open)
        { return new ScopeWindow(name, ref p_open); }
        public static ScopeWindow ScopeWindow(string name, ref bool p_open, ImGuiWindowFlags flags)
        { return new ScopeWindow(name, ref p_open, flags); }

    }
}
