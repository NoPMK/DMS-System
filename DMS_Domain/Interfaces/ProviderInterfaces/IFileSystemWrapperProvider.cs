using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Domain.Interfaces.ProviderInterfaces
{
    public interface IFileSystemWrapperProvider
    {
        IDirectoryInfoWrapper CreateDirectoryInfo(string path);
        IDriveInfoWrapper CreateDriveInfo(string driveName);
        IFileInfoWrapper CreateFileInfo(string path);
    }
}