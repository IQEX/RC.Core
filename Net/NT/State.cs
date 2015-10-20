// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Net;
using System.Net.Sockets;
namespace Rc.Framework.Net.NTCore
{
    /// <summary>
    /// Simple implementation of the UdpState class mentioned on 
    /// http://msdn.microsoft.com/en-us/library/c8s04db1(v=VS.80).aspx
    /// </summary>
    public class UdpState
    {
        public UdpState(UdpClient c, IPEndPoint e)
        {
            this.c = c;
            this.e = e;
        }
        public UdpClient c;
        public IPEndPoint e;
    }
}
