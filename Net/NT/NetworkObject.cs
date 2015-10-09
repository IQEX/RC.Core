using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
