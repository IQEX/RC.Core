#if WIN32
namespace RC.Framework.Native.Win32.Bitmaps
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Specifies the width and height of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width. The units depend on which function uses this.
        /// </summary>
        public int cx;
        /// <summary>
        /// Specifies the rectangle's height. The units depend on which function uses this.
        /// </summary>
        public int cy;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Width = {0}, Height = {1}.", cx, cy);
        }

        #region implicits

        /// <summary>
        /// Converts to <see cref="SIZE" />.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator SIZE(System.Windows.Size size)
        {
            return new SIZE { cx = (int)size.Width, cy = (int)size.Height };
        }

        /// <summary>
        /// Converts to <see cref="System.Windows.Size" />.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator System.Windows.Size(SIZE size)
        {
            return new System.Windows.Size(size.cx, size.cy);
        }

        /// <summary>
        /// Converts to <see cref="SIZE" />.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator SIZE(System.Drawing.Size size)
        {
            return new SIZE { cx = size.Width, cy = size.Height };
        }

        /// <summary>
        /// Converts to <see cref="System.Drawing.Size" />.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator System.Drawing.Size(SIZE size)
        {
            return new System.Drawing.Size(size.cx, size.cy);
        }

        #endregion
    }
}
#endif