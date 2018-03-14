// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using RC.Framework.Yaml.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
namespace RC.Framework.Collections.Generic
{
    /// <summary>
    /// Delegate for Compare method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public delegate int GateCompare<in T>(T left, T right);
    /// <summary>
    ///  Represents a strongly typed list of objects that can be accessed by index. Provides
    ///  methods to search, sort, and manipulate lists.To browse the .NET Framework source
    ///  code for this type, see the Reference Source.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    [Serializable] [Yaml(CompactMethod.Content)]
    public class RList<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IRList<T>
    {
        #region Internal
        internal T[] buffer;
        internal int size = 0;
        internal bool IsReadOnly;
        #endregion
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="i"> The zero-based index of the element to get or set.</param>
        /// <returns> The element at the specified index.</returns>
        public T this[int i]
        {
            get { return buffer[i]; }
            set { buffer[i] = value; }
        }
        /// <summary>
        /// Gets the number of elements contained
        /// </summary>
        public int Count => size;

        /// <summary>
        ///     Returns an enumerator that iterates through the <see cref="RList{T}"/>
        /// </summary>
        /// <returns>
        ///     A <see cref="RList{T}"/>.Enumerator for the <see cref="RList{T}"/>
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (buffer != null)
            {
                for (int i = 0; i < size; ++i)
                {
                    yield return buffer[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (buffer != null)
            {
                for (int i = 0; i < size; ++i)
                {
                    yield return buffer[i];
                }
            }
        } 
        internal void AllocateMore()
        {
            int max = buffer?.Length << 1 ?? 0;
            if (max < 32) max = 32;
            T[] newList = new T[max];
            if (buffer != null && size > 0) buffer.CopyTo(newList, index: 0);
            buffer = newList;
        }
        /// <summary>
        /// Trimming <see cref="RList{T}"/>.
        /// </summary>
        public void Trim()
        {
            if (size > 0)
            {
                if (size < buffer.Length)
                {
                    T[] newList = new T[size];
                    for (int i = 0; i < size; ++i) newList[i] = buffer[i];
                    buffer = newList;
                }
            }
            else buffer = new T[0];
        }
        /// <summary>
        /// Clear size <see cref="RList{T}"/>.
        /// </summary>
        public void Clear()
        {
            size = 0;
        }
        /// <summary>
        /// Relese of the <see cref="RList{T}"/>.
        /// </summary>
        public void Release()
        {
            size = 0;
            buffer = null;
        }
        /// <summary>
        /// Adds an object
        /// </summary>
        /// <param name="item"> 
        /// The object to be added to the end of the <see cref="RList{T}"/>. The
        /// value can be null for reference types.
        /// </param>
        public void Add(T item)
        {
            if (buffer == null || size == buffer.Length)
                AllocateMore();
            if (buffer != null) buffer[size++] = item;
        }
        /// <summary>
        /// Adds an object
        /// </summary>
        /// <param name="item">
        /// The object to be added to the end of the <see cref="RList{T}"/>. The
        /// value can be null for reference types.
        /// </param>
        public void Add(object item)
        {
            if (buffer == null || size == buffer.Length)
                AllocateMore();
            if (buffer != null) buffer[size++] = (T)item;
        }
        /// <summary>
        ///  Inserts an element into the <see cref="RList{T}"/> at the specified
        ///  index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        public void Insert(int index, T item)
        {
            if (buffer == null || size == buffer.Length)
                AllocateMore();
            if (index > -1 && index < size)
            {
                for (int i = size; i > index; --i) if (buffer != null) buffer[i] = buffer[i - 1];
                if (buffer != null) buffer[index] = item;
                ++size;
            }
            else Add(item);
        }
        /// <summary>
        /// Determines whether an element is in the <see cref="RList{T}"/>.
        /// </summary>
        /// <param name="item">
        ///  The object to locate in the <see cref="RList{T}"/>. The value can
        ///  be null for reference types.
        /// </param>
        /// <returns>true if item is found in the <see cref="RList{T}"/>; otherwise, false.</returns>
        public bool Contains(T item)
        {
            if (buffer == null) return false;
            for (int i = 0; i < size; ++i) if (buffer[i].Equals(item)) return true;
            return false;
        }
        /// <summary>
        ///     Searches for the specified object and returns the zero-based index of the first
        ///     occurrence within the entire <see cref="RList{T}"/>.
        /// </summary>
        /// <param name="item">
        ///     The object to locate in the <see cref="RList{T}"/>. The value can
        ///     be null for reference types.
        /// </param>
        /// <returns>
        ///     The zero-based index of the first occurrence of item within the entire <see cref="RList{T}"/>,
        ///     if found; otherwise, –1.
        /// </returns>
        public int IndexOf(T item)
        {
            if (buffer == null) return -1;
            for (int i = 0; i < size; ++i) if (buffer[i].Equals(item)) return i;
            return -1;
        }
        /// <summary>
        ///     Removes the first occurrence of a specific object from the <see cref="RList{T}"/>.
        /// </summary>
        /// <param name="item">
        ///     The object to remove from the <see cref="RList{T}"/> The value can
        ///     be null for reference types.
        /// </param>
        /// <returns>
        ///     true if item is successfully removed; otherwise, false. This method also returns
        ///     false if item was not found in the <see cref="RList{T}"/>
        /// </returns>
        public bool Remove(T item)
        {
            if (buffer != null)
            {
                EqualityComparer<T> comp = EqualityComparer<T>.Default;
                for (int i = 0; i < size; ++i)
                {
                    if (comp.Equals(buffer[i], item))
                    {
                        --size;
                        buffer[i] = default(T);
                        for (int b = i; b < size; ++b) buffer[b] = buffer[b + 1];
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        ///     Removes the element at the specified index of the <see cref="RList{T}"/>
        /// </summary>
        /// <param name="index">
        ///     The zero-based index of the element to remove.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.-or-index is equal to or greater than <see cref="RList{T}"/>.
        /// </exception>
        public void RemoveAt(int index)
        {
            if (buffer == null && index < -1 && index < size)
                throw new ArgumentOutOfRangeException("index");
            --size;
            if (buffer != null)
            {
                buffer[index] = default(T);
                for (int b = index; b < size; ++b) buffer[b] = buffer[b + 1];
            }
        }
        /// <summary>
        /// Pop <see cref="RList{T}"/>.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (buffer != null && size != 0)
            {
                T val = buffer[--size];
                buffer[size] = default(T);
                return val;
            }
            return default(T);
        }
        /// <summary>
        ///     Copies the elements of the <see cref="RList{T}"/> to a new array.
        /// </summary>
        /// <returns>
        ///     An array containing copies of the elements of the <see cref="RList{T}"/>
        /// </returns>
        public T[] ToArray()
        {
            Trim();
            return buffer;
        }
        /// <summary>
        /// Sorts the elements
        /// </summary>
        /// <param name="comparer">comparing elements</param>
        public void Sort(GateCompare<T> comparer)
        {
            int start = 0;
            int max = size - 1;
            bool changed = true;

            while (changed)
            {
                changed = false;

                for (int i = start; i < max; ++i)
                {
                    if (comparer(buffer[i], buffer[i + 1]) > 0)
                    {
                        T temp = buffer[i];
                        buffer[i] = buffer[i + 1];
                        buffer[i + 1] = temp;
                        changed = true;
                    }
                    else if (!changed)
                    {
                        start = (i == 0) ? 0 : i - 1;
                    }
                }
            }
        }
        /// <summary>
        ///     Copies the entire <see cref="RList{T}"/> to a compatible one-dimensional
        ///     array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">
        ///      The one-dimensional System.Array that is the destination of the elements copied
        ///      from <see cref="RList{T}"/>. The System.Array must have zero-based
        ///      indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException"> array is null.</exception>
        /// <exception cref="ArgumentException">
        ///      The number of elements in the source <see cref="RList{T}"/> is greater
        ///      than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"> arrayIndex is less than 0.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex == 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length < arrayIndex)
                throw new ArgumentException("array.Length < arrayIndex");
            Array.Copy(this.buffer, sourceIndex: 0, destinationArray: array, destinationIndex: arrayIndex, length: this.size);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="netList"></param>
        public static explicit operator RList<T>(List<T> netList)
        {
            RList<T> wariator = new RList<T>();
            foreach(T i in netList)
            {
                wariator.Add(i);
            }
            return wariator;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rList"></param>
        public static explicit operator List<T>(RList<T> rList)
        {
            return new List<T>(rList);
        }
    }
}