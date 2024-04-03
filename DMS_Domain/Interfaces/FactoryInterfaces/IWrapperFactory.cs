using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Domain.Interfaces.FactoryInterfaces
{
    public interface IWrapperFactory
    {
        IDriveInfoWrapper CreateDriveInfoWrapper(string driveName);
        IDirectoryInfoWrapper CreateDirectoryInfoWrapper(string directoryName);
        IFileInfoWrapper CreateFileInfoWrapper(string fileName);
    }
}