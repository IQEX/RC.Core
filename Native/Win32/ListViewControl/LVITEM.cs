#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Specifies or receives the attributes of a list-view item.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVITEM
    {
        /// <summary>
        /// Set of flags that specify which members of this structure contain data to be set or which members are being requested. 
        /// </summary>
        public ItemFlags mask;
        /// <summary>
        /// Zero-based index of the item to which this structure refers.
        /// </summary>
        public int iItem;
        /// <summary>
        /// One-based index of the subitem to which this structure refers, or zero if this structure refers to an item rather than a subitem.
        /// </summary>
        public int iSubItem;
        /// <summary>
        /// Indicates the item's state, state image, and overlay image. The stateMask member indicates the valid bits of this member.
        /// </summary>
        public uint state;
        /// <summary>
        /// Value specifying which bits of the state member will be retrieved or modified.
        /// </summary>
        public uint stateMask;
        /// <summary>
        /// If the structure specifies item attributes, pszText is a string containing the item text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        /// <summary>
        /// Number of TCHARs in the buffer pointed to by pszText, including the terminating NULL.
        /// </summary>
        public int cchTextMax;
        /// <summary>
        /// Index of the item's icon in the control's image list. 
        /// </summary>
        public int iImage;
        /// <summary>
        /// Value specific to the item. If you use the LVM_SORTITEMS message, the list-view control passes this value to the application-defined comparison function. You can also use the LVM_FINDITEM message to search a list-view control for an item with a specified lParam value.
        /// </summary>
        public IntPtr lParam;
        /// <summary>
        /// Number of image widths to indent the item. 
        /// </summary>
        public int iIndent;
    }

    /// <summary>
    /// Specifies or receives the attributes of a list-view item.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVITEM_XP
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

        /// <summary>
        /// Set of flags that specify which members of this structure contain data to be set or which members are being requested. 
        /// </summary>
        public ItemFlags mask;
        /// <summary>
        /// Zero-based index of the item to which this structure refers.
        /// </summary>
        public int iItem;
        /// <summary>
        /// One-based index of the subitem to which this structure refers, or zero if this structure refers to an item rather than a subitem.
        /// </summary>
        public int iSubItem;
        /// <summary>
        /// Indicates the item's state, state image, and overlay image. The stateMask member indicates the valid bits of this member.
        /// </summary>
        public uint state;
        /// <summary>
        /// Value specifying which bits of the state member will be retrieved or modified.
        /// </summary>
        public uint stateMask;
        /// <summary>
        /// If the structure specifies item attributes, pszText is a string containing the item text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        /// <summary>
        /// Number of TCHARs in the buffer pointed to by pszText, including the terminating NULL.
        /// </summary>
        public int cchTextMax;
        /// <summary>
        /// Index of the item's icon in the control's image list. 
        /// </summary>
        public int iImage;
        /// <summary>
        /// Value specific to the item. If you use the LVM_SORTITEMS message, the list-view control passes this value to the application-defined comparison function. You can also use the LVM_FINDITEM message to search a list-view control for an item with a specified lParam value.
        /// </summary>
        public IntPtr lParam;
        /// <summary>
        /// Number of image widths to indent the item. 
        /// </summary>
        public int iIndent;

        /// <summary>
        /// Identifier of the group that the item belongs to, or one of the following values.
        /// </summary>
        public int iGroupId;

        /// <summary>
        /// Number of data columns (subitems) to display for this item in tile view. The maximum value is 20.
        /// </summary>
        public uint cColumns;

        /// <summary>
        /// A pointer to an array of column indices, specifying which columns are displayed for this item, and the order of those columns.
        /// </summary>
        public UIntPtr puColumns;

    }

    /// <summary>
    /// Specifies or receives the attributes of a list-view item.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVITEM_VISTA
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinVistaUp; } }

        /// <summary>
        /// Set of flags that specify which members of this structure contain data to be set or which members are being requested. 
        /// </summary>
        public ItemFlags mask;
        /// <summary>
        /// Zero-based index of the item to which this structure refers.
        /// </summary>
        public int iItem;
        /// <summary>
        /// One-based index of the subitem to which this structure refers, or zero if this structure refers to an item rather than a subitem.
        /// </summary>
        public int iSubItem;
        /// <summary>
        /// Indicates the item's state, state image, and overlay image. The stateMask member indicates the valid bits of this member.
        /// </summary>
        public uint state;
        /// <summary>
        /// Value specifying which bits of the state member will be retrieved or modified.
        /// </summary>
        public uint stateMask;
        /// <summary>
        /// If the structure specifies item attributes, pszText is a string containing the item text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        /// <summary>
        /// Number of TCHARs in the buffer pointed to by pszText, including the terminating NULL.
        /// </summary>
        public int cchTextMax;
        /// <summary>
        /// Index of the item's icon in the control's image list. 
        /// </summary>
        public int iImage;
        /// <summary>
        /// Value specific to the item. If you use the LVM_SORTITEMS message, the list-view control passes this value to the application-defined comparison function. You can also use the LVM_FINDITEM message to search a list-view control for an item with a specified lParam value.
        /// </summary>
        public IntPtr lParam;
        /// <summary>
        /// Number of image widths to indent the item. 
        /// </summary>
        public int iIndent;

        /// <summary>
        /// Identifier of the group that the item belongs to, or one of the following values.
        /// </summary>
        public int iGroupId;

        /// <summary>
        /// Number of data columns (subitems) to display for this item in tile view. The maximum value is 20.
        /// </summary>
        public uint cColumns;

        /// <summary>
        /// A pointer to an array of column indices, specifying which columns are displayed for this item, and the order of those columns.
        /// </summary>
        public UIntPtr puColumns;

        /// <summary>
        /// Windows Vista: Not implemented. Windows 7 and later: A pointer to an array of these ColumnFormat flags:
        /// LVCFMT_LINE_BREAK, LVCFMT_FILL, LVCFMT_WRAP, LVCFMT_NO_TITLE, LVCFMT_TILE_PLACEMENTMASK (alone or in combination), 
        /// specifying the format of each subitem in extended tile view.
        /// </summary>
        public IntPtr piColFmt;

        /// <summary>
        /// Group index of the item. Valid only for owner data/callback (single item in multiple groups).
        /// </summary>
        public int iGroup;
    }
}
#endif