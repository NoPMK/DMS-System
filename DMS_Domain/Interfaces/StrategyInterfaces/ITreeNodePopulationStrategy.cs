using DMS_Domain.DTOs;
using System.IO.Abstractions;

namespace DMS_BLL.Strategies.PopulationStrategies
{
    public interface ITreeNodePopulationStrategy
    {
        void Populate(List<TreeNodeDTO> nodes, IDirectoryInfo directoryInfo);
    }
}