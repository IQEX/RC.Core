#if WIN32
namespace RC.Framework.Native.Win32.ListViewControl
{
    using System;
    /// <summary>
    /// Indicates the column format.
    /// </summary>
    [Flags]
    public enum ColumnFormats
    {
        /// <summary>
        /// Text is left-aligned.
        /// </summary>
        LVCFMT_LEFT = 0x0000, // Same as HDF_LEFT
        /// <summary>
        /// Text is right-aligned.
        /// </summary>
        LVCFMT_RIGHT = 0x0001, // Same as HDF_RIGHT
        /// <summary>
        /// Text is centered.
        /// </summary>
        LVCFMT_CENTER = 0x0002,// Same as HDF_CENTER
        /// <summary>
        /// A bitmask used to select those bits of fmt that control field justification. To check the format of a column, use a logical "and" to combine LCFMT_JUSTIFYMASK with fmt. You can then use a switch statement to determine whether the LVCFMT_LEFT, LVCFMT_RIGHT, or LVCFMT_CENTER bits are set.
        /// </summary>
        LVCFMT_JUSTIFYMASK = 0x0003,// Same as HDF_JUSTIFYMASK

        /// <summary>
        /// The item displays an image from an image list.
        /// </summary>
        LVCFMT_IMAGE = 0x0800, // Same as HDF_IMAGE
        /// <summary>
        /// The bitmap appears to the right of text. This does not affect an image from an image list assigned to the header item.
        /// </summary>
        LVCFMT_BITMAP_ON_RIGHT = 0x1000, // Same as HDF_BITMAP_ON_RIGHT
        /// <summary>
        /// The header item contains an image in the image list.
        /// </summary>
        LVCFMT_COL_HAS_IMAGES = 0x8000,// Same as HDF_OWNERDRAW

        /// <summary>
        /// Show sort ascending indicator in header.
        /// </summary>
        HDF_SORTUP = 0x0400,
        /// <summary>
        /// Show sort descending indicator in header.
        /// </summary>
        HDF_SORTDOWN = 0x0200,


        /// <summary>
        /// Forces the column to wrap to the top of the next list of columns.
        /// </summary>
        LVCFMT_LINE_BREAK = 0x100000,
        /// <summary>
        /// Fills the remainder of the tile area. Might have a title.
        /// </summary>
        LVCFMT_FILL = 0x200000,
        /// <summary>
        /// Allows the column to wrap within the remaining space in its list of columns.
        /// </summary>
        LVCFMT_WRAP = 0x400000,
        /// <summary>
        /// Removes the title from the subitem.
        /// </summary>
        LVCFMT_NO_TITLE = 0x800000,
        /// <summary>
        /// Equivalent to a combination of LVCFMT_LINE_BREAK and LVCFMT_FILL.
        /// </summary>
        LVCFMT_TILE_PLACEMENTMASK = (LVCFMT_LINE_BREAK | LVCFMT_FILL)

    }
}
#endif