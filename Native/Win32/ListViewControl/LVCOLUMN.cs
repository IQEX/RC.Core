#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about a column in report view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVCOLUMN
    {
        /// <summary>
        /// Variable specifying which members contain valid information
        /// </summary>
        public ColumnFlags mask;
        /// <summary>
        /// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always LVCFMT_LEFT; it cannot be changed.
        /// </summary>
        public ColumnFormats fmt;
        /// <summary>
        /// Width of the column, in pixels.
        /// </summary>
        public int cx;

        /// <summary>
        /// String of the column header.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        /// <summary>
        /// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information about a column, this member is ignored.
        /// </summary>
        public int ccTextMax;
        /// <summary>
        /// Index of subitem associated with the column.
        /// </summary>
        public int iSubItem;

        /// <summary>
        /// Zero-based index of an image within the image list. The specified image will appear within the column.
        /// </summary>
        public int iImage;
        /// <summary>
        /// Zero-based column offset. Column offset is in left-to-right order. For example, zero indicates the leftmost column.
        /// </summary>
        public int iOrder;

    }


    /// <summary>
    /// Contains information about a column in report view.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LVCOLUMN_VISTA
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinVistaUp; } }

        /// <summary>
        /// Variable specifying which members contain valid information
        /// </summary>
        public ColumnFlags mask;
        /// <summary>
        /// Alignment of the column header and the subitem text in the column. The alignment of the leftmost column is always LVCFMT_LEFT; it cannot be changed.
        /// </summary>
        public ColumnFormats fmt;
        /// <summary>
        /// Width of the column, in pixels.
        /// </summary>
        public int cx;

        /// <summary>
        /// String of the column header.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        /// <summary>
        /// Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information about a column, this member is ignored.
        /// </summary>
        public int ccTextMax;
        /// <summary>
        /// Index of subitem associated with the column.
        /// </summary>
        public int iSubItem;

        /// <summary>
        /// Zero-based index of an image within the image list. The specified image will appear within the column.
        /// </summary>
        public int iImage;
        /// <summary>
        /// Zero-based column offset. Column offset is in left-to-right order. For example, zero indicates the leftmost column.
        /// </summary>
        public int iOrder;

        /// <summary>
        /// Windows Vista. Minimum width of the column in pixels.
        /// </summary>
        public int cxMin;
        /// <summary>
        /// Windows Vista. Application-defined value typically used to store the default width of the column. This member is ignored by the list-view control.
        /// </summary>
        public int cxDefault;
        /// <summary>
        /// Windows Vista. Read-only. The ideal width of the column in pixels, as the column may currently be autosized to a lesser width.
        /// </summary>
        public int cxIdeal;
    }
}
#endif