using DMS_Domain.DTOs;
using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_BLL.Services.ListViewServices
{
    public class ListViewItemCreationService : IListViewItemCreationService
    {
        public ListItemDTO CreateDirectoryItem(IDirectoryInfoWrapper dirInfo)
        {
            return new ListItemDTO(
                dirInfo.Name,
                new[] { "", "<DIR>", dirInfo.LastWriteTime.ToString() },
                dirInfo.FullName,
                dirInfo.LastWriteTime.ToString());
        }

        public ListItemDTO CreateFileItem(IFileInfoWrapper fileInfo)
        {
            return new ListItemDTO(
                fileInfo.Name,
                new[] { fileInfo.Extension, fileInfo.Length.ToString(), fileInfo.LastWriteTime.ToString() },
                fileInfo.FullName,
                fileInfo.LastWriteTime.ToString());
        }
    }
}