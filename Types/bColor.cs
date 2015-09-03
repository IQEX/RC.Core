// =====================================//==============================================================//
//                                      //                                                              //         
// Source="root\\Types\\bColor.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
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
    public class bColor
    {
        public bColor(byte r, byte b, byte g, byte a)
        {
            this.R = r;
            this.B = b;
            this.G = g;
            this.A = a;
        }
        public byte R;
        public byte B;
        public byte G;
        public byte A;
    }
}
