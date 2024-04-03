using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.Operations;
using DMS_Infrastructure.Adapters;
using Interop.DMS_Server;

namespace DMS_Infrastructure.Wrappers.Operations
{
    public class FileOperationsWrapper : OperationWrapperBase, IFileOperationsWrapper
    {
        private readonly IFileOperations _fileOperations;

        public FileOperationsWrapper(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        public void Create(string path)
        {
            _fileOperations.CreateFile(path);
        }

        public void Delete(string path)
        {
            _fileOperations.DeleteFile(path);
        }

        public void Copy(string sourcePath, string destinationPath)
        {
            _fileOperations.CopyFile(sourcePath, destinationPath);
        }

        public void Move(string sourcePath, string destinationPath)
        {
            _fileOperations.MoveFile(sourcePath, destinationPath);
        }

        public void Rename(string sourcePath, string destinationPath)
        {
            _fileOperations.RenameFile(sourcePath, destinationPath);
        }

        public void Read(string path)
        {
            _fileOperations.ReadFile(path);
        }   

        public override void Subscribe(IOperationsEventsAdapter operationsEvents)
        {
            var adapter = new OperationsEventsAdapter(operationsEvents);
            _fileOperations.SubscribeToEvent(adapter);
        }

        public override void Unsubscribe(IOperationsEventsAdapter operationsEvents)
        {
            var adapter = new OperationsEventsAdapter(operationsEvents);
            _fileOperations.UnsubscribeFromEvent(adapter);
        }
    }
}