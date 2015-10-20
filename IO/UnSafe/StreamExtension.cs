// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Framework.IO.UnSafe
{
    /// <summary>
    /// Extension to Stream
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// Read a structure in stream
        /// </summary>
        /// <typeparam name="T">structure</typeparam>
        /// <param name="s"></param>
        /// <returns>structure</returns>
        public unsafe static T Read<T>(this System.IO.Stream s) where T : struct
        {
            int n = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
            var buf = new byte[n];
            s.Read(buf, 0, n);
            fixed (byte* pbuf = &buf[0])
                return (T)System.Runtime.InteropServices.Marshal.PtrToStructure((System.IntPtr)pbuf, typeof(T));
        }
    }
}
