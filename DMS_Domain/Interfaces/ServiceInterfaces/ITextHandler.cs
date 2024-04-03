namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface ITextHandler
    {
        void ShowAccessDenied(List<string> items);
        void ShowError(string message, string header);
        bool ShowQuestion(string message, string header);
        void ShowSuccess(string message, string header);
        void ShowWarning(string message, string header);
    }
}