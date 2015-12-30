#if UNIX
namespace RC.Framework.Native.Unix.Mono
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    internal class MHelper
    {
        [DllImport("libc")]
        private static extern uint getuid();

        // TODO: Use Mono.Unix instead (it's safer)
        public static bool RunningAsRoot => getuid() == 0;

        public static bool RunningUnderMonoService
        {
            get
            {
                var args = GetArgs();
                return args.Peek().EndsWith("mono-service.exe");
            }
        }
        public static bool RunningOnMono
        {
            get
            {
                Type t = Type.GetType("Mono.Runtime");
                return t != null;
            }
        }
        public static bool RunninOnUnix
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return ((p == 4) || (p == 6) || (p == 128));
            }
        }
        public static bool RunninOnLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return ((p == 4) || (p == 128));
            }
        }
        private static Stack<string> GetArgs()
        {
            return new Stack<string>((Environment.GetCommandLineArgs()).Reverse());
        }

        public static string GetUnparsedCommandLine()
        {
            var args = GetArgs();
            string commandLine = Environment.CommandLine;
            string exeName = args.Peek();

            if (exeName == null) return commandLine;

            // If we are being run under mono-service, strip
            // mono-service.exe + arguments from cmdline.
            // NOTE: mono-service.exe passes itself as first arg.
            if (RunningUnderMonoService)
            {
                commandLine = commandLine.Substring(exeName.Length).TrimStart();
                do
                {
                    args.Pop();
                } while (args.Count > 0 && args.Peek().StartsWith("-"));
                exeName = args.Peek();
            }

            // Now strip real program's executable name from cmdline.

            // Let's try first with a quoted executable..
            var qExeName = "\"" + exeName + "\"";
            commandLine = commandLine.IndexOf(qExeName, StringComparison.Ordinal) > 0 
                ? commandLine.Substring(commandLine.IndexOf(qExeName, StringComparison.Ordinal) + qExeName.Length) 
                : commandLine.Substring(commandLine.IndexOf(exeName, StringComparison.Ordinal) + exeName.Length);
            return (commandLine ?? "").Trim();
        }
    }
}
#endif