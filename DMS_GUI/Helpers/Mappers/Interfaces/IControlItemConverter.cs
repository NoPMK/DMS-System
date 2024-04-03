using DMS_Domain.DTOs;

namespace DMS_GUI.Helpers.Mappers.Interfaces
{
    public interface IControlItemConverter
    {
        ListViewItem ConvertToListViewItem(ListItemDTO dto);
        TreeNode ConvertToTreeNode(TreeNodeDTO dto);
    }
}