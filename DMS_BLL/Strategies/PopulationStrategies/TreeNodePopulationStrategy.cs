using DMS_Domain.DTOs;
using System.IO.Abstractions;

namespace DMS_BLL.Strategies.PopulationStrategies
{
    public class TreeNodePopulationStrategy : ITreeNodePopulationStrategy
    {
        public void Populate(List<TreeNodeDTO> nodes, IDirectoryInfo directoryInfo)
        {
            foreach (var directory in directoryInfo.GetDirectories())
            {
                if ((directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }

                var dirNodeDTO = new TreeNodeDTO(directory.Name)
                {
                    Tag = directory.FullName
                };

                // Optionally add a dummy node to directories to make them expandable
                if (directory.GetDirectories().Any())
                {
                    dirNodeDTO.Children.Add(new TreeNodeDTO("dummy"));
                }

                nodes.Add(dirNodeDTO);
            }
        }
    }
}