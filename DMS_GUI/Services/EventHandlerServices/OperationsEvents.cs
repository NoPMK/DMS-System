using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_GUI.Services.EventHandlerServices
{
    internal class OperationsEvents : IOperationsEventsAdapter
    {
        private readonly BusDMS _form;
        private readonly IAppLogger _logger;

        public OperationsEvents(BusDMS form, IAppLogger logger)
        {
            _form = form;
            _logger = logger;
        }

        public void OnFileCreated(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Created file {filePath} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFileDeleted(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Deleted file {filePath} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFileMoved(string originalFilePath, string newFilePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Moved file {originalFilePath} to {newFilePath}");
            });
        }

        public void OnFileRead(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogInfo($"Read file {filePath}in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFileRenamed(string filePath, string newContent)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Renamed file {filePath} to {newContent} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFileCopied(string originalFilePath, string newFilePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _form.DisplayFolderContents(newFilePath, _form.State.ActiveListView);
                _logger.LogSuccess($"Copied file {originalFilePath} to {newFilePath}");
            });
        }

        public void OnFolderCreated(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Created folder {filePath} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFolderDeleted(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Deleted folder {filePath} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFolderMoved(string originalFilePath, string newFilePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Moved folder {originalFilePath} to {newFilePath}");
            });
        }

        public void OnFolderOpened(string filePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _form.DisplayFolderContents(filePath, _form.State.ActiveListView);
                _logger.LogInfo($"Opened folder {filePath} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFolderRenamed(string originalFilePath, string newFolderName)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _logger.LogSuccess($"Renamed folder {originalFilePath} to {newFolderName} in {_form.State.ActiveListView.Name}");
            });
        }

        public void OnFolderCopied(string originalFilePath, string newFilePath)
        {
            _form.Invoke((MethodInvoker)delegate
            {
                _form.DisplayFolderContents(newFilePath, _form.State.ActiveListView);
                _logger.LogSuccess($"Copied folder {originalFilePath} to {newFilePath}");
            });
        }
    }
}