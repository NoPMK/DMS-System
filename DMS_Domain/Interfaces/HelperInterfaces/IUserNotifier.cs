using DMS_Domain.Enums;

namespace DMS_Domain.Interfaces.HelperInterfaces
{
    public interface IUserNotifier
    {
        void ShowMessage(string message, string title, NotificationType type);
        bool ShowQuestion(string message, string title);
    }
}