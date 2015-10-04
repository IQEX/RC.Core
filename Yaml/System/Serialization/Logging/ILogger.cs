using System;

namespace System.YAML.Serialization.Logging
{
    /// <summary>
    /// Logger interface.
    /// </summary>
    public interface ILogger
    {
        void Log(LogLevel level, Exception ex, string message);
    }
}