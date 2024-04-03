using DMS_Domain.Enums;

namespace DMS_Domain.Args
{
    public class LogMessageEventArgs : EventArgs
    {
        public string Message { get; }
        public LogMessageType MessageType { get; set; }

        public LogMessageEventArgs(string message, LogMessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}