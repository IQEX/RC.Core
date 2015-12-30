#if WIN32
namespace RC.Framework.Native.Win32.Bitmaps
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// This structure controls blending by specifying the blending functions for source and destination bitmaps.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct BLENDFUNCTION
	{
		/// <summary>
		/// Specifies the source blend operation. Currently, the only source and destination blend operation that has been defined is AC_SRC_OVER. For details, see the following Remarks section.
		/// </summary>
		public byte BlendOp;
		/// <summary>
		/// Must be zero.
		/// </summary>
		public byte BlendFlags;
		/// <summary>
		/// Specifies an alpha transparency value to be used on the entire source bitmap. 
		/// The SourceConstantAlpha value is combined with any per-pixel alpha values in the source bitmap. 
		/// If you set SourceConstantAlpha to 0, it is assumed that your image is transparent. When you only want to use per-pixel alpha values, set the SourceConstantAlpha value to 255 (opaque) .
		/// </summary>
		public byte SourceConstantAlpha;
		/// <summary>
		/// This member controls the way the source and destination bitmaps are interpreted.
		/// </summary>
		public Format AlphaFormat;

		/// <summary>
		/// Indicates the blend alpha format.
		/// </summary>
		public enum Format : byte
		{
			/// <summary>
			/// The source bitmap is placed over the destination bitmap based on the alpha values of the source pixels.
			/// </summary>
			AC_SRC_OVER = 0,
            /// <summary>
            /// This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha).
            /// </summary>
			AC_SRC_ALPHA = 1
		}
	}
}
#endif