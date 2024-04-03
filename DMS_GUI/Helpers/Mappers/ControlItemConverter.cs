using DMS_Domain.DTOs;
using DMS_GUI.Helpers.Mappers.Interfaces;

namespace DMS_GUI.Helpers.Mappers
{
    public class ControlItemConverter : IControlItemConverter
    {
        public ListViewItem ConvertToListViewItem(ListItemDTO dto)
        {
            var item = new ListViewItem(dto.PrimaryText);
            foreach (var subItem in dto.SubItems)
            {
                item.SubItems.Add(subItem);
            }
            item.Tag = dto.Tag;
            return item;
        }

        public TreeNode ConvertToTreeNode(TreeNodeDTO dto)
        {
            var node = new TreeNode(dto.Text) { Tag = dto.Tag };
            foreach (var subNode in dto.Children)
            {
                node.Nodes.Add(ConvertToTreeNode(subNode));
            }

            return node;
        }
    }
}