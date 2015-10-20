// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\IO\\ExLogging.cs"      //                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.7"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Rc.Framework.IO
{
    /// <summary>
    /// Перечесление стандартных типов лога
    /// </summary>
    public enum TypeLog
    {
        /// <summary>
        /// Лог системы
        /// </summary>
        System,
        /// <summary>
        /// Лог Ядра
        /// </summary>
        Core,
        /// <summary>
        /// Лог Сети
        /// </summary>
        Network
    }

    /// <summary>
    /// Класс логирования
    /// </summary>
    public class Log
    {
        private string BasePath;
        private readonly Dictionary<string, string> Path = new Dictionary<string, string>();
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="basePath">Базовый путь для стандартный файлов лога</param>
        public Log(string basePath)
        {
            this.BasePath = basePath;
            foreach(string e in Enum.GetNames(typeof(TypeLog)))
            {
                this.Path.Add(e, $"{BasePath}\\{e}.log");
            }
        }
        /// <summary>
        /// Установка конфигурации логирования
        /// </summary>
        /// <param name="Type">Собственный тип лога</param>
        /// <param name="Path">Путь до файла</param>
        public void AppendConfig(string Type, string Path)
        {
            this.Path.Add(Type, Path);
        }
        /// <summary>
        /// Запись в лог по собственной конфигурации, с определением метода и номера строки кода
        /// </summary>
        /// <param name="Type">Тип конфигурации</param>
        /// <param name="str">Текст лога</param>
        /// <param name="member">don't touch, this auto generated</param>
        /// <param name="line">don't touch, this auto generated</param>
        public void Write(string Type, string str, [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            StringBuilder b = new StringBuilder();
            b.Append($"[{member}:{line}({DateTime.Now})]: ");
            b.Append(str.Replace('\n', ','));
            b.Append("\n");
            File.AppendAllText(Path[Type], b.ToString());
        }
        /// <summary>
        /// Запись в лог по стандартной конфигурации
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="str"></param>
        public void Write(TypeLog Type, string str)
        {
            StringBuilder b = new StringBuilder();
            b.Append($"[{DateTime.Now.ToString("s")}] ");
            b.Append(str.Replace('\n', ','));
            b.Append("\n");
            File.AppendAllText(Path[Type.ToString()], b.ToString());
        }
        /// <summary>
        /// Запись в лог по стандартной конфигурации, с определением метода и номера строки кода
        /// </summary>
        /// <param name="Type">Тип конфигурации</param>
        /// <param name="str">Текст лога</param>
        /// <param name="member">don't touch, this auto generated</param>
        /// <param name="line">don't touch, this auto generated</param>
        public void Write(TypeLog Type, string str, [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            StringBuilder b = new StringBuilder();
            b.Append($"[{member}:{line}({DateTime.Now})]: ");
            b.Append(str.Replace('\n', ','));
            b.Append("\n");
            File.AppendAllText(Path[Type.ToString()], b.ToString());
        }
    }
}
