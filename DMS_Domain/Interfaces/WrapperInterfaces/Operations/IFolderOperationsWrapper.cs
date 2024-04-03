namespace DMS_Domain.Interfaces.WrapperInterfaces.Operations
{
    public interface IFolderOperationsWrapper : IOperationWrapper
    {
        void Create(string path);
        void Delete(string path);
        void Copy(string sourcePath, string destinationPath);
        void Move(string sourcePath, string destinationPath);
        void Rename(string sourcePath, string destinationPath);
        void Open (string path);
    }
}