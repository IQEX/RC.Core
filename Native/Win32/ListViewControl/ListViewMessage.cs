#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using RC.Framework.Native.Win32.GenericControl;
    /// <summary>
    /// Messages for listview.
    /// </summary>
    public enum ListViewMessage
	{
		/// <summary>
		/// For value offset.
		/// </summary>
		LVM_FIRST = 0x1000,
		/// <summary>
		/// Gets the background color of a list-view control.
		/// </summary>
		LVM_GETBKCOLOR = LVM_FIRST,
		/// <summary>
		/// Sets the background color of a list-view control.
		/// </summary>
		LVM_SETBKCOLOR = LVM_FIRST + 1,
		/// <summary>
		/// Retrieves the handle to an image list used for drawing list-view items.
		/// </summary>
		LVM_GETIMAGELIST = LVM_FIRST + 2,
		/// <summary>
		/// Assigns an image list to a list-view control.
		/// </summary>
		LVM_SETIMAGELIST = LVM_FIRST + 3,
		/// <summary>
		/// Retrieves the number of items in a list-view control. 
		/// </summary>
		LVM_GETITEMCOUNT = LVM_FIRST + 4,

		/// <summary>
		/// Removes an item from a list-view control. 
		/// </summary>
		LVM_DELETEITEM = LVM_FIRST + 8,
		/// <summary>
		/// Removes all items from a list-view control.
		/// </summary>
		LVM_DELETEALLITEMS = LVM_FIRST + 9,
		/// <summary>
		/// Gets the callback mask for a list-view control. 
		/// </summary>
		LVM_GETCALLBACKMASK = LVM_FIRST + 10,
		/// <summary>
		/// Changes the callback mask for a list-view control.
		/// </summary>
		LVM_SETCALLBACKMASK = LVM_FIRST + 11,
		/// <summary>
		/// Searches for a list-view item that has the specified properties and bears the specified relationship to a specified item.
		/// </summary>
		LVM_GETNEXTITEM = LVM_FIRST + 12,
		/// <summary>
		/// Retrieves the bounding rectangle for all or part of an item in the current view.
		/// </summary>
		LVM_GETITEMRECT = LVM_FIRST + 14,
		/// <summary>
		/// Moves an item to a specified position in a list-view control (must be in icon or small icon view). 
		/// </summary>
		LVM_SETITEMPOSITION = LVM_FIRST + 15,
		/// <summary>
		/// Retrieves the position of a list-view item.
		/// </summary>
		LVM_GETITEMPOSITION = LVM_FIRST + 16,
		/// <summary>
		/// Determines which list-view item, if any, is at a specified position. 
		/// </summary>
		LVM_HITTEST = LVM_FIRST + 18,
		/// <summary>
		/// Ensures that a list-view item is either entirely or partially visible, scrolling the list-view control if necessary.
		/// </summary>
		LVM_ENSUREVISIBLE = LVM_FIRST + 19,

		/// <summary>
		/// Scrolls the content of a list-view control. 
		/// </summary>
		LVM_SCROLL = LVM_FIRST + 20,
		/// <summary>
		/// Forces a list-view control to redraw a range of items. 
		/// </summary>
		LVM_REDRAWITEMS = LVM_FIRST + 21,
		/// <summary>
		/// Arranges items in icon view.
		/// </summary>
		LVM_ARRANGE = LVM_FIRST + 22,
		/// <summary>
		/// Gets the handle to the edit control being used to edit a list-view item's text.
		/// </summary>
		LVM_GETEDITCONTROL = LVM_FIRST + 24,
		/// <summary>
		/// Removes a column from a list-view control.
		/// </summary>
		LVM_DELETECOLUMN = LVM_FIRST + 28,
		/// <summary>
		/// Gets the width of a column in report or list view.
		/// </summary>
		LVM_GETCOLUMNWIDTH = LVM_FIRST + 29,

		/// <summary>
		/// Changes the width of a column in report-view mode or the width of all columns in list-view mode.
		/// </summary>
		LVM_SETCOLUMNWIDTH = LVM_FIRST + 30,
		/// <summary>
		/// Gets the handle to the header control used by the list-view control.
		/// </summary>
		LVM_GETHEADER = LVM_FIRST + 31,
		/// <summary>
		/// Creates a drag image list for the specified item.
		/// </summary>
		LVM_CREATEDRAGIMAGE = LVM_FIRST + 33,
		/// <summary>
		/// Retrieves the bounding rectangle of all items in the list-view control. The list view must be in icon or small icon view. 
		/// </summary>
		LVM_GETVIEWRECT = LVM_FIRST + 34,
		/// <summary>
		/// Retrieves the text color of a list-view control.
		/// </summary>
		LVM_GETTEXTCOLOR = LVM_FIRST + 35,
		/// <summary>
		/// Sets the text color of a list-view control. 
		/// </summary>
		LVM_SETTEXTCOLOR = LVM_FIRST + 36,
		/// <summary>
		/// Retrieves the text background color of a list-view control.
		/// </summary>
		LVM_GETTEXTBKCOLOR = LVM_FIRST + 37,
		/// <summary>
		/// Sets the background color of text in a list-view control. 
		/// </summary>
		LVM_SETTEXTBKCOLOR = LVM_FIRST + 38,
		/// <summary>
		/// Retrieves the index of the topmost visible item when in list or report view.
		/// </summary>
		LVM_GETTOPINDEX = LVM_FIRST + 39,

		/// <summary>
		/// Calculates the number of items that can fit vertically in the visible area of a list-view control when in list or report view. Only fully visible items are counted.
		/// </summary>
		LVM_GETCOUNTPERPAGE = LVM_FIRST + 40,
		/// <summary>
		/// Retrieves the current view origin for a list-view control.
		/// </summary>
		LVM_GETORIGIN = LVM_FIRST + 41,
		/// <summary>
		/// Updates a list-view item. If the list-view control has the LVS_AUTOARRANGE style, this macro causes the list-view control to be arranged. 
		/// </summary>
		LVM_UPDATE = LVM_FIRST + 42,
		/// <summary>
		/// Changes the state of an item in a list-view control.
		/// </summary>
		LVM_SETITEMSTATE = LVM_FIRST + 43,
		/// <summary>
		/// Retrieves the state of a list-view item. 
		/// </summary>
		LVM_GETITEMSTATE = LVM_FIRST + 44,
		/// <summary>
		/// Causes the list-view control to allocate memory for the specified number of items or sets the virtual number of items in a virtual list-view control. This depends on how the list-view control was created. 
		/// </summary>
		LVM_SETITEMCOUNT = LVM_FIRST + 47,
		/// <summary>
		/// Uses an application-defined comparison function to sort the items of a list-view control. The index of each item changes to reflect the new sequence.
		/// </summary>
		LVM_SORTITEMS = LVM_FIRST + 48,
		/// <summary>
		/// Moves an item to a specified position in a list-view control (must be in icon or small icon view). This message differs from the LVM_SETITEMPOSITION message in that it uses 32-bit coordinates. 
		/// </summary>
		LVM_SETITEMPOSITION32 = LVM_FIRST + 49,

		/// <summary>
		/// Determines the number of selected items in a list-view control. 
		/// </summary>
		LVM_GETSELECTEDCOUNT = LVM_FIRST + 50,
		/// <summary>
		/// Determines the spacing between items in a list-view control.
		/// </summary>
		LVM_GETITEMSPACING = LVM_FIRST + 51,
		/// <summary>
		/// Sets the spacing between icons in list-view controls that have the LVS_ICON style.
		/// </summary>
		LVM_SETICONSPACING = LVM_FIRST + 53,
		/// <summary>
		/// Sets extended styles in list-view controls. 
		/// </summary>
		LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54,

		/// <summary>
		/// Gets the extended styles that are currently in use for a given list-view control. 
		/// </summary>
		LVM_GETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 55,
		/// <summary>
		/// Retrieves information about the bounding rectangle for a subitem in a list-view control.
		/// </summary>
		LVM_GETSUBITEMRECT = LVM_FIRST + 56,
		/// <summary>
		/// Determines which list-view item or subitem is at a given position. 
		/// </summary>
		LVM_SUBITEMHITTEST = LVM_FIRST + 57,
		/// <summary>
		/// Sets the left-to-right order of columns in a list-view control. 
		/// </summary>
		LVM_SETCOLUMNORDERARRAY = LVM_FIRST + 58,
		/// <summary>
		/// Gets the current left-to-right order of columns in a list-view control.
		/// </summary>
		LVM_GETCOLUMNORDERARRAY = LVM_FIRST + 59,

		/// <summary>
		/// Sets the hot item for a list-view control. 
		/// </summary>
		LVM_SETHOTITEM = LVM_FIRST + 60,
		/// <summary>
		/// Retrieves the index of the hot item. 
		/// </summary>
		LVM_GETHOTITEM = LVM_FIRST + 61,
		/// <summary>
		/// Sets the HCURSOR value that the list-view control uses when the pointer is over an item while hot tracking is enabled.
		/// </summary>
		LVM_SETHOTCURSOR = LVM_FIRST + 62,
		/// <summary>
		/// Retrieves the HCURSOR value used when the pointer is over an item while hot tracking is enabled. 
		/// </summary>
		LVM_GETHOTCURSOR = LVM_FIRST + 63,
		/// <summary>
		/// Calculates the approximate width and height required to display a given number of items. 
		/// </summary>
		LVM_APPROXIMATEVIEWRECT = LVM_FIRST + 64,
		/// <summary>
		/// Sets the working areas within a list-view control.
		/// </summary>
		LVM_SETWORKAREAS = LVM_FIRST + 65,
		/// <summary>
		/// Retrieves the selection mark from a list-view control.
		/// </summary>
		LVM_GETSELECTIONMARK = LVM_FIRST + 66,
		/// <summary>
		/// Sets the selection mark in a list-view control.
		/// </summary>
		LVM_SETSELECTIONMARK = LVM_FIRST + 67,

		/// <summary>
		/// Retrieves the working areas from a list-view control.
		/// </summary>
		LVM_GETWORKAREAS = LVM_FIRST + 70,
		/// <summary>
		/// Sets the amount of time which the mouse cursor must hover over an item before it is selected.
		/// </summary>
		LVM_SETHOVERTIME = LVM_FIRST + 71,
		/// <summary>
		/// Retrieves the amount of time that the mouse cursor must hover over an item before it is selected. 
		/// </summary>
		LVM_GETHOVERTIME = LVM_FIRST + 72,
		/// <summary>
		/// Retrieves the number of working areas in a list-view control. 
		/// </summary>
		LVM_GETNUMBEROFWORKAREAS = LVM_FIRST + 73,
		/// <summary>
		/// Sets the tooltip control that the list-view control will use to display tooltips. 
		/// </summary>
		LVM_SETTOOLTIPS = LVM_FIRST + 74,
		/// <summary>
		/// Retrieves some or all of a list-view item's attributes. 
		/// </summary>
		LVM_GETITEM = LVM_FIRST + 75,
		/// <summary>
		/// Sets some or all of a list-view item's attributes. You can also send LVM_SETITEM to set the text of a subitem.
		/// </summary>
		LVM_SETITEM = LVM_FIRST + 76,
		/// <summary>
		/// Inserts a new item in a list-view control. 
		/// </summary>
		LVM_INSERTITEM = LVM_FIRST + 77,
		/// <summary>
		/// Retrieves the tooltip control that the list-view control uses to display tooltips.
		/// </summary>
		LVM_GETTOOLTIPS = LVM_FIRST + 78,

		/// <summary>
		/// Uses an application-defined comparison function to sort the items of a list-view control. The index of each item changes to reflect the new sequence. 
		/// </summary>
		LVM_SORTITEMSEX = LVM_FIRST + 81,
		/// <summary>
		/// Searches for a list-view item with the specified characteristics.
		/// </summary>
		LVM_FINDITEM = LVM_FIRST + 83,
		/// <summary>
		/// Determines the width of a specified string using the specified list-view control's current font.
		/// </summary>
		LVM_GETSTRINGWIDTH = LVM_FIRST + 87,

		/// <summary>
		/// Gets the state for a specified group. 
		/// </summary>
		LVM_GETGROUPSTATE = LVM_FIRST + 92,
		/// <summary>
		/// Gets the group that has the focus. 
		/// </summary>
		LVM_GETFOCUSEDGROUP = LVM_FIRST + 93,
		/// <summary>
		/// Gets the attributes of a list-view control's column. 
		/// </summary>
		LVM_GETCOLUMN = LVM_FIRST + 95,
		/// <summary>
		/// Sets the attributes of a list-view column.
		/// </summary>
		LVM_SETCOLUMN = LVM_FIRST + 96,
		/// <summary>
		/// Inserts a new column in a list-view control. 
		/// </summary>
		LVM_INSERTCOLUMN = LVM_FIRST + 97,
		/// <summary>
		/// Gets the rectangle for a specified group.
		/// </summary>
		LVM_GETGROUPRECT = LVM_FIRST + 98,

		/// <summary>
		/// Retrieves the text of a list-view item or subitem.
		/// </summary>
		LVM_GETITEMTEXT = LVM_FIRST + 115,
		/// <summary>
		/// Changes the text of a list-view item or subitem. 
		/// </summary>
		LVM_SETITEMTEXT = LVM_FIRST + 116,
		/// <summary>
		/// Retrieves the incremental search string of a list-view control.
		/// </summary>
		LVM_GETISEARCHSTRING = LVM_FIRST + 117,
		/// <summary>
		/// Begins in-place editing of the specified list-view item's text. The message implicitly selects and focuses the specified item.
		/// </summary>
		LVM_EDITLABEL = LVM_FIRST + 118,

		/// <summary>
		/// Sets the background image in a list-view control. 
		/// </summary>
		LVM_SETBKIMAGE = LVM_FIRST + 138,
		/// <summary>
		/// Gets the background image in a list-view control. 
		/// </summary>
		LVM_GETBKIMAGE = LVM_FIRST + 139,
		/// <summary>
		/// Sets the index of the selected column.
		/// </summary>
		LVM_SETSELECTEDCOLUMN = LVM_FIRST + 140,
		/// <summary>
		/// Sets the view of a list-view control.
		/// </summary>
		LVM_SETVIEW = LVM_FIRST + 142,
		/// <summary>
		/// Retrieves the current view of a list-view control.
		/// </summary>
		LVM_GETVIEW = LVM_FIRST + 143,
		/// <summary>
		/// Inserts a group into a list-view control.
		/// </summary>
		LVM_INSERTGROUP = LVM_FIRST + 145,
		/// <summary>
		/// Sets group information.
		/// </summary>
		LVM_SETGROUPINFO = LVM_FIRST + 147,
		/// <summary>
		/// Gets group information.
		/// </summary>
		LVM_GETGROUPINFO = LVM_FIRST + 149,


		/// <summary>
		/// Removes a group from a list-view control.
		/// </summary>
		LVM_REMOVEGROUP = LVM_FIRST + 150,
		/// <summary>
		/// This message is not implemented.
		/// </summary>
		LVM_MOVEGROUP = LVM_FIRST + 151,
		/// <summary>
		/// Gets the number of groups.
		/// </summary>
		LVM_GETGROUPCOUNT = LVM_FIRST + 152,
		/// <summary>
		/// Gets information on a specified group. 
		/// </summary>
		LVM_GETGROUPINFOBYINDEX = LVM_FIRST + 153,
		/// <summary>
		/// This message is not implemented.
		/// </summary>
		LVM_MOVEITEMTOGROUP = LVM_FIRST + 154,
		/// <summary>
		/// Sets information about the display of groups.
		/// </summary>
		LVM_SETGROUPMETRICS = LVM_FIRST + 155,
		/// <summary>
		/// Gets information about the display of groups.
		/// </summary>
		LVM_GETGROUPMETRICS = LVM_FIRST + 156,
		/// <summary>
		/// Enables or disables whether the items in a list-view control display as a group.
		/// </summary>
		LVM_ENABLEGROUPVIEW = LVM_FIRST + 157,
		/// <summary>
		/// Uses an application-defined comparison function to sort groups by ID within a list-view control.
		/// </summary>
		LVM_SORTGROUPS = LVM_FIRST + 158,
		/// <summary>
		/// Inserts a group into an ordered list of groups.
		/// </summary>
		LVM_INSERTGROUPSORTED = LVM_FIRST + 159,

		/// <summary>
		/// Removes all groups from a list-view control.
		/// </summary>
		LVM_REMOVEALLGROUPS = LVM_FIRST + 160,
		/// <summary>
		/// Determines whether the list-view control has a specified group.
		/// </summary>
		LVM_HASGROUP = LVM_FIRST + 161,
		/// <summary>
		/// Sets information that a list-view control uses in tile view.
		/// </summary>
		LVM_SETTILEVIEWINFO = LVM_FIRST + 162,
		/// <summary>
		/// Retrieves information about a list-view control in tile view.
		/// </summary>
		LVM_GETTILEVIEWINFO = LVM_FIRST + 163,
		/// <summary>
		/// Sets information for an existing tile of a list-view control.
		/// </summary>
		LVM_SETTILEINFO = LVM_FIRST + 164,
		/// <summary>
		/// Retrieves information about a tile in a list-view control.
		/// </summary>
		LVM_GETTILEINFO = LVM_FIRST + 165,
		/// <summary>
		/// Sets the insertion point to the defined position.
		/// </summary>
		LVM_SETINSERTMARK = LVM_FIRST + 166,
		/// <summary>
		/// Retrieves the position of the insertion point.
		/// </summary>
		LVM_GETINSERTMARK = LVM_FIRST + 167,
		/// <summary>
		/// Retrieves the insertion point closest to a specified point.
		/// </summary>
		LVM_INSERTMARKHITTEST = LVM_FIRST + 168,
		/// <summary>
		/// Retrieves the rectangle that bounds the insertion point.
		/// </summary>
		LVM_GETINSERTMARKRECT = LVM_FIRST + 169,

		/// <summary>
		/// Sets the color of the insertion point.
		/// </summary>
		LVM_SETINSERTMARKCOLOR = LVM_FIRST + 170,
		/// <summary>
		/// Retrieves the color of the insertion point.
		/// </summary>
		LVM_GETINSERTMARKCOLOR = LVM_FIRST + 171,
		/// <summary>
		/// Sets tooltip text in delayed response to the LVN_GETINFOTIP notification.
		/// </summary>
		LVM_SETINFOTIP = LVM_FIRST + 173,
		/// <summary>
		/// Retrieves an integer that specifies the selected column.
		/// </summary>
		LVM_GETSELECTEDCOLUMN = LVM_FIRST + 174,
		/// <summary>
		/// Checks whether the list-view control has group view enabled.
		/// </summary>
		LVM_ISGROUPVIEWENABLED = LVM_FIRST + 175,
		/// <summary>
		/// Retrieves the color of the border of a list-view control if the LVS_EX_BORDERSELECT extended window style is set.
		/// </summary>
		LVM_GETOUTLINECOLOR = LVM_FIRST + 176,
		/// <summary>
		/// Sets the color of the border of a list-view control if the LVS_EX_BORDERSELECT extended window style is set.
		/// </summary>
		LVM_SETOUTLINECOLOR = LVM_FIRST + 177,
		/// <summary>
		/// Cancels an item text editing operation.
		/// </summary>
		LVM_CANCELEDITLABEL = LVM_FIRST + 179,

		/// <summary>
		/// Maps the index of an item to a unique ID
		/// </summary>
		LVM_MAPINDEXTOID = LVM_FIRST + 180,
		/// <summary>
		/// Maps the ID of an item to an index.
		/// </summary>
		LVM_MAPIDTOINDEX = LVM_FIRST + 181,
		/// <summary>
		/// Indicates if an item in the list-view control is visible. 
		/// </summary>
		LVM_ISITEMVISIBLE = LVM_FIRST + 182,

		/// <summary>
		/// Gets the text meant for display when the list-view control appears empty.
		/// </summary>
		LVM_GETEMPTYTEXT = LVM_FIRST + 204,
		/// <summary>
		/// Retrieves the coordinates of the footer for a list-view control.
		/// </summary>
		LVM_GETFOOTERRECT = LVM_FIRST + 205,
		/// <summary>
		/// Gets information about the footer of a list-view control.
		/// </summary>
		LVM_GETFOOTERINFO = LVM_FIRST + 206,
		/// <summary>
		/// Gets the coordinates of a footer for a specified item in a list-view control.
		/// </summary>
		LVM_GETFOOTERITEMRECT = LVM_FIRST + 207,
		/// <summary>
		/// Gets information on a footer item in a list-view control.
		/// </summary>
		LVM_GETFOOTERITEM = LVM_FIRST + 208,
		/// <summary>
		/// Retrieves the bounding rectangle for all or part of a subitem in the current view of a list-view control.
		/// </summary>
		LVM_GETITEMINDEXRECT = LVM_FIRST + 209,
		/// <summary>
		/// Sets the state of a list-view item.
		/// </summary>
		LVM_SETITEMINDEXSTATE = LVM_FIRST + 210,
		/// <summary>
		/// Retrieves the index of an item in a specified list-view control that matches the specified properties and relationship to another item. 
		/// </summary>
		LVM_GETNEXTITEMINDEX = LVM_FIRST + 211,

		/// <summary>
		/// Retrieves the UNICODE character format flag for the control.
		/// </summary>
		LVM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,
		/// <summary>
		/// Sets the UNICODE character format flag for the control. This message allows you to change the character set used by the control at run time rather than having to re-create the control.
		/// </summary>
		LVM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
	}
}
#endif