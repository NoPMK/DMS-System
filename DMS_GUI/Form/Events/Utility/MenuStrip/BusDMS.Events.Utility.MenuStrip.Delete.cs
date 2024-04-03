using DMS_Domain.AppConstants;
using DMS_GUI.Extensions;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - Delete
        private void TryDeleteItem()
        {
            if (State.ActiveListView == null || State.ActiveListView.SelectedItems.Count == 0)
            {
                _textHandler.ShowWarning(Constants.SelectToDelete, "No Item Selected");
                return;
            }

            var itemCount = State.ActiveListView.SelectedItems.Count;

            var confirmResult = _textHandler.ShowQuestion($"Are you sure you want to delete these {itemCount} item(s)?", "Confirm Delete");
            if (confirmResult != true)
            {
                return;
            }

            DeleteSelectedItems();

            RefreshPanels();
        }

        private void DeleteSelectedItems()
        {
            foreach (ListViewItem selectedItem in State.ActiveListView.SelectedItems)
            {
                var currentDirectoryPath = GetCurrentDirectoryPath();
                var itemPath = currentDirectoryPath.CombineWithFileName(selectedItem.Text);

                TryDelete(itemPath);
            }
        }

        private void TryDelete(string itemPath)
        {
            if (_fileSystemValidator.FileExists(itemPath))
            {
                _fileOperations.Delete(itemPath);
            }
            else if (_fileSystemValidator.DirectoryExists(itemPath))
            {
                _folderOperations.Delete(itemPath);
            }
            else
            {
                _textHandler.ShowError(Constants.ItemNotFound + $"{itemPath}", "Error");
            }
        }
    }
}