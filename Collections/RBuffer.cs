// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
namespace Rc.Framework.Collections
{
    /// <summary>
	/// A call which make repetitive (variable) buffer operation easier on memory
	/// by sharing a common buffer of the smallest size enough for all operation.
	/// It also some handy method to read write class / strut (which have been
	/// appropriately tagged for interop) from and to a Stream.
	/// </summary>
	/// <remarks>It runs some specially optimized code with native stream.</remarks>
	public unsafe class RBuffer : IRBuffer
    {
        //# Описание методов не готово, временно
        //@ "да да, то что временно - то на вечно" :с
        #region GetBuffer(), CurrentLength
        byte[] buffer;
        /// <summary>
        /// Return a common shared buffer, to ease memory allocation
        /// </summary>
        public byte[] GetBuffer(int len)
        {
            if (buffer == null || buffer.Length < len)
                buffer = new byte[len];
            return buffer;
        }
        /// <summary>
        /// Current <see cref="RBuffer"/> Length
        /// </summary>
        public int CurrentLength { get { return buffer != null ? buffer.Length : 0; } }
        #endregion
        #region CopyMemory()
        /// <summary>
        /// Copy a portion of a stream unto another.
        /// Special code is used for unmanaged stream.
        /// </summary>
        public void CopyMemory(Stream dst, Stream src, int len, int buffsize)
        {
            while (len > 0)
            {
                int alen = len > buffsize ? buffsize : len;
                CopyMemory(dst, src, alen);
                len -= alen;
            }
        }
        /// <summary>
        /// Copy a portion of a stream unto another.
        /// Special code is used for unmanaged stream.
        /// </summary>
        public void CopyMemory(Stream dst, Stream src, int len)
        {
            var buf = GetBuffer(len);
            src.Read(buf, 0, len);
            dst.Write(buf, 0, len);
        }
        #endregion
        #region ToBytes<T>(), ToValue()
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="value">
        /// 
        /// </param>
        /// <param name="buf">
        /// 
        /// </param>
        /// <param name="offset">
        /// 
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 
        /// </exception>
        public static void ToBytes<T>(T value, byte[] buf, ref int offset) where T : struct
        {
            int n = Marshal.SizeOf(typeof(T));
            if (offset < 0 || offset + n > buf.Length)
                throw new ArgumentOutOfRangeException("offset");
            fixed (byte* dst = &buf[offset])
                Marshal.StructureToPtr(value, (IntPtr)dst, false);
            offset += n;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">
        /// 
        /// </typeparam>
        /// <param name="buf">
        /// 
        /// </param>
        /// <param name="offset">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="ArgumentException">
        /// 
        /// </exception>
        public static T ToValue<T>(byte[] buf, ref int offset) where T : struct
        {
            int n = Marshal.SizeOf(typeof(T));
            if (offset < 0 || offset + n > buf.Length)
                throw new ArgumentException("offset");
            fixed (byte* pbuf = &buf[offset])
            {
                var result = (T)Marshal.PtrToStructure((IntPtr)pbuf, typeof(T));
                offset += n;
                return result;
            }
        }
        #endregion
        #region Write<T>(), Read<T>()
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
        public void Write<T>(Stream str, params T[] values) where T : struct
        {
            if (values == null)
                throw new ArgumentException("values");
            Write<T>(str, values, 0, values.Length);
        }
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
        public void Write<T>(Stream str, T[] values, int offset, int count) where T : struct
        {
            if (values == null) throw new ArgumentException("values");
            if (count == 0) throw new ArgumentNullException("count");
            if (count < 0 || offset < 0 || offset + count > values.Length)
                throw new ArgumentOutOfRangeException("offset");
            int n = Marshal.SizeOf(typeof(T));
            var buf = GetBuffer(n * count);
            int bufoffset = 0;
            for (int i = 0; i < values.Length; i++)
                ToBytes(values[offset + i], buf, ref bufoffset);
            str.Write(buf, 0, bufoffset);
        }
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
        public T Read<T>(Stream str) where T : struct
        {
            if (str == null)
                throw new ArgumentException("str");
            int n = Marshal.SizeOf(typeof(T));
            var buf = GetBuffer(n);
            str.Read(buf, 0, n);
            int offset = 0;
            return ToValue<T>(buf, ref offset);
        }
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
        public void Read<T>(Stream str, T[] values, int offset, int count) where T : struct
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (values == null)
                throw new ArgumentNullException("values");
            if (count < 0 || offset < 0 || offset + count > values.Length)
                throw new ArgumentOutOfRangeException("offset");
            int n = Marshal.SizeOf(typeof(T));
            var buf = GetBuffer(n * count);
            str.Read(buf, 0, n * count);

            int bufoffset = 0;
            for (int i = 0; i < count; i++)
                values[offset + i] = ToValue<T>(buf, ref bufoffset);
        }
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
        public T[] Read<T>(Stream str, int count) where T : struct
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            var result = new T[count];
            Read<T>(str, result, 0, count);
            return result;
        }
        #endregion
    }
    public struct RBuffer<TElement>
    {
        public TElement[] items;
        public int count;

        public RBuffer(IEnumerable<TElement> source)
        {
            var array = (TElement[])null;
            int length = 0;
            var collection = source as ICollection<TElement>;
            if (collection != null)
            {
                length = collection.Count;
                if (length > 0)
                {
                    array = new TElement[length];
                    collection.CopyTo(array, 0);
                }
            }
            else
            {
                foreach (TElement element in source)
                {
                    if (array == null)
                        array = new TElement[4];
                    else if (array.Length == length)
                    {
                        var elementArray = new TElement[checked(length * 2)];
                        Array.Copy(array, 0, elementArray, 0, length);
                        array = elementArray;
                    }
                    array[length] = element;
                    ++length;
                }
            }
            items = array;
            count = length;
        }
        public TElement[] ToArray()
        {
            if (count == 0)
                return new TElement[0];
            if (items.Length == count)
                return items;
            var elementArray = new TElement[count];
            Array.Copy(items, 0, elementArray, 0, count);
            return elementArray;
        }
    }
}
