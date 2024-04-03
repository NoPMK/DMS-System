using DMS_Domain.AppConstants;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - Move
        private void TryMoveItem()
        {
            var activeList = State.ActiveListView;

            if (activeList == null || activeList.SelectedItems.Count == 0)
            {
                _textHandler.ShowWarning(Constants.SelectToMove, "No Item Selected");
                return;
            }

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Choose a folder to move to";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var destinationPath = folderBrowserDialog.SelectedPath;

                    var confirmResult = _textHandler.ShowQuestion(Constants.SureToMove, "Confirm Move");
                    if (confirmResult != true)
                    {
                        return;
                    }

                    MoveSelectedItem(destinationPath);
                }
            }
        }

        private void MoveSelectedItem(string destinationPath)
        {
            foreach (ListViewItem selectedItem in State.ActiveListView.SelectedItems)
            {
                GetDestinationPath(destinationPath, selectedItem, out string sourcePath, out string destination);

                try
                {
                    MoveBasedOnType(sourcePath, destination);
                }
                catch (Exception ex)
                {
                    _errorHandler.HandleError(ex);
                }
            }

            RefreshPanels();
        }

        private void MoveBasedOnType(string sourcePath, string destination)
        {
            if (_fileSystemValidator.FileExists(sourcePath))
            {
                _fileOperations.Move(sourcePath, destination);
            }
            else if (_fileSystemValidator.DirectoryExists(sourcePath))
            {
                _folderOperations.Move(sourcePath, destination);
            }
        }
    }
}