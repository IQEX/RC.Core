// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxWriter.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                   //                                                              //
// =====================================//==============================================================//
using System;

namespace Rc.Framework.Net
{
    public interface IArchByteBoxWriter
    {
        byte[] GetAll();
        void wG(byte[] data);
        void wQ(string str);
        void wS(short sht);
        IArchByteBoxWriter Clone();
    }
}