// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Runtime.CompilerServices;
namespace RC.Framework.IO
{
    /// <summary>
    /// interface <see cref="Log"/>.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Append config path.
        /// </summary>
        /// <param name="Type">Type config log.</param>
        /// <param name="Path">Url to file log.</param>
        void AppendConfig(string Type, string Path);
        /// <summary>
        /// Write to system log.
        /// </summary>
        /// <param name="Type">System log.</param>
        /// <param name="str">Message.</param>
        void Write(TypeLog Type, string str);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="str"></param>
        /// <param name="member"></param>
        /// <param name="line"></param>
        void Write(TypeLog Type, string str, [CallerMemberName] string member = "", [CallerLineNumber] int line = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="str"></param>
        /// <param name="member"></param>
        /// <param name="line"></param>
        void Write(string Type, string str, [CallerMemberName] string member = "", [CallerLineNumber] int line = 0);
    }
}