// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\IO\\ExLogging.cs"      //                Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.3"                   //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Rc.Framework.IO
{
    public class Log
    {
        public readonly Dictionary<string, string> Path = new Dictionary<string, string>();
        public void AppendConfig(string Type, string Path)
        {
            this.Path.Add(Type, Path);
        }
        public void Write(string Type, string str)
        {
            StringBuilder b = new StringBuilder();
            b.Append($"[{DateTime.Now.ToString("s")}] ");
            b.Append(str);
            b.Append("\n");
            File.AppendAllText(Path[Type], b.ToString());
        }
    }
    [Obsolete("This Class is Obsolete, use Rc.Framework.IO.Log")]
    public class ExLogging
    {
        public static void WriteToXl(Exception ex)
        {
            int i = 0;
            while (File.Exists(string.Format("EngineError_{0}.xs", i))) i++;
            File.AppendAllText(string.Format("EngineError_{0}.xs", i), ex.ToString());
        }
    }
}
