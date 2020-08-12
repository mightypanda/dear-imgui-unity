namespace ImGuiNET
{
    using System;
    using UnityEngine;

    public class ScopeTreeNode : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeTreeNode(string label) { ReturnValue = ImGui.TreeNode(label); }
        public ScopeTreeNode(string str_id, string fmt) { ReturnValue = ImGui.TreeNode(str_id, fmt); }
        public ScopeTreeNode(IntPtr ptr_id, string fmt) { ReturnValue = ImGui.TreeNode(ptr_id, fmt); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    public class ScopeTreeNodeEx : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeTreeNodeEx(string label) { ReturnValue = ImGui.TreeNodeEx(label); }
        public ScopeTreeNodeEx(string label, ImGuiTreeNodeFlags flags) { ReturnValue = ImGui.TreeNodeEx(label, flags); }
        public ScopeTreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt) { ReturnValue = ImGui.TreeNodeEx(str_id, flags, fmt); }
        public ScopeTreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt) { ReturnValue = ImGui.TreeNodeEx(ptr_id, flags, fmt); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    public class ScopeTreePop : ImGuiScope
    {
        public ScopeTreePop() { ImGui.TreePop(); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    public class ScopeTreePush : ImGuiScope
    {
        public ScopeTreePush() { ImGui.TreePush(); }
        public ScopeTreePush(string str_id) { ImGui.TreePush(str_id); }
        public ScopeTreePush(IntPtr ptr_id) { ImGui.TreePush(ptr_id); }
        protected override void CloseScope() { ImGui.TreePop(); }
    }

    public class ScopePopup : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopePopup(string str_id) { ReturnValue = ImGui.BeginPopup(str_id); }
        public ScopePopup(string str_id, ImGuiWindowFlags flags) { ReturnValue = ImGui.BeginPopup(str_id, flags); }
        protected override void CloseScope() { ImGui.EndPopup(); }
    }

    public class ScopePopupContextItem : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopePopupContextItem() { ReturnValue = ImGui.BeginPopupContextItem(); }
        public ScopePopupContextItem(string str_id) { ReturnValue = ImGui.BeginPopupContextItem(str_id); }
        public ScopePopupContextItem(string str_id, ImGuiMouseButton mouse_button) { ReturnValue = ImGui.BeginPopupContextItem(str_id, mouse_button); }
        protected override void CloseScope() { ImGui.EndPopup(); }
    }

    public class ScopePopupContextVoid : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopePopupContextVoid() { ReturnValue = ImGui.BeginPopupContextVoid(); }
        public ScopePopupContextVoid(string str_id) { ReturnValue = ImGui.BeginPopupContextVoid(str_id); }
        public ScopePopupContextVoid(string str_id, ImGuiMouseButton mouse_button) { ReturnValue = ImGui.BeginPopupContextVoid(str_id, mouse_button); }
        protected override void CloseScope() { ImGui.EndPopup(); }
    }

    public class ScopePopupContextWindow : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopePopupContextWindow() { ReturnValue = ImGui.BeginPopupContextWindow(); }
        public ScopePopupContextWindow(string str_id) { ReturnValue = ImGui.BeginPopupContextWindow(str_id); }
        public ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button) { ReturnValue = ImGui.BeginPopupContextWindow(str_id, mouse_button); }
        public ScopePopupContextWindow(string str_id, ImGuiMouseButton mouse_button, bool also_over_items) { ReturnValue = ImGui.BeginPopupContextWindow(str_id, mouse_button, also_over_items); }
        protected override void CloseScope() { ImGui.EndPopup(); }
    }

    public class ScopePopupModal : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopePopupModal(string name) { ReturnValue = ImGui.BeginPopupModal(name); }
        public ScopePopupModal(string name, ref bool p_open) { ReturnValue = ImGui.BeginPopupModal(name, ref p_open); }
        public ScopePopupModal(string name, ref bool p_open, ImGuiWindowFlags flags) { ReturnValue = ImGui.BeginPopupModal(name, ref p_open, flags); }
        protected override void CloseScope() { ImGui.EndPopup(); }
    }

    public class ScopeIndent : ImGuiScope
    {
        public ScopeIndent() { ImGui.Indent(); }
        public ScopeIndent(float indent_w) { ImGui.Indent(indent_w); }
        protected override void CloseScope() { ImGui.Unindent(); }
    }

    public class ScopeWindow : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeWindow(string name) { ReturnValue = ImGui.Begin(name); }
        public ScopeWindow(string name, ref bool p_open) { ReturnValue = ImGui.Begin(name, ref p_open); }
        public ScopeWindow(string name, ref bool p_open, ImGuiWindowFlags flags) { ReturnValue = ImGui.Begin(name, ref p_open, flags); }
        protected override void CloseScope() { ImGui.End(); }
    }

    public class ScopeChild : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeChild(string str_id) { ReturnValue = ImGui.BeginChild(str_id); }
        public ScopeChild(uint id) { ReturnValue = ImGui.BeginChild(id); }
        public ScopeChild(string str_id, Vector2 size) { ReturnValue = ImGui.BeginChild(str_id, size); }
        public ScopeChild(uint id, Vector2 size) { ReturnValue = ImGui.BeginChild(id, size); }
        public ScopeChild(string str_id, Vector2 size, bool border) { ReturnValue = ImGui.BeginChild(str_id, size, border); }
        public ScopeChild(uint id, Vector2 size, bool border) { ReturnValue = ImGui.BeginChild(id, size, border); }
        public ScopeChild(string str_id, Vector2 size, bool border, ImGuiWindowFlags flags) { ReturnValue = ImGui.BeginChild(str_id, size, border, flags); }
        public ScopeChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags) { ReturnValue = ImGui.BeginChild(id, size, border, flags); }
        protected override void CloseScope() { ImGui.EndChild(); }
    }

    public class ScopeChildFrame : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeChildFrame(uint id, Vector2 size) { ReturnValue = ImGui.BeginChildFrame(id, size); }
        public ScopeChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags) { ReturnValue = ImGui.BeginChildFrame(id, size, flags); }
        protected override void CloseScope() { ImGui.EndChildFrame(); }
    }

    public class ScopeCombo : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeCombo(string label, string preview_value) { ReturnValue = ImGui.BeginCombo(label, preview_value); }
        public ScopeCombo(string label, string preview_value, ImGuiComboFlags flags) { ReturnValue = ImGui.BeginCombo(label, preview_value, flags); }
        protected override void CloseScope() { ImGui.EndCombo(); }
    }

    public class ScopeDragDropSource : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeDragDropSource() { ReturnValue = ImGui.BeginDragDropSource(); }
        public ScopeDragDropSource(ImGuiDragDropFlags flags) { ReturnValue = ImGui.BeginDragDropSource(flags); }
        protected override void CloseScope() { ImGui.EndDragDropSource(); }
    }

    public class ScopeDragDropTarget : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeDragDropTarget() { ReturnValue = ImGui.BeginDragDropTarget(); }
        protected override void CloseScope() { ImGui.EndDragDropTarget(); }
    }

    public class ScopeGroup : ImGuiScope
    {
        public ScopeGroup() { ImGui.BeginGroup(); }
        protected override void CloseScope() { ImGui.EndGroup(); }
    }

    public class ScopeMainMenuBar : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeMainMenuBar() { ReturnValue = ImGui.BeginMainMenuBar(); }
        protected override void CloseScope() { ImGui.EndMainMenuBar(); }
    }

    public class ScopeMenu : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeMenu(string label) { ReturnValue = ImGui.BeginMenu(label); }
        public ScopeMenu(string label, bool enabled) { ReturnValue = ImGui.BeginMenu(label, enabled); }
        protected override void CloseScope() { ImGui.EndMenu(); }
    }

    public class ScopeMenuBar : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeMenuBar() { ReturnValue = ImGui.BeginMenuBar(); }
        protected override void CloseScope() { ImGui.EndMenuBar(); }
    }

    public class ScopeTabBar : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeTabBar(string str_id) { ReturnValue = ImGui.BeginTabBar(str_id); }
        public ScopeTabBar(string str_id, ImGuiTabBarFlags flags) { ReturnValue = ImGui.BeginTabBar(str_id, flags); }
        protected override void CloseScope() { ImGui.EndTabBar(); }
    }

    public class ScopeTabItem : ImGuiScope
    {
        public bool ReturnValue { get; }
        public ScopeTabItem(string label) { ReturnValue = ImGui.BeginTabItem(label); }
        public ScopeTabItem(string label, ref bool p_open) { ReturnValue = ImGui.BeginTabItem(label, ref p_open); }
        public ScopeTabItem(string label, ref bool p_open, ImGuiTabItemFlags flags) { ReturnValue = ImGui.BeginTabItem(label, ref p_open, flags); }
        protected override void CloseScope() { ImGui.EndTabItem(); }
    }

    public class ScopeTooltip : ImGuiScope
    {
        public ScopeTooltip() { ImGui.BeginTooltip(); }
        protected override void CloseScope() { ImGui.EndTooltip(); }
    }



    public static partial class ImGuiUn
    {
        public static ScopeTreeNode ScopeTreeNode(string label)
        { return new ScopeTreeNode(label); }
        public static ScopeTreeNode ScopeTreeNode(string str_id, string fmt)
        { return new ScopeTreeNode(str_id, fmt); }
        public static ScopeTreeNode ScopeTreeNode(IntPtr ptr_id, string fmt)
        { return new ScopeTreeNode(ptr_id, fmt); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string label)
        { return new ScopeTreeNodeEx(label); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string label, ImGuiTreeNodeFlags flags)
        { return new ScopeTreeNodeEx(label, flags); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt)
        { return new ScopeTreeNodeEx(str_id, flags, fmt); }
        public static ScopeTreeNodeEx ScopeTreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt)
        { return new ScopeTreeNodeEx(ptr_id, flags, fmt); }
        public static ScopeTreePop ScopeTreePop()
        { return new ScopeTreePop(); }
        public static ScopeTreePush ScopeTreePush()
        { return new ScopeTreePush(); }
        public static ScopeTreePush ScopeTreePush(string str_id)
        { return new ScopeTreePush(str_id); }
        public static ScopeTreePush ScopeTreePush(IntPtr ptr_id)
        { return new ScopeTreePush(ptr_id); }
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
        public static ScopeIndent ScopeIndent()
        { return new ScopeIndent(); }
        public static ScopeIndent ScopeIndent(float indent_w)
        { return new ScopeIndent(indent_w); }
        public static ScopeWindow ScopeWindow(string name)
        { return new ScopeWindow(name); }
        public static ScopeWindow ScopeWindow(string name, ref bool p_open)
        { return new ScopeWindow(name, ref p_open); }
        public static ScopeWindow ScopeWindow(string name, ref bool p_open, ImGuiWindowFlags flags)
        { return new ScopeWindow(name, ref p_open, flags); }
        public static ScopeChild ScopeChild(string str_id)
        { return new ScopeChild(str_id); }
        public static ScopeChild ScopeChild(uint id)
        { return new ScopeChild(id); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size)
        { return new ScopeChild(str_id, size); }
        public static ScopeChild ScopeChild(uint id, Vector2 size)
        { return new ScopeChild(id, size); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size, bool border)
        { return new ScopeChild(str_id, size, border); }
        public static ScopeChild ScopeChild(uint id, Vector2 size, bool border)
        { return new ScopeChild(id, size, border); }
        public static ScopeChild ScopeChild(string str_id, Vector2 size, bool border, ImGuiWindowFlags flags)
        { return new ScopeChild(str_id, size, border, flags); }
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
        public static ScopeMainMenuBar ScopeMainMenuBar()
        { return new ScopeMainMenuBar(); }
        public static ScopeMenu ScopeMenu(string label)
        { return new ScopeMenu(label); }
        public static ScopeMenu ScopeMenu(string label, bool enabled)
        { return new ScopeMenu(label, enabled); }
        public static ScopeMenuBar ScopeMenuBar()
        { return new ScopeMenuBar(); }
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

    }
}
