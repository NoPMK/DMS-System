using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_BLL.Services.ErrorHandlerServices
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ITextHandler _textHandler;
        private readonly IAppLogger _logger;

        public ErrorHandler(ITextHandler textHandler, IAppLogger logger)
        {
            _textHandler = textHandler;
            _logger = logger;
        }

        public void HandleError(Exception ex)
        {
            _textHandler.ShowError($"An unexpected error occured: {ex.Message}", "Error");
            _logger.LogError($"An unexpected error occured: {ex.Message}");
        }
    }
}