namespace DMS_Domain.Interfaces.WrapperInterfaces.FileSystem
{
    public interface IFileInfoWrapper
    {
        FileAttributes Attributes { get; }
        string Name { get; }
        string FullName { get; }
        long Length { get; }
        string Extension { get; }
        DateTime LastWriteTime { get; }
    }
}