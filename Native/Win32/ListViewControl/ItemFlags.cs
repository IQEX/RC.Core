#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Flags for the mask.
    /// </summary>
    [Flags]
    public enum ItemFlags : uint
    {
        /// <summary>
        /// The pszText member is valid or must be set.
        /// </summary>
        LVIF_TEXT = 0x0001,
        /// <summary>
        /// The iImage member is valid or must be set.
        /// </summary>
        LVIF_IMAGE = 0x0002,
        /// <summary>
        /// The lParam member is valid or must be set.
        /// </summary>
        LVIF_PARAM = 0x00000004,
        /// <summary>
        /// The state member is valid or must be set.
        /// </summary>
        LVIF_STATE = 0x00000008,
        /// <summary>
        /// The iIndent member is valid or must be set.
        /// </summary>
        LVIF_INDENT = 0x00000010,
        /// <summary>
        /// The control will not generate LVN_GETDISPINFO to retrieve text information if it receives an LVM_GETITEM message. Instead, the pszText member will contain LPSTR_TEXTCALLBACK.
        /// </summary>
        LVIF_NORECOMPUTE = 0x00000800,
        /// <summary>
        /// Windows XP and later. The iGroupId member is valid or must be set. If this flag is not set when an LVM_INSERTITEM message is sent, the value of iGroupId is assumed to be I_GROUPIDCALLBACK.
        /// </summary>
        LVIF_GROUPID = 0x00000100,
        /// <summary>
        /// Windows XP and later.The cColumns member is valid or must be set.
        /// </summary>
        LVIF_COLUMNS = 0x00000200,
    }
}
#endif