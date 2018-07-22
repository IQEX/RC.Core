// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.IO;

namespace RC.Framework.Collections
{
    /// <summary>
	/// A call which make repetitive (variable) buffer operation easier on memory
	/// by sharing a common buffer of the smallest size enough for all operation.
	/// It also some handy method to read write class / strut (which have been
	/// appropriately tagged for interop) from and to a Stream.
	/// </summary>
	/// <remarks>It runs some specially optimized code with native stream.</remarks>
    public interface IRBuffer
    {
        /// <summary>
        /// Current <see cref="IRBuffer"/> Length
        /// </summary>
        int CurrentLength { get; }
        /// <summary>
        /// Copy a portion of a stream unto another.
        /// Special code is used for unmanaged stream.
        /// </summary>
        void CopyMemory(Stream dst, Stream src, int len);
        /// <summary>
        /// Copy a portion of a stream unto another.
        /// Special code is used for unmanaged stream.
        /// </summary>
        void CopyMemory(Stream dst, Stream src, int len, int buffsize);
        /// <summary>
        /// Return a common shared buffer, to ease memory allocation
        /// </summary>
        byte[] GetBuffer(int len);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="str">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="ArgumentException">
        /// 
        /// </exception>
        T Read<T>(Stream str) where T : struct;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="str">
        /// 
        /// </param>
        /// <param name="count">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 
        /// </exception>
        T[] Read<T>(Stream str, int count) where T : struct;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="str">
        /// 
        /// </param>
        /// <param name="values">
        /// 
        /// </param>
        /// <param name="offset">
        /// 
        /// </param>
        /// <param name="count">
        /// 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 
        /// </exception>
        void Read<T>(Stream str, T[] values, int offset, int count) where T : struct;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="str">
        /// 
        /// </param>
        /// <param name="values">
        /// 
        /// </param>
        /// <exception cref="ArgumentException">
        /// 
        /// </exception>
        void Write<T>(Stream str, params T[] values) where T : struct;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="str">
        /// 
        /// </param>
        /// <param name="values">
        /// 
        /// </param>
        /// <param name="offset">
        /// 
        /// </param>
        /// <param name="count">
        /// 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 
        /// </exception>
        void Write<T>(Stream str, T[] values, int offset, int count) where T : struct;
    }
}