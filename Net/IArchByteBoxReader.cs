// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxReader.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                   //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    public interface IArchByteBoxReader
    {
        byte[] rG();
        string rQ();
        short rS();
        IArchByteBoxReader Clone();
    }
}