namespace DMS_Domain.Interfaces.HelperInterfaces
{
    public interface IFileSystemValidator
    {
        bool CanAccessDirectory(string path);
        bool DirectoryExists(string path);
        bool FileExists(string path);
    }
}