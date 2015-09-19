// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxWriter.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.2"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    public interface IArchByteBoxWriter
    {
        byte[] GetAll();
        void wG(byte[] data);
        void wQ(string str);
        void wS(short sht);
        void wF(float flt);
        void wL(long lng);
        void wGUID(System.Guid g);
        void wDT(System.DateTime DT);
        IArchByteBoxWriter Clone();
    }
}