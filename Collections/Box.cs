// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Collections
{
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    /// <typeparam name="T3">Field Generic</typeparam>
    /// <typeparam name="T4">Field Generic</typeparam>
    public class Box<T1, T2, T3, T4>
    {
        private T1 _t1;
        private T2 _t2;
        private T3 _t3;
        private T4 _t4;
        /// <summary>
        /// is Read Only Field
        /// </summary>
        public readonly bool isReadOnly;
        /// <summary>
        /// Field Generic
        /// </summary>
        public T1 t1
        {
            get
            {
                return _t1;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t1 = value;
            }
        }
        /// <summary>
        /// Field Generic
        /// </summary>
        public T2 t2
        {
            get
            {
                return _t2;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t2 = value;
            }
        }
        /// <summary>
        /// Field Generic
        /// </summary>
        public T3 t3
        {
            get
            {
                return _t3;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t3 = value;
            }
        }
        /// <summary>
        /// Field Generic
        /// </summary>
        public T4 t4
        {
            get
            {
                return _t4;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t4 = value;
            }
        }
        public Box(T1 t1, T2 t2, T3 t3, T4 t4, bool ReadOnly = true)
        {
            this.isReadOnly = ReadOnly;
            this._t1 = t1;
            this._t2 = t2;
            this._t3 = t3;
            this._t4 = t4;
        }
    }
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    /// <typeparam name="T3">Field Generic</typeparam>
    public class Box<T1, T2, T3>
    {
        private T1 _t1;
        private T2 _t2;
        private T3 _t3;
        /// <summary>
        /// is Read Only Field
        /// </summary>
        public readonly bool isReadOnly;
        /// <summary>
        /// Field Generic
        /// </summary>
        public T1 t1
        {
            get
            {
                return _t1;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t1 = value;
            }
        }
        /// <summary>
        /// Field Generic
        /// </summary>
        public T2 t2
        {
            get
            {
                return _t2;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t2 = value;
            }
        }
        /// <summary>
        /// Field Generic
        /// </summary>
        public T3 t3
        {
            get
            {
                return _t3;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t3 = value;
            }
        }
        public Box(T1 t1, T2 t2, T3 t3, bool ReadOnly = true)
        {
            this.isReadOnly = ReadOnly;
            this._t1 = t1;
            this._t2 = t2;
            this._t3 = t3;
        }
    }
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    public class Box<T1, T2>
    {
        private T1 _t1;
        private T2 _t2;
        /// <summary>
        /// is Read Only Field
        /// </summary>
        public readonly bool isReadOnly;
        /// <summary>
        /// Field Generic T1
        /// </summary>
        public T1 t1
        {
            get
            {
                return _t1;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t1 = value;
            }
        }
        /// <summary>
        /// Field Generic T1
        /// </summary>
        public T2 t2
        {
            get
            {
                return _t2;
            }
            set
            {
                if (isReadOnly)
                    throw new FieldAccessException("this Field is readonly");
                _t2 = value;
            }
        }
        public Box(T1 t1, T2 t2, bool ReadOnly = true)
        {
            this.isReadOnly = ReadOnly;
            this._t1 = t1;
            this._t2 = t2;
        }
    }
}
