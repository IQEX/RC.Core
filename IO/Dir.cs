// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Direct\\Dir.cs"        //                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="RC.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.7"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace RC.Framework.IO
{
    using System;
    using System.IO;
    /// <summary>
    /// Класс допольнительных инструментов для работы с директориями 
    /// </summary>
    public class RDir
    {
        /// <summary>
        /// Копирование директории
        /// </summary>
        /// <param name="sourceDirName"> Исходное имя директории </param>
        /// <param name="destDirName"> Новое имя деректории </param>
        /// <param name="copySubDirs"> Копирование под-котологов? </param>
        public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, overwrite: true);
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    Copy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        /// <summary>
        /// Безопасное удаление папки
        /// </summary>
        /// <param name="path"></param>
        public static bool TryDelete(string path)
        {
            if (!Directory.Exists(path)) return false;
            try
            {
                Directory.Delete(path, recursive: true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
