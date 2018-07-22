#if UNIX
#pragma warning disable 1591
namespace RC.Framework.Native.Unix
{
    using Mono;
    public class Environment
    {
        public string CommandLine => MHelper.GetUnparsedCommandLine();
        public bool IsAdministrator => MHelper.RunningAsRoot;
        public bool IsRunningAsAService => MHelper.RunningUnderMonoService;
        public bool IsServiceInstalled(string serviceName) => MHelper.RunningUnderMonoService;
    }
}
#endif