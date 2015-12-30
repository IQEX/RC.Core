// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Net.NTCore
{
    using System;
    public interface INetworkObject
    {
        byte[] ToByte();
        void outByte(byte[] bitBox);
    }
    /// <summary>
    /// Class of Network Object
    /// </summary>
    public abstract class NetworkObject : INetworkObject
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

    public class TRE : NetworkObject
    {
        public override void outByte(byte[] bitBox)
        {
            throw new NotImplementedException();
        }

        public override byte[] ToByte()
        {
            throw new NotImplementedException();
        }
    }

    public static class NTCodeEx
    {
        public static byte[] ToNetworkObject(this INetworkObject t)
        {
            TRE ts = new TRE();
            
            return null;
        }
    }
}
