using DMS_Domain.DTOs;

namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface ISetupService
    {
        List<ListItemDTO> LoadListViewContent(string folderPath, bool showHiddenItems);
        string GetDriveDetails(string driveName);
        List<TreeNodeDTO> GetTreeNodes(string path);
        IEnumerable<DriveInfo> GetReadyDrives();
        DriveInfo GetDrive(string path);
    }
}