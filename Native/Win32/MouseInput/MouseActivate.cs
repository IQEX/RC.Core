#if WIN32
namespace RC.Framework.Native.Win32.MouseInput
{
    /// <summary>
    /// Return values for WM_MOUSEACTIVATE message.
    /// </summary>
    public enum MouseActivate
    {
        /// <summary>
        /// Activates the window, and does not discard the mouse message.
        /// </summary>
        MA_ACTIVATE = 1,
        /// <summary>
        /// Activates the window, and discards the mouse message.
        /// </summary>
        MA_ACTIVATEANDEAT = 2,
        /// <summary>
        /// Does not activate the window, and does not discard the mouse message.
        /// </summary>
        MA_NOACTIVATE = 3,
        /// <summary>
        /// Does not activate the window, but discards the mouse message.
        /// </summary>
        MA_NOACTIVATEANDEAT = 4
    }
}
#endif