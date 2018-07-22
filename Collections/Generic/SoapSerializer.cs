// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//

using System;
using System.IO;

namespace RC.Framework.Collections.Generic
{
    /// <summary>
    /// Содержит методы работы с soap
    /// </summary>
    public static class SoapSerializer
    {
        /// <summary>
        /// unpack soap string array byte
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public static T DeSerializable<T>(byte[] bt) where T : class
        {
            if (bt == null || bt.Length == 0)
                throw new System.ArgumentException("byte array is empty", nameof(bt));
            //T t;
            using (MemoryStream fs = new MemoryStream(bt))
            {
                throw new NotImplementedException();
            }
            //return t;
        }
        /// <summary>
        /// pack T to soap string byte array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] Serializable<T>(T t) where T : class
        {
            if (t == null)
                throw new System.ArgumentException("byte array is empty", nameof(t));
           // byte[] nit = null;
            using (MemoryStream fs = new MemoryStream())
            {
                throw new NotImplementedException();
                //nit = fs.ToArray();
            }
           // return nit;
        }
    }
}
