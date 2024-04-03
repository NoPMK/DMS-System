using DMS_Domain.AppConstants;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - Copy
        private void TryCopyItem()
        {
            var activeList = State.ActiveListView;

            if (activeList == null || activeList.SelectedItems.Count == 0)
            {
                _textHandler.ShowWarning(Constants.SelectToCopy, "No Item Selected");
                return;
            }

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Choose a folder to copy to";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var destinationPath = folderBrowserDialog.SelectedPath;
                    CopySelectedItem(destinationPath);
                }
            }
        }

        private void CopySelectedItem(string destinationPath)
        {
            foreach (ListViewItem selectedItem in State.ActiveListView.SelectedItems)
            {
                GetDestinationPath(destinationPath, selectedItem, out string sourcePath, out string destination);

                try
                {
                    CopyBasedOnType(sourcePath, destination);
                   
                }
                catch (Exception ex)
                {
                    _errorHandler.HandleError(ex);
                }
            }
        }

        private void CopyBasedOnType(string sourcePath, string destination)
        {
            if (_fileSystemValidator.FileExists(sourcePath))
            {
                CloseIfOpen(sourcePath);
                _fileOperations.Copy(sourcePath, destination);
            }
            else if (_fileSystemValidator.DirectoryExists(sourcePath))
            {
                _folderOperations.Copy(sourcePath, destination);
            }
        }

        private void CloseIfOpen(string sourcePath)
        {
            using (FileStream stream = File.Open(sourcePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                stream.Close();
            }
        }
    }
}