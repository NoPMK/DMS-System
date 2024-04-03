using DMS_Domain.Enums;
using DMS_Domain.Interfaces.HelperInterfaces;

namespace DMS_GUI.Services.UserNotificationServices
{
    public class UserNotifier : IUserNotifier
    {
        public void ShowMessage(string message, string header, NotificationType type)
        {
            MessageBoxIcon icon = type switch
            {
                NotificationType.Success => MessageBoxIcon.Information,
                NotificationType.Warning => MessageBoxIcon.Warning,
                NotificationType.Error => MessageBoxIcon.Error,
                NotificationType.Question => MessageBoxIcon.Question,
                _ => MessageBoxIcon.None
            };
            MessageBox.Show(message, header, MessageBoxButtons.OK, icon);
        }

        public bool ShowQuestion(string message, string header)
        {
            var result = MessageBox.Show(message, header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}