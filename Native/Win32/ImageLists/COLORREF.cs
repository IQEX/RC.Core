#if WIN32
namespace RC.Framework.Native.Win32.ImageLists
{
    enum COLORREF : uint
    {
        /// <summary>
        /// The default background color.
        /// </summary>
        CLR_DEFAULT = 0xFF000000,
        /// <summary>
        /// No background color.
        /// </summary>
        CLR_NONE = 0xFFFFFFFF
    }
}
#endif