// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Types\\Handle.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
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
    public class HANDLE
    {
        private IntPtr PTRST;
        private HANDLE(IntPtr pt)
        {
            this.PTRST = pt;
        }
        public HANDLE(long pt)
        {
            this.PTRST = new IntPtr(pt);
        }
        public static implicit operator HANDLE(IntPtr a)
        {
            return new HANDLE(a);
        }
        public static implicit operator IntPtr(HANDLE d)
        {
            return d.PTRST;
        }
    }
}
