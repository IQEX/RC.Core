// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\Protocol\\RawNet.cs"             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.3"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rc.Framework.Net.Protocol
{
    public delegate void OnErrorPPD(string message, int id);
    public delegate void OnArchPackagesPPD(IArchByteBoxReader box);
    public enum EProtocol
    {
        UDP,
        TCP,
        FTP,
    }
    public enum FamilyAddress
    {
        IPV4,
        IPV6
    }
    public enum RawNetErrorCode : int
    {
        HANDLE_ON_CREATE_CONNECT = 17020,
        HANDLE_ON_STREAM,
        HANDLE_ON_READ_STREAM
    }
    public sealed class RawNet
    {
        // ======================================
        // Protocol's
        // ======================================
        private static TcpClient rnt;
        private static r_nudp rnu;
        // ======================================
        // Enum's
        // ======================================
        private EProtocol Tocol;
        private FamilyAddress FA;
        // ======================================
        // Filed's
        // ======================================
        public bool isConnect
        {
            get
            {
                return rnt.Connected;
            }
        }
        public bool isExit;

        private NetworkStream NetStream;
        // ======================================
        // Event
        // ======================================
        public event OnErrorPPD OnError;
        public event OnArchPackagesPPD OnPack;
        // ======================================
        // Construct
        // ======================================
        public RawNet(EProtocol eptc, FamilyAddress fadr)
        {
            this.FA = fadr;
            this.Tocol = eptc;
        }
        // ======================================
        // Method
        // ======================================
        public async Task<RawNet> Connect(IPAddress ip, int port)
        {
            if(Tocol == EProtocol.TCP)
            {
                try
                {
                    rnt = new TcpClient();
                    await rnt.ConnectAsync(ip, port);
                }
                catch(Exception ex)
                {
                    if (OnError != null)
                        OnError(ex.Message, (int)RawNetErrorCode.HANDLE_ON_CREATE_CONNECT);
                }
                try
                {
                    NetStream = rnt.GetStream();
                }
                catch (Exception ex)
                {
                    if (OnError != null)
                        OnError(ex.Message, (int)RawNetErrorCode.HANDLE_ON_STREAM);
                }
                new Thread(() => 
                {
                    while(!isExit)
                    {
                        try
                        {
                            if(NetStream.DataAvailable)
                            {
                                byte[] bytes = new byte[rnt.ReceiveBufferSize];
                                int bytesRead = NetStream.Read(bytes, 0, rnt.ReceiveBufferSize);
                                IArchByteBoxReader reader = ArchByteBox.InvokeReader(bytes);
                                if (OnPack != null)
                                    OnPack(reader.Clone());
                                reader = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (OnError != null)
                                OnError(ex.ToString(), (int)RawNetErrorCode.HANDLE_ON_READ_STREAM);
                        }
                    }
                }).Start();
            }
            else if (Tocol == EProtocol.UDP)
            {
                throw new Exception("Protocol UDP Not Work");
            }
            return this;
        }
        public RawNet Send(IArchByteBoxWriter wr)
        {
            NetStream.Write(wr.GetAll(), 0, wr.GetAll().Length);
            return this;
        }
    }
    internal class r_ntcp : System.Net.Sockets.TcpClient
    {
        public r_ntcp() : base()
        {

        }
    }
    internal class r_nudp : System.Net.Sockets.UdpClient
    {

    }
}
