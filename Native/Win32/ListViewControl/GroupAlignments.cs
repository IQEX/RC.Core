#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    [Flags]
    public enum GroupAlignments : uint
    {
        /// <summary>
        /// Header text is aligned at the left of the window.
        /// </summary>
        LVGA_HEADER_LEFT = 0x00000001,
        /// <summary>
        /// Header text is centered horizontally in the window.
        /// </summary>
        LVGA_HEADER_CENTER = 0x00000002,
        /// <summary>
        /// Header text is aligned at the right of the window.
        /// </summary>
        LVGA_HEADER_RIGHT = 0x00000004, // Don't forget to validate exclusivity
        /// <summary>
        /// Footer text is aligned at the left of the window.
        /// </summary>
        LVGA_FOOTER_LEFT = 0x00000008,
        /// <summary>
        /// Footer text is centered horizontally in the window.
        /// </summary>
        LVGA_FOOTER_CENTER = 0x00000010,
        /// <summary>
        /// Footer text is aligned at the right of the window.
        /// </summary>
        LVGA_FOOTER_RIGHT = 0x00000020, // Don't forget to validate exclusivity

    }
}
#endif