using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IFileSystemService
    {
        IEnumerable<IDirectoryInfoWrapper> GetDirectories(string folderPath, bool includeHidden);
        IEnumerable<IFileInfoWrapper> GetFiles(string folderPath, bool includeHidden);
        (IEnumerable<IDirectoryInfoWrapper> subDirectories, IEnumerable<string> restrictedDirectories) GetSubDirectories(string path, bool showHiddenItems);
    }
}