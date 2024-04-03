namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IOperationsEventsAdapter
    {
        void OnFileCopied(string originalFilePath, string newFilePath);
        void OnFileCreated(string filePath);
        void OnFileDeleted(string filePath);
        void OnFileMoved(string originalFilePath, string newFilePath);
        void OnFileRead(string filePath);
        void OnFileRenamed(string filePath, string newContent);
        void OnFolderCopied(string originalFilePath, string newFilePath);
        void OnFolderCreated(string filePath);
        void OnFolderDeleted(string filePath);
        void OnFolderMoved(string originalFilePath, string newFilePath);
        void OnFolderOpened(string filePath);
        void OnFolderRenamed(string originalFilePath, string newFolderName);
    }
}