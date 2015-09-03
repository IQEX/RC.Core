// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Types\\Dword.cs"       //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="5.0"                   //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Types
{
    [Serializable]
    /// <summary>
    /// Dword Code App
    /// </summary>
    public class DWORD : IComparable, IComparable<DWORD>, IEquatable<DWORD>
    {
        private UInt64 UU;
        private DWORD(UInt64 u)
        {
            this.UU = u;
        }
        public static implicit operator DWORD(UInt64 a)
        {
            return new DWORD(a);
        }
        public static implicit operator UInt64(DWORD d)
        {
            return d.UU;
        }
        public static explicit operator DWORD(String a)
        {
            return new DWORD(UInt64.Parse(a));
        }
        public static explicit operator String(DWORD d)
        {
            return d.UU.ToString();
        }
        public static DWORD operator +(DWORD a, DWORD b)
        {
            return new DWORD(a.UU + b.UU);
        }
        public static DWORD operator -(DWORD a, DWORD b)
        {
            return new DWORD(a.UU - b.UU);
        }
        public static DWORD operator *(DWORD a, DWORD b)
        {
            return new DWORD(a.UU * b.UU);
        }
        public static bool operator !=(DWORD a, DWORD b)
        {
            if (a.UU != b.UU)
                return true;
            else
                return false;
        }
        public static bool operator ==(DWORD a, DWORD b)
        {
            if (a.UU == b.UU)
                return true;
            else
                return false;
        }
        public int CompareTo(DWORD other)
        {
            return 1;
        }
        public int CompareTo(object obj)
        {
            return -1;
        }
        public bool Equals(DWORD other)
        {
            if (this.UU == other.UU)
                return true;
            else
                return false;
        }
        public TypeCode GetTypeCode()
        {
            return TypeCode.UInt64;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
