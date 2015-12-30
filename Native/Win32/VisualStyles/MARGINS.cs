#if WIN32
namespace RC.Framework.Native.Win32.VisualStyles
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Defines the margins of windows that have visual styles applied.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
	public struct MARGINS
    {
        /// <summary>
        /// Gets a value indicating whether this struct is supported on current platform.
        /// </summary>
        /// <value>
        /// <c>true</c> if this struct is supported; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSupported { get { return PlatformInfo.IsWinXPUp; } }

		/// <summary>
		/// Width of the left border that retains its size.
		/// </summary>
		public int cxLeftWidth;
		/// <summary>
		/// Width of the right border that retains its size.
		/// </summary>
		public int cxRightWidth;
		/// <summary>
		/// Height of the top border that retains its size.
		/// </summary>
		public int cyTopHeight;
		/// <summary>
		/// Height of the bottom border that retains its size.
		/// </summary>
		public int cyBottomHeight;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Left = {0}, Top = {1}, Right = {2}, Bottom = {3}.", cxLeftWidth, cyTopHeight, cxRightWidth, cyBottomHeight);
        }
	}
}
#endif