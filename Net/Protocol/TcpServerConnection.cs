﻿#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
namespace RC.Framework.Net.Protocol.Tcp
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    public class TokenUserCollectionTransportSpace
    {
        private TcpClient m_socket;
        private readonly List<byte[]> messagesToSend;
        private int attemptCount;
        private Thread m_thread;
        private DateTime m_lastVerifyTime;
        private Encoding m_encoding;
        public string IP;
        public TokenUserCollectionTransportSpace(TcpClient sock, Encoding encoding)
        {
            m_socket = sock;
            messagesToSend = new List<byte[]>();
            attemptCount = 0;

            m_lastVerifyTime = DateTime.UtcNow;
            m_encoding = encoding;
        }
        public bool connected()
        {
            try
            {
                return m_socket.Connected;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool verifyConnected()
        {
            //note: `Available` is checked before because it's faster,
            //`Available` is also checked after to prevent a race condition.
            bool connected = m_socket.Client.Available != 0 || 
                !m_socket.Client.Poll(microSeconds: 1, mode: SelectMode.SelectRead) || 
                m_socket.Client.Available != 0;
            m_lastVerifyTime = DateTime.UtcNow;
            return connected;
        }
        public bool processOutgoing(int maxSendAttempts)
        {
            lock (m_socket)
            {
                if (!m_socket.Connected)
                {
                    messagesToSend.Clear();
                    return false;
                }

                if (messagesToSend.Count == 0)
                {
                    return false;
                }

                NetworkStream stream = m_socket.GetStream();
                try
                {
                    stream.Write(messagesToSend[index: 0], offset: 0, size: messagesToSend[index: 0].Length);

                    lock (messagesToSend)
                    {
                        messagesToSend.RemoveAt(index: 0);
                    }
                    attemptCount = 0;
                }
                catch (System.IO.IOException)
                {
                    //occurs when there's an error writing to network
                    attemptCount++;
                    if (attemptCount < maxSendAttempts) return messagesToSend.Count != 0;
                    //TODO log error

                    lock (messagesToSend)
                    {
                        messagesToSend.RemoveAt(index: 0);
                    }
                    attemptCount = 0;
                }
                catch (ObjectDisposedException)
                {
                    //occurs when stream is closed
                    m_socket.Close();
                    return false;
                }
            }
            return messagesToSend.Count != 0;
        }
        public void sendData(byte[] data)
        {
            lock (messagesToSend)
            {
                messagesToSend.Add(data);
            }
        }
        public void forceDisconnect()
        {
            lock (m_socket)
            {
                m_socket.Close();
            }
        }
        public bool hasMoreWork()
        {
            return messagesToSend.Count > 0 || (Socket.Available > 0 && canStartNewThread());
        }
        private bool canStartNewThread()
        {
            if (m_thread == null) return true;
            return (m_thread.ThreadState & (ThreadState.Aborted | ThreadState.Stopped)) != 0 &&
                   (m_thread.ThreadState & ThreadState.Unstarted) == 0;
        }
        public TcpClient Socket
        {
            get
            {
                return m_socket;
            }
            set
            {
                m_socket = value;
            }
        }
        public Thread CallbackThread
        {
            get
            {
                return m_thread;
            }
            set
            {
                if (!canStartNewThread())
                {
                    throw new Exception("Cannot override TcpServerConnection Callback Thread. The old thread is still running.");
                }
                m_thread = value;
            }
        }
        public DateTime LastVerifyTime => m_lastVerifyTime;

        public Encoding Encoding
        {
            get
            {
                return m_encoding;
            }
            set
            {
                m_encoding = value;
            }
        }
    }
}
