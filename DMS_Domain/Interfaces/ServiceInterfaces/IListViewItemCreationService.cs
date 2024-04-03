using DMS_Domain.DTOs;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IListViewItemCreationService
    {
        ListItemDTO CreateDirectoryItem(IDirectoryInfoWrapper dirInfo);
        ListItemDTO CreateFileItem(IFileInfoWrapper fileInfo);
    }
}