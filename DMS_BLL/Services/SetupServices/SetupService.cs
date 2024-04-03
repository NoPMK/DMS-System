using DMS_Domain.DTOs;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_BLL.Services.SetupServices
{
    public class SetupService : ISetupService
    {
        private readonly IErrorHandler _errorHandler;
        private readonly ITextHandler _textHandler;
        private readonly IFileSystemValidator _directoryValidator;
        private readonly ITreeNodeService _treeNodeService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IListViewItemCreationService _listViewItemCreationService;
        private readonly IDriveInfoService _driveInfoService;

        public SetupService(IErrorHandler errorHandler,
                            IFileSystemValidator directoryValidator,
                            ITreeNodeService treeNodePopulatorService,
                            IFileSystemService fileSystemService,
                            IListViewItemCreationService listViewItemCreationService,
                            IDriveInfoService driveInfoService,
                            ITextHandler textHandler)
        {
            _errorHandler = errorHandler;
            _directoryValidator = directoryValidator;
            _treeNodeService = treeNodePopulatorService;
            _fileSystemService = fileSystemService;
            _listViewItemCreationService = listViewItemCreationService;
            _driveInfoService = driveInfoService;
            _textHandler = textHandler;
        }

        public List<ListItemDTO> LoadListViewContent(string folderPath, bool showHiddenItems)
        {
            var itemDTOs = new List<ListItemDTO>();

            AddDirectoriesToListView(folderPath, showHiddenItems, itemDTOs);
            AddFilesToListView(folderPath, showHiddenItems, itemDTOs);

            return itemDTOs;
        }

        public string GetDriveDetails(string driveName)
        {
            try
            {
                return _driveInfoService.GetDriveDetails(driveName);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
                return null;
            }
        }

        public IEnumerable<DriveInfo> GetReadyDrives()
        {
            try
            {
                return _driveInfoService.QueryReadyDrives();
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
                return null;
            }
        }

        public DriveInfo GetDrive(string path)
        {
            try
            {
                return _driveInfoService.GetDriveByPath(path);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
                return null;
            }
        }

        public List<TreeNodeDTO> GetTreeNodes(string path)
        {
            var nodeDTOs = new List<TreeNodeDTO>();
            if (!_directoryValidator.DirectoryExists(path))
            {
                return nodeDTOs;
            }

            try
            {
                _treeNodeService.Populate(path, nodeDTOs);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }

            return nodeDTOs;
        }

        private void AddFilesToListView(string folderPath, bool showHiddenItems, List<ListItemDTO> items)
        {
            var files = _fileSystemService.GetFiles(folderPath, showHiddenItems);
            foreach (var file in files)
            {
                var item = _listViewItemCreationService.CreateFileItem(file);
                items.Add(item);
            }
        }

        private void AddDirectoriesToListView(string folderPath, bool showHiddenItems, List<ListItemDTO> items)
        {
            var (subDirs, restrictedDirs) = _fileSystemService.GetSubDirectories(folderPath, showHiddenItems);

            foreach (var dir in subDirs)
            {
                var item = _listViewItemCreationService.CreateDirectoryItem(dir);
                items.Add(item);
            }

            if (restrictedDirs.Any())
            {
                _textHandler.ShowAccessDenied(restrictedDirs.ToList());
            }
        }
    }
}