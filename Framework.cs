// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.IO;
using System.Reflection;

namespace Rc.Framework
{
    /// <summary>
    /// основной класс управления фреймворка
    /// </summary>
    public static class Framework
    {
        /// <summary>
        /// Версия
        /// </summary>
        public readonly static string Version = $"{GetInfoFramework().ver.Major}{GetInfoFramework().ver.Minor}{GetInfoFramework().ver.Build}";
        /// <summary>
        /// Получение информации о сборке фреймворка
        /// </summary>
        /// <returns></returns>
        public static RCAssemblyInfo GetInfoFramework()
        {
            Assembly asm = AppDomain.CurrentDomain.Load(File.ReadAllBytes("Rc.Core.dll"));
            RCAssemblyInfo rv = new RCAssemblyInfo();
            AssemblyName name = asm.GetName();
            rv.ver = name.Version;
            rv.CodeBase = name.CodeBase;
            rv.Name = name.FullName;
            rv.ProcArch = name.ProcessorArchitecture;
            return rv;
        }
    }
}

namespace Rc
{
    /// <summary>
    /// class of version framework to rc line
    /// </summary>
    public class RCAssemblyInfo
    {
        /// <summary>
        /// Version
        /// </summary>
        public Version ver;
        /// <summary>
        /// Name
        /// </summary>
        public string Name;
        /// <summary>
        /// CodeBase
        /// </summary>
        public string CodeBase;
        /// <summary>
        /// ProcessorArchitecture
        /// </summary>
        public ProcessorArchitecture ProcArch;
    }
}