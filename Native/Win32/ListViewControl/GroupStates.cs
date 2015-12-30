#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Specifies the listview group's state.
    /// </summary>
    [Flags]
    public enum GroupStates : uint
    {
        /// <summary>
        /// Groups are expanded, the group name is displayed, and all items in the group are displayed.
        /// </summary>
        LVGS_NORMAL = 0,
        /// <summary>
        /// The group is collapsed.
        /// </summary>
        LVGS_COLLAPSED = 1,
        /// <summary>
        /// The group is hidden.
        /// </summary>
        LVGS_HIDDEN = 2,
        /// <summary>
        /// Version 6.00 and Windows Vista. The group does not display a header.
        /// </summary>
        LVGS_NOHEADER = 4,
        /// <summary>
        /// Version 6.00 and Windows Vista. The group can be collapsed.
        /// </summary>
        LVGS_COLLAPSIBLE = 8,
        /// <summary>
        /// Version 6.00 and Windows Vista. The group has keyboard focus.
        /// </summary>
        LVGS_FOCUSED = 16,
        /// <summary>
        /// Version 6.00 and Windows Vista. The group is selected.
        /// </summary>
        LVGS_SELECTED = 32,
        /// <summary>
        /// Version 6.00 and Windows Vista. The group displays only a portion of its items.
        /// </summary>
        LVGS_SUBSETED = 64,
        /// <summary>
        /// Version 6.00 and Windows Vista. The subset link of the group has keyboard focus.
        /// </summary>
        LVGS_SUBSETLINKFOCUSED = 128
    }
}
#endif