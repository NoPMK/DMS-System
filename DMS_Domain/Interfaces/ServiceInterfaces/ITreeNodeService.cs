using DMS_Domain.DTOs;

namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface ITreeNodeService
    {
        TreeNodeExpansionResultDTO ExpandNodes(string path, bool showHiddenItems);
        void Populate(string path, List<TreeNodeDTO> nodes);
    }
}