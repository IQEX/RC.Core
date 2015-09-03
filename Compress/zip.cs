using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;
using Ionic.Zip;
using System.IO;
using System.Windows;
using Rc.Framework.IO;

namespace Rc.Framework.Compress
{
    public delegate void DError(Exception ex);
    public class Zip
    {
        public event EventHandler<ExtractProgressEventArgs> ExtractProgress;
        public event DError ExtractError;
        internal CompressionLevel compress;
        internal Encoding Encod;
        internal bool CoralisPacked(string sourseName, string releseName)
        {
            try
            {
                using (ZipFile zip = new ZipFile(releseName, Encod))
                {
                    zip.Password = "@!!00:00:01:E3:С7:33:B2:7E:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:2C:EC:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:52:2F!!@";
                    zip.Encryption = EncryptionAlgorithm.PkzipWeak;
                    zip.CompressionLevel = compress;
                    zip.TempFileFolder = Path.GetTempPath();
                    zip.AddFile(sourseName, "\\");
                    zip.Save(releseName);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ExtractError != null)
                    ExtractError(ex);
                return false;
            }
        }
        internal bool CoralisDir(string releseName, string DirName)
        {
            try
            {
                string[] filesdir = Directory.GetFiles(DirName);
                using (ZipFile zip = new ZipFile(releseName, Encod))
                {
                    zip.Password = "@!!00:00:01:E3:С7:33:B2:7E:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:2C:EC:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:52:2F!!@";
                    zip.Encryption = EncryptionAlgorithm.PkzipWeak;
                    zip.CompressionLevel = compress;
                    zip.TempFileFolder = Path.GetTempPath();
                    zip.AddItem(DirName);
                    zip.Save(releseName);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ExtractError != null)
                    ExtractError(ex);
                return false;
            }
        }
        internal bool ExtractPacked(string arhName, string directors)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(arhName))
                {
                    zip.ExtractProgress += Zip_ExtractProgress;
                    zip.Password = "@!!00:00:01:E3:С7:33:B2:7E:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:2C:EC:00:7E:2C:00:01:E3:С7:33:B2:EC:52:2F:52:2F!!@";
                    zip.ExtractAll(directors, ExtractExistingFileAction.OverwriteSilently);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ExtractError != null)
                    ExtractError(ex);
                return false;
            }
        }
        private void Zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if(ExtractProgress != null)
            {
                ExtractProgress(sender, e);
            }
        }
    }
}
