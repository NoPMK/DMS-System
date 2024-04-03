using DMS_Domain.Args;

namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IAppLogger
    {
        event EventHandler<LogMessageEventArgs> MessageLogged;
        void LogSuccess(string message);
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}