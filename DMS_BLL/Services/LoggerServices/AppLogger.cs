using DMS_Domain.Args;
using DMS_Domain.Enums;
using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_BLL.Services.LoggerServices
{
    public class AppLogger : IAppLogger
    {
        public event EventHandler<LogMessageEventArgs> MessageLogged;

        public void LogSuccess(string message)
        {
            Log(message, LogMessageType.SUCCESS);
        }

        public void LogInfo(string message)
        {
            Log(message, LogMessageType.INFO);
        }

        public void LogWarning(string message)
        {
            Log(message, LogMessageType.WARNING);
        }

        public void LogError(string message)
        {
            Log(message, LogMessageType.ERROR);
        }

        private void Log(string message, LogMessageType messageType)
        {
            string formattedMessage = $"[{messageType}] {DateTime.Now}: {message}";
            MessageLogged?.Invoke(this, new LogMessageEventArgs(formattedMessage, messageType));
        }
    }
}