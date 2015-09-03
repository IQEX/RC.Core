// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Native\\SystemTools.cs"//                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.3"                   //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Native
{
    /// <summary>
	/// Set of systems tools.
	/// </summary>
	///
	/// <remarks><para>The class is a container of different system tools, which are used
	/// across the framework. Some of these tools are platform specific, so their
	/// implementation is different on different platform, like .NET and Mono.</para>
	/// </remarks>
	public static class SystemTools
    {
        /// <summary>
        /// Copy block of unmanaged memory.
        /// </summary>
        ///
        /// <param name="dst">Destination pointer.</param>
        /// <param name="src">Source pointer.</param>
        /// <param name="count">Memory block's length to copy.</param>
        ///
        /// <returns>Return's value of <paramref name="dst" /> - pointer to destination.</returns>
        ///
        /// <remarks><para>This function is required because of the fact that .NET does
        /// not provide any way to copy unmanaged blocks, but provides only methods to
        /// copy from unmanaged memory to managed memory and vise versa.</para></remarks>
        public unsafe static IntPtr CopyUnmanagedMemory(IntPtr dst, IntPtr src, int count)
        {
            SystemTools.CopyUnmanagedMemory((byte*)dst.ToPointer(), (byte*)src.ToPointer(), count);
            return dst;
        }
        /// <summary>
        /// Copy block of unmanaged memory.
        /// </summary>
        ///
        /// <param name="dst">Destination pointer.</param>
        /// <param name="src">Source pointer.</param>
        /// <param name="count">Memory block's length to copy.</param>
        ///
        /// <returns>Return's value of <paramref name="dst" /> - pointer to destination.</returns>
        ///
        /// <remarks><para>This function is required because of the fact that .NET does
        /// not provide any way to copy unmanaged blocks, but provides only methods to
        /// copy from unmanaged memory to managed memory and vise versa.</para></remarks>
        public unsafe static byte* CopyUnmanagedMemory(byte* dst, byte* src, int count)
        {
            return NativeMethods.memcpy(dst, src, count);
        }
        /// <summary>
        /// Fill memory region with specified value.
        /// </summary>
        ///
        /// <param name="dst">Destination pointer.</param>
        /// <param name="filler">Filler byte's value.</param>
        /// <param name="count">Memory block's length to fill.</param>
        ///
        /// <returns>Return's value of <paramref name="dst" /> - pointer to destination.</returns>
        public unsafe static IntPtr SetUnmanagedMemory(IntPtr dst, int filler, int count)
        {
            SystemTools.SetUnmanagedMemory((byte*)dst.ToPointer(), filler, count);
            return dst;
        }
        /// <summary>
        /// Fill memory region with specified value.
        /// </summary>
        ///
        /// <param name="dst">Destination pointer.</param>
        /// <param name="filler">Filler byte's value.</param>
        /// <param name="count">Memory block's length to fill.</param>
        ///
        /// <returns>Return's value of <paramref name="dst" /> - pointer to destination.</returns>
        public unsafe static byte* SetUnmanagedMemory(byte* dst, int filler, int count)
        {
            return NativeMethods.memset(dst, filler, count);
        }
    }
}
