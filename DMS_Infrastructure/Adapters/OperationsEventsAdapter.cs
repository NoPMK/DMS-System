using DMS_Domain.Interfaces.ServiceInterfaces;
using Interop.DMS_Server;

namespace DMS_Infrastructure.Adapters
{
    public class OperationsEventsAdapter : IOperationsEvents
    {
        private readonly IOperationsEventsAdapter _operationsEventsAdapter;

        public OperationsEventsAdapter(IOperationsEventsAdapter operationsEventsAdapter)
        {
            _operationsEventsAdapter = operationsEventsAdapter;
        }

        public void OnFileCreated(string filePath)
        {
            _operationsEventsAdapter.OnFileCreated(filePath);
        }

        public void OnFileDeleted(string filePath)
        {
            _operationsEventsAdapter.OnFileDeleted(filePath);
        }

        public void OnFileRead(string filePath)
        {
            _operationsEventsAdapter.OnFileRead(filePath);
        }

        public void OnFileRenamed(string filePath, string newContent)
        {
            _operationsEventsAdapter.OnFileRenamed(filePath, newContent);
        }

        public void OnFileMoved(string originalFilePath, string newFilePath)
        {
            _operationsEventsAdapter.OnFileMoved(originalFilePath, newFilePath);
        }

        public void OnFileCopied(string originalFilePath, string newFilePath)
        {
            _operationsEventsAdapter.OnFileCopied(originalFilePath, newFilePath);
        }

        public void OnFolderCreated(string filePath)
        {
            _operationsEventsAdapter.OnFolderCreated(filePath);
        }

        public void OnFolderDeleted(string filePath)
        {
            _operationsEventsAdapter.OnFolderDeleted(filePath);
        }

        public void OnFolderMoved(string originalFilePath, string newFilePath)
        {
            _operationsEventsAdapter.OnFolderMoved(originalFilePath, newFilePath);
        }

        public void OnFolderRenamed(string originalFilePath, string newFolderName)
        {
            _operationsEventsAdapter.OnFolderRenamed(originalFilePath, newFolderName);
        }

        public void OnFolderOpened(string filePath)
        {
            _operationsEventsAdapter.OnFolderOpened(filePath);
        }

        public void OnFolderCopied(string originalFilePath, string newFilePath)
        {
            _operationsEventsAdapter.OnFolderCopied(originalFilePath, newFilePath);
        }
    }
}