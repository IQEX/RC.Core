#if WIN32
namespace RC.Framework.Native.Win32
{
    using System;
    /// <summary>
    /// Contains basic win32 values.
    /// </summary>
    public static class BasicValues
	{
		/// <summary>
		/// Represents the TRUE value as <see cref="IntPtr"/>.
		/// </summary>
		public static readonly IntPtr TRUE = new IntPtr(value: 1);
		/// <summary>
		/// Represents the FALSE value as <see cref="IntPtr"/>.
		/// </summary>
		public static readonly IntPtr FALSE = IntPtr.Zero;

        /// <summary>
        /// The max file path length.
        /// </summary>
        public const int MAX_PATH = 260;
	}
}
#endif