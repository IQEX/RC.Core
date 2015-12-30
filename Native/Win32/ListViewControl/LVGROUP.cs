#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Used to set and retrieve groups.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct LVGROUP
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

		/// <summary>
		/// Size of this structure, in bytes.
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// Mask that specifies which members of the structure are valid input. One or more of the following values:LVGF_NONENo other items are valid.
		/// </summary>
		public GroupFlags mask;

		/// <summary>
		/// Pointer to a null-terminated string that contains the header text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the header text.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszHeader;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszHeader member. If the structure is not receiving information about a group, this member is ignored.
		/// </summary>
		public int cchHeader;

		/// <summary>
		/// Pointer to a null-terminated string that contains the footer text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the footer text.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszFooter;

		/// <summary>
		/// Size in TCHARs of the buffer pointed to by the pszFooter member. If the structure is not receiving information about a group, this member is ignored.
		/// </summary>
		public int cchFooter;

		/// <summary>
		/// ID of the group.
		/// </summary>
		public int iGroupId;

		/// <summary>
		/// Mask used with LVM_GETGROUPINFO (Microsoft Windows XP and Windows Vista) and LVM_SETGROUPINFO (Windows Vista only) to specify which flags in the state value are being retrieved or set.
		/// </summary>
		public uint stateMask;

		/// <summary>
		/// Flag that can have one of the following values:LVGS_NORMALGroups are expanded, the group name is displayed, and all items in the group are displayed.
		/// </summary>
		public GroupStates state;

		/// <summary>
		/// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of the header flags. Footer flags are optional. Windows XP: Footer flags are reserved.LVGA_FOOTER_CENTERReserved.
		/// </summary>
        public GroupAlignments uAlign;
	}

    /// <summary>
    /// Used to set and retrieve groups.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVGROUP_VISTA
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinVistaUp; } }

        /// <summary>
        /// Size of this structure, in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Mask that specifies which members of the structure are valid input. One or more of the following values:LVGF_NONENo other items are valid.
        /// </summary>
        public GroupFlags mask;

        /// <summary>
        /// Pointer to a null-terminated string that contains the header text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the header text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszHeader;

        /// <summary>
        /// Size in TCHARs of the buffer pointed to by the pszHeader member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public int cchHeader;

        /// <summary>
        /// Pointer to a null-terminated string that contains the footer text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the footer text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszFooter;

        /// <summary>
        /// Size in TCHARs of the buffer pointed to by the pszFooter member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public int cchFooter;

        /// <summary>
        /// ID of the group.
        /// </summary>
        public int iGroupId;

        /// <summary>
        /// Mask used with LVM_GETGROUPINFO (Microsoft Windows XP and Windows Vista) and LVM_SETGROUPINFO (Windows Vista only) to specify which flags in the state value are being retrieved or set.
        /// </summary>
        public uint stateMask;

        /// <summary>
        /// Flag that can have one of the following values:LVGS_NORMALGroups are expanded, the group name is displayed, and all items in the group are displayed.
        /// </summary>
        public GroupStates state;

        /// <summary>
        /// Indicates the alignment of the header or footer text for the group. It can have one or more of the following values. Use one of the header flags. Footer flags are optional. Windows XP: Footer flags are reserved.LVGA_FOOTER_CENTERReserved.
        /// </summary>
        public GroupAlignments uAlign;

        /// <summary>
        /// Windows Vista. Pointer to a null-terminated string that contains the subtitle text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the subtitle text. This element is drawn under the header text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszSubtitle;

        /// <summary>
        /// Windows Vista. Size, in TCHARs, of the buffer pointed to by the pszSubtitle member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public uint cchSubtitle;

        /// <summary>
        /// Windows Vista. Pointer to a null-terminated string that contains the text for a task link when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the task text. This item is drawn right-aligned opposite the header text. When clicked by the user, the task link generates an LVN_LINKCLICK notification.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszTask;

        /// <summary>
        /// Windows Vista. Size in TCHARs of the buffer pointed to by the pszTask member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public uint cchTask;

        /// <summary>
        /// Windows Vista. Pointer to a null-terminated string that contains the top description text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the top description text. This item is drawn opposite the title image when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszDescriptionTop;

        /// <summary>
        /// Windows Vista. Size in TCHARs of the buffer pointed to by the pszDescriptionTop member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public uint cchDescriptionTop;

        /// <summary>
        /// Windows Vista. Pointer to a null-terminated string that contains the bottom description text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the bottom description text. This item is drawn under the top description text when there is a title image, no extended image, and uAlign==LVGA_HEADER_CENTER.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszDescriptionBottom;

        /// <summary>
        /// Windows Vista. Size in TCHARs of the buffer pointed to by the pszDescriptionBottom member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public uint cchDescriptionBottom;

        /// <summary>
        /// Windows Vista. Index of the title image in the control imagelist.
        /// </summary>
        public int iTitleImage;

        /// <summary>
        /// Windows Vista. Index of the extended image in the control imagelist.
        /// </summary>
        public int iExtendedImage;

        /// <summary>
        /// Windows Vista. Read-only.
        /// </summary>
        public int iFirstItem;

        /// <summary>
        /// Windows Vista. Read-only in non-owner data mode.
        /// </summary>
        public uint cItems;

        /// <summary>
        /// Windows Vista. NULL if group is not a subset. Pointer to a null-terminated string that contains the subset title text when item information is being set. If group information is being retrieved, this member specifies the address of the buffer that receives the subset title text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszSubsetTitle;

        /// <summary>
        /// Windows Vista. Size in TCHARs of the buffer pointed to by the pszSubsetTitle member. If the structure is not receiving information about a group, this member is ignored.
        /// </summary>
        public uint cchSubsetTitle;
    }
}
#endif