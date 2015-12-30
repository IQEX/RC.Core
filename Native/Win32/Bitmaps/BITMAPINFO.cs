#if WIN32
namespace RC.Framework.Native.Win32.Bitmaps
{
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Defines the dimensions and color information for a DIB.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct BITMAPINFO
    {
        /// <summary>
        /// Structure that contains information about the dimensions of color format.
        /// </summary>
        public BITMAPINFOHEADER bmiHeader;
        /// <summary>
        /// This contains one of the following:
        /// 1. An array of RGBQUAD. The elements of the array that make up the color table.
        /// 2. An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of bmiColors is allowed for functions that use DIBs.
        /// The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.
        /// </summary>
        public IntPtr bmiColors;

    };
}
#endif