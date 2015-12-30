#if WIN32
namespace RC.Framework.Native.Win32.ImageLists
{
    using Rectangles;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Contains information about an image in an image list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct IMAGEINFO
    {
        /// <summary>
        /// A handle to the bitmap that contains the images.
        /// </summary>
        public IntPtr hbmImage;
        /// <summary>
        /// A handle to a monochrome bitmap that contains the masks for the images. If the image list does not contain a mask, this member is NULL.
        /// </summary>
        public IntPtr hbmMask;
        /// <summary>
        /// Not used. This member should always be zero.
        /// </summary>
        public int Unused1;
        /// <summary>
        /// Not used. This member should always be zero.
        /// </summary>
        public int Unused2;
        /// <summary>
        /// The bounding rectangle of the specified image within the bitmap specified by hbmImage.
        /// </summary>
        public RECT rcImage;
    }
}
#endif