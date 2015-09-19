// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxWriter.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="2.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    public interface IArchByteBoxWriter
    {
        byte[] GetAll();
        void wByte(byte[] data);
        void wString(string str);
        void wShort(short sht);
        void wFloat(float flt);
        void wLong(long lng);
        void wInt(int it);
        void wULong(ulong ulng);
        void wGUID(System.Guid g);
        void wDateTime(System.DateTime DT);
        IArchByteBoxWriter Clone();
    }
}