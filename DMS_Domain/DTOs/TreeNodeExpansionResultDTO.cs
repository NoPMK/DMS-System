using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Domain.DTOs
{
    public class TreeNodeExpansionResultDTO
    {
        public List<IDirectoryInfoWrapper> SubDirectories { get; set; } = new List<IDirectoryInfoWrapper>();
        public IEnumerable<string> RestrictedDirectories { get; set; } = new List<string>();
    }
}