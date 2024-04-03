namespace DMS_Domain.Interfaces.WrapperInterfaces.FileSystem
{
    public interface IDirectoryInfoWrapper
    {
        FileAttributes Attributes { get; }
        string FullName { get; }
        string Name { get; }
        DateTime LastWriteTime { get; }

        IEnumerable<IDirectoryInfoWrapper> GetDirectories();
        IEnumerable<IFileInfoWrapper> GetFiles();
    }
}