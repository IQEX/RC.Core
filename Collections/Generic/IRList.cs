// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
namespace RC.Framework.Collections.Generic
{
    /// <summary>
    ///  Represents a strongly typed list of objects that can be accessed by index. Provides
    ///  methods to search, sort, and manipulate lists.To browse the .NET Framework source
    ///  code for this type, see the Reference Source.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface IRList<T>
    {
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="i"> The zero-based index of the element to get or set.</param>
        /// <returns> The element at the specified index.</returns>
        T this[int i] { get; set; }
        /// <summary>
        /// Gets the number of elements contained
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Adds an object
        /// </summary>
        /// <param name="item"> 
        /// The object to be added to the end of the <see cref="RList{T}"/>. The
        /// value can be null for reference types.
        /// </param>
        void Add(T item);
        /// <summary>
        /// Adds an object
        /// </summary>
        /// <param name="item">
        /// The object to be added to the end of the <see cref="RList{T}"/>. The
        /// value can be null for reference types.
        /// </param>
        void Add(object item);
        /// <summary>
        /// Clear size <see cref="RList{T}"/>.
        /// </summary>
        void Clear();
        /// <summary>
        /// Determines whether an element is in the <see cref="RList{T}"/>.
        /// </summary>
        /// <param name="item">
        ///  The object to locate in the <see cref="RList{T}"/>. The value can
        ///  be null for reference types.
        /// </param>
        /// <returns>true if item is found in the <see cref="RList{T}"/>; otherwise, false.</returns>
        bool Contains(T item);
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
        void CopyTo(T[] array, int arrayIndex);
        /// <summary>
        ///     Returns an enumerator that iterates through the <see cref="RList{T}"/>
        /// </summary>
        /// <returns>
        ///     A <see cref="RList{T}"/>.Enumerator for the <see cref="RList{T}"/>
        /// </returns>
        IEnumerator<T> GetEnumerator();
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
        int IndexOf(T item);
        /// <summary>
        ///  Inserts an element into the <see cref="RList{T}"/> at the specified
        ///  index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        void Insert(int index, T item);
        /// <summary>
        /// Pop <see cref="RList{T}"/>.
        /// </summary>
        /// <returns></returns>
        T Pop();
        /// <summary>
        /// Relese of the <see cref="RList{T}"/>.
        /// </summary>
        void Release();
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
        bool Remove(T item);
        /// <summary>
        ///     Removes the element at the specified index of the <see cref="RList{T}"/>
        /// </summary>
        /// <param name="index">
        ///     The zero-based index of the element to remove.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.-or-index is equal to or greater than <see cref="RList{T}"/>.
        /// </exception>
        void RemoveAt(int index);
        /// <summary>
        /// Sorts the elements
        /// </summary>
        /// <param name="comparer">comparing elements</param>
        void Sort(GateCompare<T> comparer);
        /// <summary>
        ///     Copies the elements of the <see cref="RList{T}"/> to a new array.
        /// </summary>
        /// <returns>
        ///     An array containing copies of the elements of the <see cref="RList{T}"/>
        /// </returns>
        T[] ToArray();
        /// <summary>
        /// Trimming <see cref="RList{T}"/>.
        /// </summary>
        void Trim();
    }
}