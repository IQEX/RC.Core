using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Collections
{
    public class Box2s2s2<TKey, TValue, T>
    {
        public readonly T t;
        public readonly TKey key;
        public readonly TValue val;
        public Box2s2s2(TKey key, TValue val, T t)
        {
            this.key = key;
            this.t = t;
            this.val = val;
        }
    }
    public class Box2s2<TKey, TValue>
    {
        public readonly TKey key;
        public readonly TValue val;
        public Box2s2(TKey key, TValue val)
        {
            this.key = key;
            this.val = val;
        }
    }
    public class Box2<T>
    {
        public readonly T T1, T2;
        public Box2(T t1, T t2)
        {
            this.T1 = t1;
            this.T2 = t2;
        }
    }
    public class Box3<T>
    {
        public readonly T T1, T2, T3;
        public Box3(T t1, T t2, T t3)
        {
            this.T1 = t1;
            this.T2 = t2;
            this.T3 = t3;
        }
        public Box3(Box2<T> ts, T t3)
        {
            this.T1 = ts.T1;
            this.T2 = ts.T2;
            this.T3 = t3;
        }
    }
    public class Box4<T>
    {
        public readonly T T1, T2, T3, T4;
        public Box4(T t1, T t2, T t3, T t4)
        {
            this.T1 = t1;
            this.T2 = t2;
            this.T3 = t3;
            this.T4 = t4;
        }
        public Box4(Box2<T> ts, T t3, T t4)
        {
            this.T1 = ts.T1;
            this.T2 = ts.T2;
            this.T3 = t3;
            this.T4 = t4;
        }
        public Box4(Box3<T> ts, T t4)
        {
            this.T1 = ts.T1;
            this.T2 = ts.T2;
            this.T3 = ts.T3;
            this.T4 = t4;
        }
    }
}
