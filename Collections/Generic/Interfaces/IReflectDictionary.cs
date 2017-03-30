// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;

namespace RC.Framework.Collections.Generic
{
    /// <summary>
    /// Same as a .net dictionary. But just working in both directions.
    /// </summary>
    /// <typeparam name="TKey">The type of the first dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the second dictionary.</typeparam>
    public interface IReflectDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets the ElementA
        /// </summary>
        /// <param name="u">ElementB</param>
        /// <returns>ElementA</returns>
        TKey this[TValue u] { get; }
        /// <summary>
        /// Gets the ElementB
        /// </summary>
        /// <param name="t">ElementA</param>
        /// <returns>ElementB</returns>
        TValue this[TKey t] { get; }
        /// <summary>
        /// Returns the amount of the dictionary
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Gets all the values for the A element.
        /// </summary>
        IRList<TKey> KeyElements { get; }
        /// <summary>
        /// Gets all the values for the B element.
        /// </summary>
        IRList<TValue> ValueElements { get; }
        /// <summary>
        /// Adds an element to the bidictinary
        /// </summary>
        /// <param name="t">Element A</param>
        /// <param name="u">Element B</param>
        void Add(TKey t, TValue u);
        /// <summary>
        /// Adds an element to the bidictinary
        /// </summary>
        /// <param name="t">Element B</param>
        /// <param name="u">Element A</param>
        void AddElement(TValue u, TKey t);
        /// <summary>
        /// Proofs if an A element exists or not
        /// </summary>
        /// <param name="t">Element A</param>
        /// <returns>Exists or not</returns>
        bool ElementAExists(TKey t);
        /// <summary>
        /// Proofs if an A element exists or not
        /// </summary>
        /// <param name="u">Element B</param>
        /// <returns>Exists or not</returns>
        bool ElementBExists(TValue u);
        /// <summary>
        /// Returns an element
        /// </summary>
        /// <param name="u">Element B</param>
        /// <returns>Element A</returns>
        TKey GetElement(TValue u);
        /// <summary>
        /// Returns an element
        /// </summary>
        /// <param name="t">Element A</param>
        /// <returns>Element B</returns>
        TValue GetElement(TKey t);
        /// <summary>
        /// Returns the element a a special offset
        /// </summary>
        /// <param name="offSet">The offset</param>
        /// <returns>KeyValuePair</returns>
        KeyValuePair<TKey, TValue> GetElement(int offSet);
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="u">Element B</param>
        void RemoveElement(TValue u);
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="t">Element A</param>
        void RemoveElement(TKey t);
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="t">Element B</param>
        /// <param name="u">Element A</param>
        void RemoveElement(TValue u, TKey t);
    }
}