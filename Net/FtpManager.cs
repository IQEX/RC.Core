// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\FtpManager.cs"    //     Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>    //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rc.Framework.Net
{
    /// <summary>
    /// Basic class of DotNetFtpLibrary
    /// </summary>
    public class FtpClient
    {
        private const int BUFFER_SIZE = 32768;
        //private const int BUFFER_SIZE = 1024;
        private Thread _thread;
        private bool _abort = false;
        private string _host;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Port | defaultValue = 21
        /// </summary>
        public int Port { get; set; }
        //# DO NOT USE: ftp://192.168.0.1, ftp://www.myftpserver.com
        /// <summary>
        /// URL of your ftpServer e.g. 192.168.0.1, www.myftpserver.com 
        /// !DO NOT USE: ftp://192.168.0.1, ftp://www.myftpserver.com
        /// </summary>
        public string Host { get { return _host; } set { this.SetHost(value); } }
        /// <summary>
        /// Transfermode | defaultValue = true | usePassive = false maybe fails (firewall settings..)
        /// </summary>
        public bool UsePassive { get; set; }
        /// <summary>
        /// Timeout of connection | defaultValue = 30000
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// KeepAlive | defaultValue = false
        /// </summary>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// Occurs when upload process has changed
        /// </summary>
        public event EventHandler<UploadProgressChangedLibArgs> UploadProgressChanged;
        /// <summary>
        /// Occurs when upload process has completed or error has been detected
        /// </summary>
        public event EventHandler<UploadFileCompletedEventLibArgs> UploadFileCompleted;
        /// <summary>
        /// Occurs when download process has changed
        /// </summary>
        public event EventHandler<DownloadProgressChangedLibArgs> DownloadProgressChanged;
        /// <summary>
        /// Occurs when download process has completed or error has been detected
        /// </summary>
        public event EventHandler<DownloadFileCompletedEventLibArgs> DownloadFileCompleted;

        /// <summary>
        /// Creates an instance of FtpClient
        /// </summary>
        public FtpClient()
        {
            UsePassive = true;
            this.TimeOut = 30000;
            KeepAlive = false;
        }

        /// <summary>
        /// Creates an instance of FtpClient
        /// </summary>
        /// <param name="host">URL of your ftpServer e.g. 192.168.0.1, www.myftpserver.com ! DO NOT USE: ftp://192.168.0.1, ftp://www.myftpserver.com</param>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="port">Port of ftpServer | defaultValue = 21</param>
        public FtpClient(string host, string userName, string password, int port)
        {
            Host = host;
            UserName = userName;
            Password = password;
            Port = port;
            UsePassive = true;
            this.TimeOut = 30000;
            KeepAlive = false;
        }

        /// <summary>
        /// Creates an instance of FtpClient
        /// </summary>
        /// <param name="host">URL of your ftpServer e.g. 192.168.0.1, www.myftpserver.com ! DO NOT USE: ftp://192.168.0.1, ftp://www.myftpserver.com</param>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="port">Port of ftpServer | defaultValue = 21</param>
        /// <param name="usePassive">Transfermode | defaultValue = true | usePassive = false maybe fails (firewall settings..)</param>
        public FtpClient(string host, string userName, string password, int port, bool usePassive)
        {
            Host = host;
            UserName = userName;
            Password = password;
            Port = port;
            UsePassive = usePassive;
            this.TimeOut = 30000;
            KeepAlive = false;
        }


        /// <summary>
        /// Uploads file to ftpServer | method blocks calling thread till upload is finnished or error occured
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Upload(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            _abort = false;
            FtpWebRequest request = null;
            long totalBytesSend = 0;

            try
            {
                request = WebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
                request.Credentials = new NetworkCredential(UserName, Password);
                request.UsePassive = UsePassive;
                request.Timeout = TimeOut;
                request.KeepAlive = KeepAlive;
                WebException webException;
                Debug.WriteLine("proofing directory exists");
                if (!this.DirectoryExits(remoteDirectory, out webException))
                {
                    this.CreateDirectoryRecursive(remoteDirectory, out webException);

                }
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //request.ContentLength = fi.Length - remoteFileSize;

                Debug.WriteLine("starting upload");
                using (Stream requestStream = request.GetRequestStream())
                {
                    using (FileStream fs = File.Open(Path.Combine(localDirectory, localFilename), FileMode.Open))
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        byte[] buffer = new byte[BUFFER_SIZE];
                        int readBytes = 0;
                        do
                        {
                            readBytes = fs.Read(buffer, 0, BUFFER_SIZE);
                            requestStream.Write(buffer, 0, readBytes);
                            if (UploadProgressChanged != null && !_abort)
                            {
                                UploadProgressChanged(this, new UploadProgressChangedLibArgs(fs.Position, fs.Length));
                            }
                            //System.Threading.Thread.Sleep(500);
                        } while (readBytes != 0 && !_abort);
                        totalBytesSend = fs.Length;
                    }
                }
                if (UploadFileCompleted != null && !_abort)
                {
                    var uploadFileCompleteArgs = new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Success);
                    UploadFileCompleted(this, uploadFileCompleteArgs);
                }
            }
            catch (WebException webException)
            {
                if (UploadFileCompleted != null && !_abort)
                {
                    UploadFileCompleted(this, new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Failed, webException));
                }
            }
            catch (Exception exp)
            {
                var webException = exp as WebException;
                if (UploadFileCompleted != null && !_abort)
                {
                    UploadFileCompleted(this, new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Failed, webException));
                }
            }
        }// method

        /// <summary>
        /// Method uploads file to ftpServer | method does not block calling thread 
        /// | file exists on FtpServer => method overrides file
        /// | directory does not exist on FtpServer => directory is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        public void UploadAsync(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            ThreadParameters parameters = new ThreadParameters(localDirectory, localFilename, remoteDirectory, remoteFileName);
            ParameterizedThreadStart pThreadStart = new ParameterizedThreadStart(this.DoUploadAsync);
            _thread = new Thread(pThreadStart);
            _thread.Name = "UploadThread";
            _thread.IsBackground = true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.Start(parameters);
        }// method

        /// <summary>
        /// Method uploads file to FtpServer 
        /// | file exists on FtpServer => method resumes upload (apends file)
        /// | file does not exist on FtpServer => method creates file
        /// | directory does not exist on FtpServer => directory is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UploadResume(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            _abort = false;
            FileInfo fi = new FileInfo(Path.Combine(localDirectory, localFilename));
            long remoteFileSize = 0;
            FtpWebRequest request = null;
            long totalBytesSend = 0;

            request = WebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Timeout = TimeOut;
            request.UsePassive = UsePassive;
            request.KeepAlive = KeepAlive;
            try
            {
                if (this.FileExists(remoteDirectory, remoteFileName, out remoteFileSize))
                {
                    request.Method = WebRequestMethods.Ftp.AppendFile;
                }
                else
                {
                    WebException webException;
                    if (!this.DirectoryExits(remoteDirectory, out webException))
                    {
                        var directoryCreated = this.CreateDirectory(remoteDirectory, out webException);
                    }
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                }
                request.ContentLength = fi.Length - remoteFileSize;
                request.UsePassive = true;

                using (Stream requestStream = request.GetRequestStream())
                {
                    using (FileStream logFileStream = new FileStream(Path.Combine(localDirectory, localFilename), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        StreamReader fs = new StreamReader(logFileStream);

                        fs.BaseStream.Seek(remoteFileSize, SeekOrigin.Begin);
                        byte[] buffer = new byte[BUFFER_SIZE];
                        int readBytes = 0;
                        do
                        {
                            readBytes = fs.BaseStream.Read(buffer, 0, BUFFER_SIZE);
                            requestStream.Write(buffer, 0, readBytes);
                            if (UploadProgressChanged != null && !_abort)
                            {
                                UploadProgressChanged(this, new UploadProgressChangedLibArgs(fs.BaseStream.Position, fs.BaseStream.Length));
                            }
                            //System.Threading.Thread.Sleep(500);
                        } while (readBytes != 0 && !_abort);
                        //_fileStreams.Remove( fs );
                        requestStream.Close();
                        totalBytesSend = fs.BaseStream.Length;
                        fs.Close();
                        logFileStream.Close();
                        Thread.Sleep(100);
                    }
                }
                //Console.WriteLine( "Done" );
                if (UploadFileCompleted != null && !_abort)
                {
                    var uploadFileCompleteArgs = new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Success);
                    UploadFileCompleted(this, uploadFileCompleteArgs);
                }
            }
            catch (WebException webException)
            {
                if (UploadFileCompleted != null && !_abort)
                {
                    UploadFileCompleted(this, new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Failed, webException));
                }
            }
            catch (Exception exp)
            {
                if (UploadFileCompleted != null && !_abort)
                {
                    UploadFileCompleted(this, new UploadFileCompletedEventLibArgs(totalBytesSend, TransmissionState.Failed, exp));
                }
            }

        }

        /// <summary>
        /// Method uploads file to FtpServer
        /// method does not block calling thread
        ///  file exists on FtpServer => method resumes upload
        ///  file does not exist on FtpServer => method creates file
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        public void UploadResumeAsync(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            ThreadParameters parameters = new ThreadParameters(localDirectory, localFilename, remoteDirectory, remoteFileName);
            ParameterizedThreadStart pThreadStart = new ParameterizedThreadStart(this.DoUploadResumeAsync);
            _thread = new Thread(pThreadStart);
            _thread.Name = "UploadThread";
            _thread.IsBackground = true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.Start(parameters);
        }

        /// <summary>
        /// Method downloads file to FtpServer
        /// Method blocks calling thread
        ///  file to download exits on localhost => file is overwritten
        ///  file does not exist on localhost => file is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Download(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            _abort = false;
            var localFile = Path.Combine(localDirectory, localFilename);
            FileInfo file = new FileInfo(localFile);
            FileStream localfileStream = null;
            long totalBytesReceived = 0;
            try
            {
                FtpWebRequest request = FtpWebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
                request.Credentials = new NetworkCredential(UserName, Password);
                request.UsePassive = UsePassive;
                request.Timeout = TimeOut;
                request.KeepAlive = KeepAlive;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                long remoteFileSize = this.GetFileSize(remoteDirectory, remoteFileName);
                localfileStream = new FileStream(localFile, FileMode.Create, FileAccess.Write);

                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                using (Stream ftpStream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                    totalBytesReceived = bytesRead;
                    while (bytesRead != 0 && !_abort)
                    {
                        localfileStream.Write(buffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                        totalBytesReceived += bytesRead;
                        if (DownloadProgressChanged != null && !_abort)
                        {
                            DownloadProgressChanged(this, new DownloadProgressChangedLibArgs(totalBytesReceived, remoteFileSize));
                        }
                    }//while
                    localfileStream.Close();
                }
                if (DownloadFileCompleted != null && !_abort)
                {
                    var downloadFileCompleteArgs = new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Success);
                    DownloadFileCompleted(this, downloadFileCompleteArgs);
                }

            }
            catch (WebException webException)
            {
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
            catch (Exception exp)
            {
                var webException = exp as WebException;
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
            finally
            {
                if (localfileStream != null) localfileStream.Close();
            }
        }
        /*  public void Download(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            _abort = false;
            var localFile = Path.Combine(localDirectory, localFilename);
            FileInfo file = new FileInfo(localFile);
            long totalBytesReceived = 0;
            try
            {
                FtpWebRequest request = FtpWebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
                request.Credentials = new NetworkCredential(UserName, Password);
                request.UsePassive = UsePassive;
                request.Timeout = TimeOut;
                request.KeepAlive = KeepAlive;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                long remoteFileSize = this.GetFileSize(remoteDirectory, remoteFileName);
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                using (FileStream localfileStream = new FileStream(localFile, FileMode.Create, FileAccess.Write))
                {
                    using (Stream ftpStream = response.GetResponseStream())
                    {
                        byte[] buffer = new byte[BUFFER_SIZE];
                        int bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                        totalBytesReceived = bytesRead;
                        while (bytesRead != 0 && !_abort)
                        {
                            localfileStream.Write(buffer, 0, bytesRead);
                            bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                            totalBytesReceived += bytesRead;
                            if (DownloadProgressChanged != null && !_abort)
                            {
                                DownloadProgressChanged(this, new DownloadProgressChangedLibArgs(totalBytesReceived, remoteFileSize));
                            }
                        }
                    }
                }
                if (DownloadFileCompleted != null && !_abort)
                {
                    var downloadFileCompleteArgs = new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Success);
                    DownloadFileCompleted(this, downloadFileCompleteArgs);
                }
            }
            catch (WebException webException)
            {
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
            catch (Exception exp)
            {
                var webException = exp as WebException;
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
        }
        */
        public void DownloadAsync(string Files, string FileToDisk)
        {
            this.DownloadAsync("", FileToDisk, "", Files);
        }

        /// <summary>
        /// Method downloads file to FtpServer
        /// Method does not block calling thread
        ///  file to download exits on localhost => file is overwritten
        ///  file does not exist on localhost => file is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        public void DownloadAsync(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            ThreadParameters parameters = new ThreadParameters(localDirectory, localFilename, remoteDirectory, remoteFileName);
            ParameterizedThreadStart pThreadStart = new ParameterizedThreadStart(this.DoDownloadAsync);
            _thread = new Thread(pThreadStart);
            _thread.Name = "DownloadThread";
            _thread.IsBackground = true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.Start(parameters);
        }// method

        /// <summary>
        /// Method downloads file to FtpServer
        /// Method blocks calling thread
        ///  file to download exits on localhost => file is appended
        ///  file does not exist on localhost => file is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DownloadResume(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            _abort = false;
            var localFile = Path.Combine(localDirectory, localFilename);
            FileInfo file = new FileInfo(localFile);
            FileStream localfileStream = null;
            long totalBytesReceived = 0;
            long localFileSize = 0;
            try
            {
                FtpWebRequest request = FtpWebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
                request.Credentials = new NetworkCredential(UserName, Password);
                request.UsePassive = UsePassive;
                request.Timeout = TimeOut;
                request.KeepAlive = KeepAlive;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                long remoteFileSize = this.GetFileSize(remoteDirectory, remoteFileName);
                if (file.Exists)
                {
                    if (file.Length == remoteFileSize)
                    {
                        if (DownloadFileCompleted != null)
                        {
                            var downloadFileCompleteArgs = new DownloadFileCompletedEventLibArgs(0, TransmissionState.Success);
                            DownloadFileCompleted(this, downloadFileCompleteArgs);
                            return;
                        }
                    }
                    else if (file.Length > remoteFileSize)
                    {
                        if (DownloadFileCompleted != null)
                        {
                            var downloadFileCompleteArgs = new DownloadFileCompletedEventLibArgs(0, TransmissionState.LocalFileBiggerAsRemoteFile);
                            DownloadFileCompleted(this, downloadFileCompleteArgs);
                            return;
                        }
                    }//else if
                    else
                    {
                        localfileStream = new FileStream(localFile, FileMode.Append, FileAccess.Write);
                        request.ContentOffset = file.Length;
                        localFileSize = file.Length;
                    }//else
                }
                else
                {
                    localfileStream = new FileStream(localFile, FileMode.Create, FileAccess.Write);
                }
                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                using (Stream ftpStream = response.GetResponseStream())
                {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                    totalBytesReceived = localFileSize + bytesRead;
                    while (bytesRead != 0 && !_abort)
                    {
                        localfileStream.Write(buffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(buffer, 0, BUFFER_SIZE);
                        totalBytesReceived += bytesRead;
                        if (DownloadProgressChanged != null && !_abort)
                        {
                            DownloadProgressChanged(this, new DownloadProgressChangedLibArgs(totalBytesReceived, remoteFileSize));
                        }
                    }//while
                    localfileStream.Close();
                }
                if (DownloadFileCompleted != null && !_abort)
                {
                    var downloadFileCompleteArgs = new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Success);
                    DownloadFileCompleted(this, downloadFileCompleteArgs);
                }

            }
            catch (WebException webException)
            {
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
            catch (Exception exp)
            {
                var webException = exp as WebException;
                if (DownloadFileCompleted != null && !_abort)
                {
                    DownloadFileCompleted(this, new DownloadFileCompletedEventLibArgs(totalBytesReceived, TransmissionState.Failed, webException));
                }
            }
            finally
            {
                if (localfileStream != null) localfileStream.Close();
            }
        }

        /// <summary>
        /// Method downloads file to FtpServer
        /// Method does not block calling thread
        ///  file to download exits on localhost => file is appended
        ///  file does not exist on localhost => file is created
        /// </summary>
        /// <param name="localDirectory">directory on localhost</param>
        /// <param name="localFilename">filename on localhost</param>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DownloadResumeAsync(string localDirectory, string localFilename, string remoteDirectory, string remoteFileName)
        {
            ThreadParameters parameters = new ThreadParameters(localDirectory, localFilename, remoteDirectory, remoteFileName);
            ParameterizedThreadStart pThreadStart = new ParameterizedThreadStart(this.DoDownloadResumeAsync);
            _thread = new Thread(pThreadStart);
            _thread.Name = "DownloadThread";
            _thread.IsBackground = true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.Start(parameters);
        }

        /// <summary>
        /// Returns true if file exists
        /// | if file does not exist, method returns -1
        /// | dummy method of FileExists
        /// </summary>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        /// <param name="remFileSize">remote fileSize if file exists else -1</param>
        /// <returns>True if file exists else false</returns>
        public bool FileExists(string remoteDirectory, string remoteFileName, out long remFileSize)
        {
            var success = false;
            remFileSize = 0;
            var request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory + "/" + remoteFileName)) as FtpWebRequest;
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Timeout = TimeOut;
            request.UsePassive = true;
            request.KeepAlive = KeepAlive;
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                using (FtpWebResponse response = request.GetResponse() as FtpWebResponse)
                {
                    FileStruct fstruct = new FileStruct();
                    fstruct.Size = long.Parse(response.StatusDescription.Split(' ')[1].Replace("\r", "").Replace("\n", ""));
                    response.Close();
                    
                    remFileSize = fstruct.Size;
                    success = true;
                }
            }
            catch { }
            return success;
        }
        /// <summary>
        /// Returns filesize
        /// | if file does not exist, method returns -1
        /// | dummy method of FileExists
        /// </summary>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="remoteFileName">filename on ftpServer</param>
        /// <returns></returns>
        public long GetFileSize(string remoteDirectory, string remoteFileName)
        {
            long remoteFilesize;
            if (!this.FileExists(remoteDirectory, remoteFileName, out remoteFilesize))
            {
                remoteFilesize = -1;
            }
            return remoteFilesize;
        }
        /// <summary>
        ///  Creates directory recursive
        /// </summary>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="webException">WebException if creating directory fails else WebException is NULL</param>
        /// <returns>true if (sub)directories are created successfull</returns>
        public bool CreateDirectoryRecursive(string remoteDirectory, out WebException webException)
        {
            remoteDirectory = remoteDirectory.Replace("///", "/");
            remoteDirectory = remoteDirectory.Replace("//", "/");

            string[] subDirectories = remoteDirectory.Split("/".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            string subDirectory = string.Empty;
            foreach (var subDirectoryTmp in subDirectories)
            {
                subDirectory += subDirectoryTmp;
                this.CreateDirectory(subDirectory, out webException);
                Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                subDirectory += "/";
            }//foreach
            return this.DirectoryExits(subDirectory, out webException);
        }
        /// <summary>
        ///  Creates directory | method will not create directory tree (subdirectories)
        ///  for creating directory tree use method CreateDirectoryRecursive
        /// </summary>
        /// <param name="remoteDirectory">directory on ftpServer</param>
        /// <param name="webException">WebException if creating directory fails else WebException is NULL</param>
        /// <returns>true if directory is created successfull</returns>
        public bool CreateDirectory(string remoteDirectory, out WebException webException)
        {
            if (UploadProgressChanged != null && !_abort)
            {
                UploadProgressChanged(this, new UploadProgressChangedLibArgs(TransmissionState.CreatingDir));
            }
            webException = null;
            var success = false;
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + _host + ":" + Port + "/" + remoteDirectory));
                request.Credentials = new NetworkCredential(UserName, Password);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Timeout = TimeOut;
                request.UsePassive = UsePassive;
                request.KeepAlive = KeepAlive;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    response.Close();
                }
            }
            catch (WebException exp)
            {
                webException = exp;
            }
            return success;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteDirectory"></param>
        /// <param name="webException"></param>
        /// <returns></returns>
        public bool DirectoryExits(string remoteDirectory, out WebException webException)
        {
            if (UploadProgressChanged != null && !_abort)
            {
                UploadProgressChanged(this, new UploadProgressChangedLibArgs(TransmissionState.ProofingDirExits));
            }
            long remFileSize;
            webException = null;
            var success = FileExists(remoteDirectory, "", out remFileSize);
            return success;
        }
        /// <summary>
        /// Stopps ftp transfer
        /// </summary>
        public void Abort()
        {
            try
            {
                _abort = true;
                _thread.Abort();
            }
            catch { }
        }
        private void DoUploadResumeAsync(object threadParameters)
        {
            try
            {
                ThreadParameters p = threadParameters as ThreadParameters;
                this.UploadResume(p.LocalDirectory, p.LocalFilename, p.RemoteDirectory, p.RemoteFilename);
            }
            catch { }
        }
        private void DoUploadAsync(object threadParameters)
        {
            try
            {
                ThreadParameters p = threadParameters as ThreadParameters;
                this.Upload(p.LocalDirectory, p.LocalFilename, p.RemoteDirectory, p.RemoteFilename);
            }
            catch { }
        }
        private void DoDownloadAsync(object threadParameters)
        {
            try
            {
                ThreadParameters p = threadParameters as ThreadParameters;
                this.Download(p.LocalDirectory, p.LocalFilename, p.RemoteDirectory, p.RemoteFilename);
            }
            catch { }
        }
        private void DoDownloadResumeAsync(object threadParameters)
        {
            try
            {
                ThreadParameters p = threadParameters as ThreadParameters;
                this.DownloadResume(p.LocalDirectory, p.LocalFilename, p.RemoteDirectory, p.RemoteFilename);
            }
            catch { }
        }
        private void SetHost(string host)
        {
            _host = host;
            if (host.ToLower().StartsWith("ftp://"))
            {
                _host = _host.Substring(6);
            }
        }
    }
    public enum TransmissionState
    {
        /// <summary>
        /// Transmission finnished successful
        /// </summary>
        Success,
        /// <summary>
        /// Transmission failed
        /// </summary>
        Failed,
        /// <summary>
        /// You try to resume upload, but file on ftp-server is bigger as your localfile
        /// </summary>
        LocalFileBiggerAsRemoteFile,
        /// <summary>
        /// DotNetFtpLibrary proofs if directory exits
        /// </summary>
        ProofingDirExits,
        /// <summary>
        /// DotNetFtpLibrary is creating (sub)directories
        /// </summary>
        CreatingDir,
        /// <summary>
        /// DotNetFtpLibrary uploads a file to ftp-server
        /// </summary>
        Uploading
    }
    internal static class Procent_
    {

        internal static int Get(long sendBytes, long totalBytes)
        {
            int procent = 0;
            switch (totalBytes)
            {
                case 0:
                    procent = 100;
                    break;
                default:
                    try
                    {
                        procent = (int)((double)sendBytes / (double)totalBytes * 100d);
                    }
                    catch
                    {
                        procent = 0;
                    }
                    break;
            }
            return procent;
        }

    }
    /// <summary>
    /// File details of remote file/directory
    /// </summary>
    public struct FileStruct
    {
        /// <summary>
        /// FLags
        /// </summary>
        public string Flags;
        /// <summary>
        /// Owner
        /// </summary>
        public string Owner;
        /// <summary>
        /// Group
        /// </summary>
        public string Group;
        /// <summary>
        /// True if directory else false
        /// </summary>
        public bool IsDirectory;
        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime;
        /// <summary>
        /// CreateTime stored in a string
        /// </summary>
        public string CreateTimeString;
        /// <summary>
        /// Name of file/directory
        /// </summary>
        public string Name;
        /// <summary>
        /// Size of file
        /// </summary>
        public long Size;
    }
    /// <summary>
    /// Style how ftp server lists directories
    /// </summary>
    internal enum FileListStyle
    {
        UnixStyle,
        WindowsStyle,
        Unknown
    }
    /// <summary>
    /// FTP servers return different dateFormats, depending on 
    /// OS (Windows,Unix..), Culture(USA,Germany..) 
    /// library is tested on Unix(english) Windows(IIS7-german, Filezilla-german)
    /// if library is not able to parse records please send me an example
    /// egon.duerr@gmx.at
    /// </summary>
    internal static class ConvertDate
    {
        internal static bool Parse(string date, string time, out DateTime? dateTime)
        {
            dateTime = null;
            DateTime dateTimeTmp;
            var success = false;
            DateTime.TryParse(date + " " + time, out dateTimeTmp);
            foreach (var cultureInfo in _cultureInfos)
            {
                if (DateTime.TryParse(date + " " + time, out dateTimeTmp))
                {
                    dateTime = dateTimeTmp;
                    success = true;
                    break;
                }
            }//foreach

            if (!success)
            {
                try
                {
                    // could be done in one line
                    // using two lines makes it easy to find exception in parsing, in most cases only one part fails  
                    var dateTimeTmp1 = DateTime.ParseExact(time, "hh:mmtt", CultureInfo.InvariantCulture);
                    var dateTimeTmp2 = DateTime.ParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    var ddd = dateTimeTmp2.ToShortDateString() + " " + dateTimeTmp1.TimeOfDay;
                    dateTime = DateTime.Parse(dateTimeTmp2.ToShortDateString() + " " + dateTimeTmp1.TimeOfDay, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch { }
            }
            return success;
        }

        private static List<CultureInfo> _cultureInfos = new List<CultureInfo>()
        {
            CultureInfo.InvariantCulture,
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo( "ja-JP")
        };

    }
    /// <summary>
    /// Provides information of directory
    /// </summary>
    public class FtpListDirectoryDetails
    {
        /// <summary>
        /// Provides information of directory
        /// </summary>
        public FtpListDirectoryDetails()
        {
        }

        /// <summary>
        /// Parses list of strings to list of FileStruct
        /// </summary>
        /// <param name="ftpRecords">String including information of file/directory</param>
        /// <returns>List of FileStruct</returns>
        public List<FileStruct> Parse(List<string> ftpRecords)
        {
            List<FileStruct> myListArray = new List<FileStruct>();
            //string[] dataRecords = datastring.Split( '\n' );
            //dataRecords[ 0 ] = "-rw-rw-rw- 1 user group 1171 Nov 26 00:43 blue.css\n";
            FileListStyle _directoryListStyle = GuessFileListStyle(ftpRecords);
            foreach (string s in ftpRecords)
            {
                FileStruct f = Parse(s);
                if (!(f.Name == "." || f.Name == ".."))
                {
                    myListArray.Add(f);
                }
            }
            return myListArray;
        }// method

        /// <summary>
        /// Parses string to FileStruct
        /// </summary>
        /// <param name="ftpRecord">String including information of file/directory</param>
        /// <returns>FileStruct</returns>
        public FileStruct Parse(string ftpRecord)
        {
            FileStruct f = new FileStruct();
            FileListStyle _directoryListStyle = GuessFileListStyle(ftpRecord);
            if (_directoryListStyle != FileListStyle.Unknown && ftpRecord != "")
            {
                f.Name = "..";
                switch (_directoryListStyle)
                {
                    case FileListStyle.UnixStyle:
                        f = ParseFileStructFromUnixStyleRecord(ftpRecord);
                        break;
                    case FileListStyle.WindowsStyle:
                        f = ParseFileStructFromWindowsStyleRecord(ftpRecord);
                        break;
                }//switch
            }
            return f;
        }//

        private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
        {
            //Assuming the record style as
            // 02-03-04  07:46PM       <DIR>          Append
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            string[] splitArray = processstr.Split(" \t".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
            string dateStr = splitArray[0];
            processstr = splitArray[1];
            string timeStr = processstr.Substring(0, 7);
            processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
            ConvertDate.Parse(dateStr, timeStr, out f.CreateTime);
            f.CreateTimeString = dateStr + timeStr;
            if (processstr.Substring(0, 5) == "<DIR>")
            {
                f.IsDirectory = true;
                processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
            }
            else
            {
                f.IsDirectory = false;
                string[] strs = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long.TryParse(strs[0].Trim(), out f.Size);
                processstr = strs[1].Trim();
            }
            f.Name = processstr;  //Rest is name   
            return f;
        }

        private FileListStyle GuessFileListStyle(List<string> recordList)
        {
            foreach (string s in recordList)
            {
                return GuessFileListStyle(s);
            }//foreach
            return FileListStyle.Unknown;
        }

        private FileListStyle GuessFileListStyle(string record)
        {
            if (record.Length > 10
             && Regex.IsMatch(record.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
            {
                return FileListStyle.UnixStyle;
            }
            else if (record.Length > 8
             && Regex.IsMatch(record.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
            {
                return FileListStyle.WindowsStyle;
            }
            return FileListStyle.Unknown;
        }

        private FileStruct ParseFileStructFromUnixStyleRecord(string Record)
        {
            //Assuming record style as
            // dr-xr-xr-x   1 owner    group               0 Nov 25  2002 bussys
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            f.Flags = processstr.Substring(0, 9);
            f.IsDirectory = (f.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //skip one part
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            long.TryParse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 0), out f.Size);   //skip one part
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 8));
            f.Name = processstr;   //Rest of the part is name
            return f;
        }

        private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1)).Trim();
            return retString;
        }

    }
    internal class ThreadParameters
    {
        internal string LocalDirectory { get; set; }
        internal string LocalFilename { get; set; }
        internal string RemoteDirectory { get; set; }
        internal string RemoteFilename { get; set; }

        internal ThreadParameters(string localDirectory, string localFileName, string remoteDirectory, string remoteFileName)
        {
            LocalDirectory = localDirectory;
            LocalFilename = localFileName;
            RemoteDirectory = remoteDirectory;
            RemoteFilename = remoteFileName;
        }
    }
    /// <summary>
    /// Provides data for DownloadFileCompleted event
    /// </summary>
    public class DownloadFileCompletedEventLibArgs : EventArgs
    {
        /// <summary>
        /// Get total bytes downloaded
        /// </summary>
        public long TotalBytesReceived { get; private set; }
        /// <summary>
        /// Get TransmissionState of download
        /// </summary>
        public TransmissionState TransmissionState { get; private set; }
        /// <summary>
        /// Get Webexception of download
        /// </summary>
        public WebException WebException { get; private set; }
        /// <summary>
        /// Get Exception of download
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Provides data for DownloadFileCompleted event
        /// </summary>
        /// <param name="totalBytesReceived">Total bytes downloaded</param>
        /// <param name="transmissionState">TransmissionState</param>
        public DownloadFileCompletedEventLibArgs(long totalBytesReceived, TransmissionState transmissionState)
        {
            TotalBytesReceived = totalBytesReceived;
            TransmissionState = transmissionState;
            WebException = null;
            Exception = null;
        }

        /// <summary>
        /// Provides data for DownloadFileChanged event
        /// </summary>
        /// <param name="totalBytesReceived">TotalBytes downloaded</param>
        /// <param name="transmissionState">TransmissionState</param>
        /// <param name="webException">Webexception | Webexception = NULL in case of success</param>
        public DownloadFileCompletedEventLibArgs(long totalBytesReceived, TransmissionState transmissionState, WebException webException)
        {
            TotalBytesReceived = totalBytesReceived;
            TransmissionState = transmissionState;
            WebException = webException;
            Exception = null;
        }

        /// <summary>
        /// Provides data for DownloadFileChanged event
        /// </summary>
        /// <param name="totalBytesReceived">TotalBytes downloaded</param>
        /// <param name="transmissionState">TransmissionState</param>
        /// <param name="exception">Exception | Exception = NULL in case of success</param>
        public DownloadFileCompletedEventLibArgs(long totalBytesReceived, TransmissionState transmissionState, Exception exception)
        {
            TotalBytesReceived = totalBytesReceived;
            TransmissionState = transmissionState;
            WebException = null;
            Exception = exception;
        }

    }
    /// <summary>
    /// Provides data for DownloadFileChanged event
    /// </summary>
    public class DownloadProgressChangedLibArgs : EventArgs
    {
        /// <summary>
        /// Gets bytes downloaded
        /// </summary>
        public long BytesReceived { get; private set; }

        /// <summary>
        /// Gets total bytes downloaded
        /// </summary>
        public long TotalBytesReceived { get; private set; }

        /// <summary>
        /// Gets procent of download 
        /// </summary>
        public int Procent { get; private set; }

        /// <summary>
        /// Provides data for DownloadFileChanged event
        /// </summary>
        /// <param name="bytesReceived">Bytes downloaded</param>
        /// <param name="totalBytesReceived">Total bytes downloaded</param>
        public DownloadProgressChangedLibArgs(long bytesReceived, long totalBytesReceived)
        {
            BytesReceived = bytesReceived;
            TotalBytesReceived = totalBytesReceived;
            Procent = Procent_.Get(bytesReceived, totalBytesReceived);
        }

    }
    /// <summary>
    /// Provides data for UploadFileCompleted event
    /// </summary>
    public class UploadFileCompletedEventLibArgs : EventArgs
    {
        /// <summary>
        /// Gets totalBytes uploaded
        /// </summary>
        public long TotalBytesSend { get; private set; }
        /// <summary>
        /// Gets TransmissionState, e.g. Uploading, CreatingDir..
        /// </summary>
        public TransmissionState TransmissionState { get; set; }
        /// <summary>
        /// Webexception, in case of success Webexception = NULL
        /// </summary>
        public WebException WebException { get; private set; }
        /// <summary>
        /// Exception, in case of success Exception = NULL
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Provides data for UploadFileCompleted event
        /// </summary>
        /// <param name="totalBytesSend">Total bytes uploaded</param>
        /// <param name="transmissionState">State of transmission</param>
        public UploadFileCompletedEventLibArgs(long totalBytesSend, TransmissionState transmissionState)
        {
            TotalBytesSend = totalBytesSend;
            TransmissionState = transmissionState;
            WebException = null;
            Exception = null;
        }

        /// <summary>
        /// Provides data for UploadFileCompleted event
        /// </summary>
        /// <param name="totalBytesSend">Total bytes uploaded</param>
        /// <param name="transmissionState">State of transmission</param>
        /// <param name="webException">Upload failed => Webexception describes error | Upload succeded => Webexception = NULL</param>
        public UploadFileCompletedEventLibArgs(long totalBytesSend, TransmissionState transmissionState, WebException webException)
        {
            TotalBytesSend = totalBytesSend;
            TransmissionState = transmissionState;
            WebException = webException;
            Exception = null;
        }

        /// <summary>
        /// Provides data for UploadFileCompleted event
        /// </summary>
        /// <param name="totalBytesSend"></param>
        /// <param name="transmissionState"></param>
        /// <param name="exception">Upload failed => exception describes error</param>
        public UploadFileCompletedEventLibArgs(long totalBytesSend, TransmissionState transmissionState, Exception exception)
        {
            TotalBytesSend = totalBytesSend;
            TransmissionState = transmissionState;
            WebException = null;
            Exception = exception;
        }

    }
    /// <summary>
    /// Provides data for UploadFileChanged event
    /// </summary>
    public class UploadProgressChangedLibArgs : EventArgs
    {
        /// <summary>
        /// Gets number of bytes send by upload process
        /// </summary>
        public long BytesSent { get; private set; }

        /// <summary>
        /// Gets  total number of bytes send by upload process
        /// </summary>
        public long TotalBytesToSend { get; private set; }

        /// <summary>
        /// Gets procent of upload 
        /// </summary>
        public int Procent { get; private set; }

        /// <summary>
        /// Defines upload state
        /// </summary>
        public TransmissionState TransmissionState { get; private set; }

        /// <summary>
        ///Provides data for UploadFileChanged event 
        /// </summary>
        /// <param name="bytesSend">Bytes uploaded</param>
        /// <param name="totalBytesToSend">Total bytes uploaded</param>
        public UploadProgressChangedLibArgs(long bytesSend, long totalBytesToSend)
        {
            TransmissionState = TransmissionState.Uploading;
            BytesSent = bytesSend;
            TotalBytesToSend = totalBytesToSend;
            Procent = Procent_.Get(bytesSend, totalBytesToSend);
        }

        /// <summary>
        /// Provides data for UploadFileChanged event
        /// </summary>
        /// <param name="transmissionState">TransmissionState e.g. Uploading, CreatingDir..</param>
        public UploadProgressChangedLibArgs(TransmissionState transmissionState)
        {
            TransmissionState = transmissionState;
            BytesSent = 0;
            TotalBytesToSend = 0;
            Procent = 0;
        }

    }
}