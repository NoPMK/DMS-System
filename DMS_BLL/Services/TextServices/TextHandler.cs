using DMS_Domain.Enums;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_BLL.Services.TextServices
{
    public class TextHandler : ITextHandler
    {
        private readonly IAppLogger _logger;
        private readonly IUserNotifier _userNotifier;

        public TextHandler(IAppLogger logger, IUserNotifier userNotifier)
        {
            _logger = logger;
            _userNotifier = userNotifier;
        }

        public void ShowSuccess(string message, string header)
        {
            _userNotifier.ShowMessage(message, header, NotificationType.Success);
            _logger.LogInfo(message);
        }

        public void ShowWarning(string message, string header)
        {
            _userNotifier.ShowMessage(message, header, NotificationType.Warning);
            _logger.LogWarning(message);
        }

        public void ShowError(string message, string header)
        {
            _userNotifier.ShowMessage(message, header, NotificationType.Error);
            _logger.LogError(message);
        }

        public bool ShowQuestion(string message, string header)
        {
            return _userNotifier.ShowQuestion(message, header);
        }

        public void ShowAccessDenied(List<string> items)
        {
            _logger.LogWarning($"Access denied to the following items:\n{string.Join("\n", items)}\n");
        }
    }
}