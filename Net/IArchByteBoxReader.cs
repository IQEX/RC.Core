// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxReader.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="3.2"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    public interface IArchByteBoxReader
    {
        byte[] rByte();
        string rString();
        short rShort();
        float rFloat();
        int rInt();
        long rLong();
        bool rBool();
        ulong rULong();
        ushort rUShort();
        uint rUInt();
        RMath.IntRange rIRange();
        RMath.Range rFRange();
        System.DateTime rDateTime();
        System.Guid rGUID();
        IArchByteBoxReader Clone();
    }
}