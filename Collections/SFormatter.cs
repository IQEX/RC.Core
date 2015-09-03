// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Collection\\SFormatter.cs"               Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Collections
{
    public class SFormatter<T>
    {
        public T DeSerializable(byte[] bt)
        {
            T t;
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream fs = new MemoryStream(bt))
            {
                t = (T)formatter.Deserialize(fs);
            }
            return t;
        }
        public byte[] Serializable(T t)
        {
            byte[] nit = null;
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream fs = new MemoryStream())
            {
                formatter.Serialize(fs, t);
                nit = fs.ToArray();
            }
            return nit;
        }
    }
}
