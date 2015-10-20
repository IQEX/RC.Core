// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Rc.Framework.Collections.Generic
{
    public interface IRcList<T> : ICollection<T>
    {
        int Count { get; }
        object Get(int index);
        void Add(T obj);
        void RemoveAt(int index);
        void Clear();
    }
    [Serializable]
    public class SList<T> : IRcList<T>
    {

        public T[] buffer;
        public int size = 0;
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            if (buffer != null)
            {
                for (int i = 0; i < size; ++i)
                {
                    yield return buffer[i];
                }
            }
        }
        public T this[int i]
        {
            get { return buffer[i]; }
            set { buffer[i] = value; }
        }
        public int Count { get { return size; } }
        public object Get(int index) { return buffer[index]; }
        void AllocateMore()
        {
            int max = (buffer == null) ? 0 : (buffer.Length << 1);
            if (max < 32) max = 32;
            T[] newList = new T[max];
            if (buffer != null && size > 0) buffer.CopyTo(newList, 0);
            buffer = newList;
        }
        void Trim()
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
        public void Clear() { size = 0; }
        public void Release() { size = 0; buffer = null; }
        public void Add(T item)
        {
            if (buffer == null || size == buffer.Length) AllocateMore();
            buffer[size++] = item;
        }
        public void Add(object item)
        {
            if (buffer == null || size == buffer.Length) AllocateMore();
            buffer[size++] = (T)item;
        }
        public void Insert(int index, T item)
        {
            if (buffer == null || size == buffer.Length) AllocateMore();

            if (index > -1 && index < size)
            {
                for (int i = size; i > index; --i) buffer[i] = buffer[i - 1];
                buffer[index] = item;
                ++size;
            }
            else Add(item);
        }
        public bool Contains(T item)
        {
            if (buffer == null) return false;
            for (int i = 0; i < size; ++i) if (buffer[i].Equals(item)) return true;
            return false;
        }
        public int IndexOf(T item)
        {
            if (buffer == null) return -1;
            for (int i = 0; i < size; ++i) if (buffer[i].Equals(item)) return i;
            return -1;
        }
        public bool Remove(T item)
        {
            if (buffer != null)
            {
                System.Collections.Generic.EqualityComparer<T> comp =
                    System.Collections.Generic.EqualityComparer<T>.Default;

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
        public void RemoveAt(int index)
        {
            if (buffer != null && index > -1 && index < size)
            {
                --size;
                buffer[index] = default(T);
                for (int b = index; b < size; ++b) buffer[b] = buffer[b + 1];
            }
        }
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
        public T[] ToArray() { Trim(); return buffer; }
        public delegate int CompareFunc(T left, T right);
        [DebuggerHidden]
        [DebuggerStepThrough]
        public void Sort(CompareFunc comparer)
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
    }
}