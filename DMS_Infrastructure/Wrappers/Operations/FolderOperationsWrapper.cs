using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.Operations;
using DMS_Infrastructure.Adapters;
using Interop.DMS_Server;

namespace DMS_Infrastructure.Wrappers.Operations
{
    public class FolderOperationsWrapper : OperationWrapperBase, IFolderOperationsWrapper
    {
        private readonly IFolderOperations _folderOperations;

        public FolderOperationsWrapper(IFolderOperations folderOperations)
        {
            _folderOperations = folderOperations;
        }

        public void Create(string path)
        {
            _folderOperations.CreateFolder(path);
        }

        public void Delete(string path)
        {
            _folderOperations.DeleteFolder(path);
        }

        public void Copy(string sourcePath, string destinationPath)
        {
            _folderOperations.CopyFolder(sourcePath, destinationPath);
        }

        public void Move(string sourcePath, string destinationPath)
        {
            _folderOperations.MoveFolder(sourcePath, destinationPath);
        }

        public void Rename(string sourcePath, string destinationPath)
        {
            _folderOperations.RenameFolder(sourcePath, destinationPath);
        }

        public void Open(string path)
        {
            _folderOperations.OpenFolder(path);
        }

        public override void Subscribe(IOperationsEventsAdapter operationsEvents)
        {
            var adapter = new OperationsEventsAdapter(operationsEvents);
            _folderOperations.SubscribeToEvent(adapter);
        }

        public override void Unsubscribe(IOperationsEventsAdapter operationsEvents)
        {
            var adapter = new OperationsEventsAdapter(operationsEvents);
            _folderOperations.UnsubscribeFromEvent(adapter);
        }
    }
}