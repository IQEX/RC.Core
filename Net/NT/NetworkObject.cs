﻿// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Framework.Net.NTCore
{
    /// <summary>
    /// Class of Network Object
    /// </summary>
    public abstract class NetworkObject
    {
        /// <summary>
        /// Class to Byte Array
        /// </summary>
        /// <returns></returns>
        public abstract byte[] ToByte();
        /// <summary>
        /// Byte Array To Content Class
        /// </summary>
        /// <param name="bitBox">Content</param>
        public abstract void outByte(byte[] bitBox);
    }
}
