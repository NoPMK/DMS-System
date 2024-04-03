using DMS_Domain.AppConstants;
using DMS_GUI.Extensions;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - Rename
        private void TryRenameItem()
        {
            var activeList = State.ActiveListView;

            if (activeList == null || activeList.SelectedItems.Count == 0)
            {
                _textHandler.ShowWarning(Constants.SelectOneToRename, "Rename item");
                return;
            }

            if (activeList.SelectedItems.Count == 1 && activeList.SelectedItems[0] != null)
            {
                activeList.LabelEdit = true;
                activeList.SelectedItems[0].BeginEdit();
            }

            _textHandler.ShowWarning(Constants.SelectOnlyOne, "Rename item");
        }

        private void RenameItem(ListViewItem listViewItem, string fullPath)
        {
            var oldFullPath = listViewItem.Tag.ToString();
            var newName = fullPath.ExtractFileName();

            try
            {
                RenameBasedOnType(listViewItem, fullPath, oldFullPath, newName);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }
        }

        private void RenameBasedOnType(ListViewItem listViewItem, string fullPath, string oldFullPath, string newName)
        {
            if (_fileSystemValidator.FileExists(oldFullPath))
            {
                _fileOperations.Rename(oldFullPath, newName);
            }
            else if (_fileSystemValidator.DirectoryExists(oldFullPath))
            {
                _folderOperations.Rename(oldFullPath, newName);
            }

            listViewItem.Text = newName;
            listViewItem.Tag = fullPath;
        }
    }
}