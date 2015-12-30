#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Mask flags for listview group.
    /// </summary>
    [Flags]
    public enum GroupFlags : uint
    {
        /// <summary>
        /// No other items are valid.
        /// </summary>
        LVGF_NONE = 0x00000,
        /// <summary>
        /// pszHeader and cchHeader members are valid.
        /// </summary>
        LVGF_HEADER = 0x00001,
        /// <summary>
        /// pszFooter and cchFooter members are valid.
        /// </summary>
        LVGF_FOOTER = 0x00002,
        /// <summary>
        /// state and stateMask members are valid.
        /// </summary>
        LVGF_STATE = 0x00004,
        /// <summary>
        /// uAlign member is valid.
        /// </summary>
        LVGF_ALIGN = 0x00008,
        /// <summary>
        /// iGroupId member is valid.
        /// </summary>
        LVGF_GROUPID = 0x00010,
        /// <summary>
        /// Version 6.00 and Windows Vista. The pszSubtitle member is valid.
        /// </summary>
        LVGF_SUBTITLE = 0x00100,
        /// <summary>
        /// Version 6.00 and Windows Vista. The pszTask member is valid.
        /// </summary>
        LVGF_TASK = 0x00200,
        /// <summary>
        /// Version 6.00 and Windows Vista. The pszDescriptionTop member is valid.
        /// </summary>
        LVGF_DESCRIPTIONTOP = 0x00400,
        /// <summary>
        /// Version 6.00 and Windows Vista. The pszDescriptionBottom member is valid.
        /// </summary>
        LVGF_DESCRIPTIONBOTTOM = 0x00800,
        /// <summary>
        /// Version 6.00 and Windows Vista. The iTitleImage member is valid.
        /// </summary>
        LVGF_TITLEIMAGE = 0x01000,
        /// <summary>
        /// Version 6.00 and Windows Vista. The iExtendedImage member is valid.
        /// </summary>
        LVGF_EXTENDEDIMAGE = 0x02000,
        /// <summary>
        /// Version 6.00 and Windows Vista. The cItems member is valid.
        /// </summary>
        LVGF_ITEMS = 0x04000,
        /// <summary>
        /// Version 6.00 and Windows Vista. The pszSubsetTitle member is valid.
        /// </summary>
        LVGF_SUBSET = 0x08000,
        /// <summary>
        /// Version 6.00 and Windows Vista. The cchSubsetTitle member is valid.
        /// </summary>
        LVGF_SUBSETITEMS = 0x10000
    }
}
#endif