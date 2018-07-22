// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\Protocol\\TcpServer.cs"             Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="RC.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.3"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//

using System.Linq;
using RC.Framework.Net.Arch;

#pragma warning disable CS1591
namespace RC.Framework.Net.Protocol.Tcp
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    public delegate void SConnection(TokenUserCollectionTransportSpace connection);
    public delegate void SError(TcpPlatform server, Exception e);
    public delegate void SDisconnect(TcpPlatform server, TokenUserCollectionTransportSpace connection);


    public class TcpPlatform
    {
        private List<TokenUserCollectionTransportSpace> connections;
        private TcpListener listener;

        private Thread listenThread;
        private Thread sendThread;

        private bool m_isOpen;

        private int m_port;
        private int m_maxSendAttempts;
        private int m_idleTime;
        private int m_maxCallbackThreads;
        private int m_verifyConnectionInterval;
        private Encoding m_encoding;
        private SemaphoreSlim sem;
        private bool waiting;
        private int activeThreads;
        private readonly object activeThreadsLock = new object();
        public event SConnection OnConnect = null;
        public event SConnection OnDataAvailable = null;
        public event SDisconnect OnDisconnect = null;
        public event SError OnError = null;
        public TcpPlatform()
        {
            initialise();
        }
        private void initialise()
        {
            connections = new List<TokenUserCollectionTransportSpace>();
            listener = null;

            listenThread = null;
            sendThread = null;

            m_port = -1;
            m_maxSendAttempts = 3;
            m_isOpen = false;
            m_idleTime = 50;
            m_maxCallbackThreads = 100;
            m_verifyConnectionInterval = 100;
            m_encoding = Encoding.ASCII;

            sem = new SemaphoreSlim(initialCount: 0);
            waiting = false;

            activeThreads = 0;
        }
        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (value < 0) return;
                if (m_port == value) return;
                if (m_isOpen) throw new Exception("Invalid attempt to change port while still open.\n" +
                                                  "Please close port before changing.");

                m_port = value;
                if (listener == null)
                {
                    //this should only be called the first time.
                    listener = new TcpListener(IPAddress.Any, m_port);
                }
                else
                {
                    listener.Server.Bind(new IPEndPoint(IPAddress.Any, m_port));
                }
            }
        }
        public int MaxSendAttempts
        {
            get
            { return m_maxSendAttempts; }
            set
            { m_maxSendAttempts = value; }
        }
        public bool IsOpen
        {
            get
            {
                return m_isOpen;
            }
            set
            {
                if (m_isOpen == value)
                {
                    return;
                }

                if (value)
                {
                    Open();
                }
                else
                {
                    Close();
                }
            }
        }
        public List<TokenUserCollectionTransportSpace> Connections
        {
            get
            {
                List<TokenUserCollectionTransportSpace> rv = new List<TokenUserCollectionTransportSpace>();
                rv.AddRange(connections);
                return rv;
            }
        }
        public int IdleTime
        {
            get
            {
                return m_idleTime;
            }
            set
            {
                m_idleTime = value;
            }
        }
        public int MaxCallbackThreads
        {
            get
            {
                return m_maxCallbackThreads;
            }
            set
            {
                m_maxCallbackThreads = value;
            }
        }
        public int VerifyConnectionInterval
        {
            get
            {
                return m_verifyConnectionInterval;
            }
            set
            {
                m_verifyConnectionInterval = value;
            }
        }
        public Encoding Encoding
        {
            get
            {
                return m_encoding;
            }
            set
            {
                Encoding oldEncoding = m_encoding;
                m_encoding = value;
                foreach (TokenUserCollectionTransportSpace client in connections.Where(client => client.Encoding == oldEncoding))
                {
                    client.Encoding = m_encoding;
                }
            }
        }
        public void setEncoding(Encoding encoding, bool changeAllClients)
        {
            Encoding oldEncoding = m_encoding;
            m_encoding = encoding;
            if (!changeAllClients) return;
            foreach (TokenUserCollectionTransportSpace client in connections)
            {
                client.Encoding = m_encoding;
            }
        }
        private void runListener()
        {
            while (m_isOpen && m_port >= 0)
            {
                try
                {
                    if (listener.Pending())
                    {
                        TcpClient socket = listener.AcceptTcpClient();
                        TokenUserCollectionTransportSpace conn = new TokenUserCollectionTransportSpace(socket, m_encoding);

                        if (OnConnect != null)
                        {
                            lock (activeThreadsLock)
                            {
                                activeThreads++;
                            }
                            conn.CallbackThread = new Thread(() =>
                            {
                                OnConnect(conn);
                            });
                            conn.CallbackThread.Start();
                        }

                        lock (connections)
                        {
                            connections.Add(conn);
                        }
                    }
                    else
                    {
                        Thread.Sleep(m_idleTime);
                    }
                }
                catch (ThreadInterruptedException) { } //thread is interrupted when we quit
                catch (Exception e)
                {
                    if (m_isOpen)
                    {
                        OnError?.Invoke(this, e);
                    }
                }
            }
        }
        private void runSender()
        {
            while (m_isOpen && m_port >= 0)
            {
                try
                {
                    bool moreWork = false;
                    for (int i = 0; i < connections.Count; i++)
                    {
                        if (connections[i].CallbackThread != null)
                        {
                            try
                            {
                                connections[i].CallbackThread = null;
                                lock (activeThreadsLock)
                                {
                                    activeThreads--;
                                }
                            }
                            catch (Exception ex)
                            {
                                OnError?.Invoke(this, ex);
                            }
                        }

                        if (connections[i].CallbackThread != null) { }
                        else if (connections[i].connected() && 
                            (connections[i].LastVerifyTime.AddMilliseconds(m_verifyConnectionInterval) > DateTime.UtcNow || 
                             connections[i].verifyConnected()))
                        {
                            moreWork = moreWork || processConnection(connections[i]);
                        }
                        else
                        {
                            lock (connections)
                            {
                                OnDisconnect?.Invoke(this, connections[i]);
                                connections.RemoveAt(i);
                                i--;
                            }
                        }
                    }

                    if (moreWork) continue;
                    Thread.Yield();
                    lock (sem)
                    {
                        if (connections.Any(conn => conn.hasMoreWork()))
                        {
                            moreWork = true;
                        }
                    }
                    if (moreWork) continue;
                    waiting = true;
                    sem.Wait(m_idleTime);
                    waiting = false;
                }
                catch (ThreadInterruptedException ex)
                {
                    OnError?.Invoke(this, ex);
                }
                catch (Exception e)
                {
                    if (m_isOpen) OnError?.Invoke(this, e);
                }
            }
        }
        public byte[] readStream(TcpClient client)
        {
            lock (this)
            {
                NetworkStream stream = client.GetStream();
                while (stream.DataAvailable)
                {

                    byte[] arLength = new byte[sizeof(short)];
                    stream.Read(arLength, offset: 0, size: arLength.Length);
                    IArchByteBoxReader reader = ArchManagedByte.InvokeReader(arLength);
                    short Length = reader.rShort();
                    byte[] byffer = new byte[Length];
                    stream.Read(byffer, offset: 0, size: byffer.Length);

                    return byffer;
                }
                return null;
            }
        }
        private bool processConnection(TokenUserCollectionTransportSpace conn)
        {
            bool moreWork = conn.processOutgoing(m_maxSendAttempts);

            if (OnDataAvailable == null || activeThreads >= m_maxCallbackThreads || conn.Socket.Available <= 0)
                return moreWork;
            lock (activeThreadsLock)
            {
                activeThreads++;
            }
            conn.CallbackThread = new Thread(() =>
            {
                OnDataAvailable(conn);
            });
            conn.CallbackThread.Start();
            Thread.Yield();
            return moreWork;
        }
        public void Open()
        {
            lock (this)
            {
                if (m_isOpen) return; //already open, no work to do
                if (m_port < 0) throw new Exception("Invalid port");

                try
                {
                    listener.Start(backlog: 5);
                }
                catch (Exception)
                {
                    listener.Stop();
                    listener = new TcpListener(IPAddress.Any, m_port);
                    listener.Start();
                }

                m_isOpen = true;

                listenThread = new Thread(runListener);
                listenThread.Start();

                sendThread = new Thread(runSender);
                sendThread.Start();
            }
        }
        public void Close()
        {
            if (!m_isOpen) return;

            lock (this)
            {
                m_isOpen = false;
                foreach (TokenUserCollectionTransportSpace conn in connections)
                {
                    conn.forceDisconnect();
                }
                try
                {
                    if (listenThread.IsAlive)
                    {
                        listenThread.Interrupt();

                        Thread.Yield();
                        if(listenThread.IsAlive)
                        {
                            listenThread.Abort();
                        }
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    OnError?.Invoke(this, ex);
                }
                try
                {
                    if (sendThread.IsAlive)
                    {
                        sendThread.Interrupt();

                        Thread.Yield();
                        if(sendThread.IsAlive)
                        {
                            sendThread.Abort();
                        }
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    OnError?.Invoke(this, ex);
                }
            }
            listener.Stop();

            lock (connections)
            {
                connections.Clear();
            }

            listenThread = null;
            sendThread = null;
            GC.Collect();
        }
        public void Send(byte[] data)
        {
            lock (sem)
            {
                foreach (TokenUserCollectionTransportSpace conn in connections)
                {
                    conn.sendData(data);
                }
                Thread.Yield();
                if (!waiting) return;
                sem.Release();
                waiting = false;
            }
        }
    }
}
