// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Direct\\Dir.cs"        //                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.7"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.IO;

namespace Rc.Framework.Direct
{
    /// <summary>
    /// Класс допольнительных инструментов для работы с директориями 
    /// </summary>
    public class Dir
    {
        /// <summary>
        /// Связание путей, для заполнение пустот.
        /// Необходимо для передачи пути через аргументы.
        /// </summary>
        /// <param name="Path"> Путь </param>
        /// <returns> Связанный путь </returns>
        [Obsolete("Use wrap path \'STRING_OF_PATH\'")]
        public static string CompPath(string Path)
        {
            return Path.Replace(' ', '@');
        }
        /// <summary>
        /// Развязка пути, возвращение пустот.
        /// Необходимо для возвращения изначального вида пути пришедшего через аргументы.
        /// </summary>
        /// <param name="CompPath"> Связанный путь </param>
        /// <returns> Развязанный путь </returns>
        /// [Obsolete("Use wrap path \'STRING_OF_PATH\'")]
        public static string UnmpPath(string CompPath)
        {
            return CompPath.Replace('@', ' ');
        }
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
                file.CopyTo(temppath, true);
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
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
