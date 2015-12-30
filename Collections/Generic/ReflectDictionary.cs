// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
using System.Linq;
namespace RC.Framework.Collections.Generic
{
    /// <summary>
    /// Same as a .net dictionary. But just working in both directions.
    /// </summary>
    /// <typeparam name="TKey">The type of the first dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the second dictionary.</typeparam>
    public class ReflectDictionary<TKey, TValue> : IReflectDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictOne = new Dictionary<TKey, TValue>();
        private Dictionary<TValue, TKey> dictTwo = new Dictionary<TValue, TKey>();
        /// <summary>
        /// Gets the ElementA
        /// </summary>
        /// <param name="u">ElementB</param>
        /// <returns>ElementA</returns>
        public TKey this[TValue u]
        {
            get { return dictTwo[u]; }
        }
        /// <summary>
        /// Gets the ElementB
        /// </summary>
        /// <param name="t">ElementA</param>
        /// <returns>ElementB</returns>
        public TValue this[TKey t]
        {
            get { return dictOne[t]; }
        }
        /// <summary>
        /// Gets all the values for the A element.
        /// </summary>
        public IRList<TKey> KeyElements { get { return (RList<TKey>)dictTwo.Values.ToList(); } }
        /// <summary>
        /// Gets all the values for the B element.
        /// </summary>
        public IRList<TValue> ValueElements { get { return (RList<TValue>)dictOne.Values.ToList(); } }
        /// <summary>
        /// Adds an element to the bidictinary
        /// </summary>
        /// <param name="t">Element A</param>
        /// <param name="u">Element B</param>
        public void Add(TKey t, TValue u)
        {
            dictOne.Add(t, u);
            dictTwo.Add(u, t);
        }
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="t">Element A</param>
        public void RemoveElement(TKey t)
        {
            dictTwo.Remove(dictOne[t]);
            dictOne.Remove(t);
        }
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="u">Element B</param>
        public void RemoveElement(TValue u)
        {
            dictOne.Remove(dictTwo[u]);
            dictTwo.Remove(u);
        }
        /// <summary>
        /// Adds an element to the bidictinary
        /// </summary>
        /// <param name="t">Element B</param>
        /// <param name="u">Element A</param>
        public void AddElement(TValue u, TKey t)
        {
            dictOne.Add(t, u);
            dictTwo.Add(u, t);
        }
        /// <summary>
        /// Removes an element from the bidictinary
        /// </summary>
        /// <param name="t">Element B</param>
        /// <param name="u">Element A</param>
        public void RemoveElement(TValue u, TKey t)
        {
            dictOne.Remove(t);
            dictTwo.Remove(u);
        }
        /// <summary>
        /// Returns an element
        /// </summary>
        /// <param name="u">Element B</param>
        /// <returns>Element A</returns>
        public TKey GetElement(TValue u)
        {
            return dictTwo[u];
        }
        /// <summary>
        /// Returns an element
        /// </summary>
        /// <param name="t">Element A</param>
        /// <returns>Element B</returns>
        public TValue GetElement(TKey t)
        {
            return dictOne[t];
        }
        /// <summary>
        /// Returns the element a a special offset
        /// </summary>
        /// <param name="offSet">The offset</param>
        /// <returns>KeyValuePair</returns>
        public KeyValuePair<TKey, TValue> GetElement(int offSet)
        {
            return dictOne.ElementAt(offSet);
        }
        /// <summary>
        /// Returns the amount of the dictionary
        /// </summary>
        public int Count
        {
            get { return (dictOne.Count + dictTwo.Count) / 2; }
        }
        /// <summary>
        /// Proofs if an A element exists or not
        /// </summary>
        /// <param name="t">Element A</param>
        /// <returns>Exists or not</returns>
        public bool ElementAExists(TKey t)
        {
            TValue elementB;
            return dictOne.TryGetValue(t, out elementB);
        }
        /// <summary>
        /// Proofs if an A element exists or not
        /// </summary>
        /// <param name="u">Element B</param>
        /// <returns>Exists or not</returns>
        public bool ElementBExists(TValue u)
        {
            TKey elementA;
            return dictTwo.TryGetValue(u, out elementA);
        }
    }
}
