#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Indicates the valid field flags.
    /// </summary>
    [Flags]
    public enum ColumnFlags : uint
    {
        /// <summary>
        /// The fmt member is valid.
        /// </summary>
        LVCF_FMT = 0x0001,
        /// <summary>
        /// The cx member is valid.
        /// </summary>
        LVCF_WIDTH = 0x0002,
        /// <summary>
        /// The pszText member is valid.
        /// </summary>
        LVCF_TEXT = 0x0004,
        /// <summary>
        /// The iSubItem member is valid.
        /// </summary>
        LVCF_SUBITEM = 0x0008,
        /// <summary>
        /// The iImage member is valid.
        /// </summary>
        LVCF_IMAGE = 0x0010,
        /// <summary>
        /// The iOrder member is valid.
        /// </summary>
        LVCF_ORDER = 0x0020,
    }

}
#endif