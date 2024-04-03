using DMS_BLL.Strategies.PopulationStrategies;
using DMS_Domain.DTOs;
using DMS_Domain.Interfaces.ServiceInterfaces;
using System.IO.Abstractions;

namespace DMS_BLL.Services.TreeNodeServices
{
    public class TreeNodeService : ITreeNodeService
    {
        private readonly ITreeNodePopulationStrategy _treeNodePopulationStrategy;
        private readonly IFileSystemService _fileService;
        private readonly IFileSystem _fileSystem;

        public TreeNodeService(ITreeNodePopulationStrategy treeNodePopulationStrategy,
                               IFileSystemService fileService,IFileSystem fileSystem)
        {
            _treeNodePopulationStrategy = treeNodePopulationStrategy;
            _fileService = fileService;
            _fileSystem = fileSystem;
        }

        public void Populate(string path, List<TreeNodeDTO> nodes)
        {
            var rootDirectoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(path);
            _treeNodePopulationStrategy.Populate(nodes, rootDirectoryInfo);
        }

        public TreeNodeExpansionResultDTO ExpandNodes(string path, bool showHiddenItems)
        {
            var (subDirs, restrictedDirs) = _fileService.GetSubDirectories(path, showHiddenItems);
            var result = new TreeNodeExpansionResultDTO
            {
                SubDirectories = subDirs.ToList(),
                RestrictedDirectories = restrictedDirs
            };

            return result;
        }
    }
}