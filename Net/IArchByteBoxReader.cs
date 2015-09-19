﻿// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxReader.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.3"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    public interface IArchByteBoxReader
    {
        byte[] rG();
        string rQ();
        short rS();
        float rF();
        int rI();
        long rL();
        System.Guid rGUID();
        IArchByteBoxReader Clone();
    }
}