#if WIN32
namespace RC.Framework.Native.Win32.ImageLists
{
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about an image list draw operation and is used with the IImageList::Draw function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct IMAGELISTDRAWPARAMS
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public int cbSize;
        /// <summary>
        /// A handle to the image list that contains the image to be drawn.
        /// </summary>
        public IntPtr himl;
        /// <summary>
        /// The zero-based index of the image to be drawn.
        /// </summary>
        public int i;
        /// <summary>
        /// A handle to the destination device context.
        /// </summary>
        public IntPtr hdcDst;
        /// <summary>
        /// The x-coordinate that specifies where the image is drawn.
        /// </summary>
        public int x;
        /// <summary>
        /// The y-coordinate that specifies where the image is drawn.
        /// </summary>
        public int y;
        /// <summary>
        /// A value that specifies the number of pixels to draw, relative to the upper-left corner of the drawing operation as specified by xBitmap and yBitmap. If cx and cy are zero, then Draw draws the entire valid section. The method does not ensure that the parameters are valid.
        /// </summary>
        public int cx;
        /// <summary>
        /// A value that specifies the number of pixels to draw, relative to the upper-left corner of the drawing operation as specified by xBitmap and yBitmap. If cx and cy are zero, then Draw draws the entire valid section. The method does not ensure that the parameters are valid.
        /// </summary>
        public int cy;
        /// <summary>
        /// The x-coordinate that specifies the upper-left corner of the drawing operation in reference to the image itself. Pixels of the image that are to the left of xBitmap and above yBitmap do not appear.
        /// </summary>
        public int xBitmap;        // x offest from the upperleft of bitmap
        /// <summary>
        /// The y-coordinate that specifies the upper-left corner of the drawing operation in reference to the image itself. Pixels of the image that are to the left of xBitmap and above yBitmap do not appear.
        /// </summary>
        public int yBitmap;        // y offset from the upperleft of bitmap
        /// <summary>
        /// The image background color. This parameter can also be an application-defined RGB value.
        /// </summary>
        public COLORREF rgbBk;
        /// <summary>
        /// The image foreground color. This member is used only if fStyle includes the ILD_BLEND25 or ILD_BLEND50 flag.
        /// </summary>
        public COLORREF rgbFg;
        /// <summary>
        /// A flag specifying the drawing style and, optionally, the overlay image.
        /// </summary>
        public int fStyle;
        /// <summary>
        /// A value specifying a raster operation code. These codes define how the color data for the source rectangle will be combined with the color data for the destination rectangle to achieve the final color. This member is ignored if	fStyle does not include the ILD_ROP flag.
        /// </summary>
        public int dwRop;
        /// <summary>
        /// A flag that specifies the drawing state. 
        /// </summary>
        public int fState;
        /// <summary>
        /// Used with the alpha blending effect.
        /// </summary>
        public int Frame;
        /// <summary>
        /// A color used for the glow and shadow effects. 
        /// </summary>
        public int crEffect;
    }
}
#endif