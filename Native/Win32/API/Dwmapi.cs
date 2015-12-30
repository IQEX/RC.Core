#if WIN32
namespace RC.Framework.Native.Win32.API
{
    using VisualStyles;
    using System;
    using System.Runtime.InteropServices;
    /// <summary>
    /// API methods in dwmapi.dll.
    /// </summary>
    public static class Dwmapi
    {
        #region real hook

        class NativeMethods
        {
            [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DwmDefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref IntPtr plResult);

            [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
            public static extern void DwmIsCompositionEnabled([MarshalAs(UnmanagedType.Bool)]ref bool isEnabled);

            [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
            public static extern HRESULT DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

            [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
            public static extern HRESULT DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute,
                ref int attribute, uint cbAttribute);
        }
        #endregion

        #region public methods


        /// <summary>
        /// Gets whether this api is supported.
        /// </summary>
        public static bool IsPlatformSupported { get { return PlatformInfo.IsWinVistaUp; } }

        /// <summary>
        /// Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled. Applications can listen for composition state changes by handling the WM_DWMCOMPOSITIONCHANGED notification.
        /// </summary>
        public static bool IsCompositionEnabled
        {
            get
            {
                bool val = false;
                if (IsPlatformSupported)
                {
                    NativeMethods.DwmIsCompositionEnabled(ref val);
                }
                return val;
            }
        }

        /// <summary>
        /// Extends the window frame into the client area.
        /// </summary>
        /// <param name="hWnd">The handle to the window in which the frame will be extended into the client area.</param>
        /// <param name="left">The left margin.</param>
        /// <param name="top">The top margin.</param>
        /// <param name="right">The right margin.</param>
        /// <param name="bottom">The bottom margin.</param>
        /// <returns></returns>
        public static bool ExtendFrameIntoClientArea(IntPtr hWnd, int left, int top, int right, int bottom)
        {
            if (IsPlatformSupported)
            {
                MARGINS m = new MARGINS();
                m.cxLeftWidth = left;
                m.cyTopHeight = top;
                m.cxRightWidth = right;
                m.cyBottomHeight = bottom;
                return NativeMethods.DwmExtendFrameIntoClientArea(hWnd, ref m).Succeeded;
            }
            return false;
        }

        /// <summary>
        /// Sets the value of non-client rendering attributes for a window.
        /// </summary>
        /// <param name="hwnd">The handle to the window that will receive the attributes.</param>
        /// <param name="attribute">A single DWMWINDOWATTRIBUTE flag to apply to the window. This parameter specifies the attribute and the pvAttribute parameter points to the value of that attribute.</param>
        /// <param name="attributeValue">The value of the attribute specified in the attribute parameter. Different DWMWINDOWATTRIBUTE flags require different value types.</param>
        /// <param name="attributeSize">The size, in bytes, of the value type pointed to by the pvAttribute parameter.</param>
        /// <returns></returns>
        public static bool SetWindowAttribute(IntPtr hwnd, DwmWindowAttribute attribute, int attributeValue, uint attributeSize)
        {
            if (IsPlatformSupported)
            {
                return NativeMethods.DwmSetWindowAttribute(hwnd, attribute, ref attributeValue, attributeSize).Succeeded;
            }
            return false;
        }

        /// <summary>
        /// Default window procedure for Desktop Window Manager (DWM) hit testing within the non-client area.
        /// </summary>
        /// <param name="hwnd">A handle to the window procedure that received the message.</param>
        /// <param name="msg">The message.</param>
        /// <param name="wParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
        /// <param name="lParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
        /// <param name="result">A pointer to an LRESULT value that, when this method returns successfully,receives the result of the hit test.</param>
        /// <returns></returns>
        public static bool DefWndProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref IntPtr result)
        {
            if (IsPlatformSupported)
            {
                return NativeMethods.DwmDefWindowProc(hwnd, msg, wParam, lParam, ref result);
            }
            return false;
        }

        #endregion
    }
}
#endif