// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2016  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.IO;
using System.Reflection;

namespace RC.Framework
{
    /// <summary>
    /// основной класс управления фреймворка
    /// </summary>
    public static class Framework
    {
        /// <summary>
        /// Версия
        /// </summary>
        public static readonly string Version = $"{GetInfoFramework().ver.Major}.{GetInfoFramework().ver.Minor}.{GetInfoFramework().ver.Build}.{GetInfoFramework().ver.Revision}";
        /// <summary>
        /// Получение информации о сборке фреймворка
        /// </summary>
        /// <returns></returns>
        public static RCAssemblyInfo GetInfoFramework()
        {
            if(!File.Exists(Environment.CurrentDirectory + "\\Rc.Core.dll"))
            {
                RCAssemblyInfo rc = new RCAssemblyInfo
                {
                    CodeBase = "null",
                    Name = "Rc.Core",
                    ProcArch = ProcessorArchitecture.Amd64,
                    ver = new System.Version(10, 0, 15200, 0)
                };
#if !x32
#else
                rc.ProcArch = ProcessorArchitecture.X86;
#endif
                return rc;
            }
            Assembly asm = AppDomain.CurrentDomain.Load(File.ReadAllBytes(Environment.CurrentDirectory + "\\Rc.Core.dll"));
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

namespace RC
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