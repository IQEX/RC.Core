#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Extended styles for listview.
    /// </summary>
    [Flags]
    public enum ListViewStylesEx : uint
	{
		/// <summary>
		/// Displays gridlines around items and subitems. 
		/// </summary>
        LVS_EX_GRIDLINES = 0x01,
		/// <summary>
		/// Allows images to be displayed for subitems. 
		/// </summary>
        LVS_EX_SUBITEMIMAGES = 0x02,
		/// <summary>
		/// Enables check boxes for items in a list-view control. 
		/// </summary>
        LVS_EX_CHECKBOXES = 0x04,
		/// <summary>
		/// Enables hot-track selection in a list-view control. 
		/// </summary>
        LVS_EX_TRACKSELECT = 0x08,
		/// <summary>
		/// Enables drag-and-drop reordering of columns in a list-view control. 
		/// </summary>
        LVS_EX_HEADERDRAGDROP = 0x10,
		/// <summary>
		/// When an item is selected, the item and all its subitems are highlighted.
		/// </summary>
        LVS_EX_FULLROWSELECT = 0x20,
		/// <summary>
		/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user clicks an item.
		/// </summary>
		LVS_EX_ONECLICKACTIVATE = 0x40,
		/// <summary>
		/// The list-view control sends an LVN_ITEMACTIVATE notification code to the parent window when the user double-clicks an item. 
		/// </summary>
		LVS_EX_TWOCLICKACTIVATE = 0x80,

	}
}
#endif