using DMS_Domain.AppConstants;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        private void TryCutItem()
        {
            if (State.ActiveListView == null || State.ActiveListView.SelectedItems.Count == 0)
            {
                _textHandler.ShowWarning(Constants.SelectToCut, "No Item Selected");
                return;
            }

            var selectedItems = State.ActiveListView.SelectedItems;
            State.CutItems.Clear();

            if (selectedItems.Count > 0)
            {
                State.RightClickSourcePath = State.ActiveListView == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;
            }

            foreach (ListViewItem item in selectedItems)
            {
                State.CutItems.Add(item);
                if (State.IsThemeDark)
                {
                    item.ForeColor = DarkThemeCutForeColor;
                    item.BackColor = DarkThemeCutBackColor;
                }
                else
                {
                    item.ForeColor = LightThemeCutForeColor;
                    item.BackColor = LightThemeCutBackColor;
                }
            }

            PasteStripItem.Enabled = true;
            RightClickPaste.Enabled = true;
        }

        private void TryPasteItem()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Choose a folder to paste to";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var destinationPath = folderBrowserDialog.SelectedPath;

                    var confirmResult = _textHandler.ShowQuestion(Constants.SureToMove, "Confirm Paste");
                    if (confirmResult != true)
                    {
                        return;
                    }

                    PasteSelectedItem(destinationPath);
                }
            }
        }

        private void TryPasteItemOnRightClick(MouseEventArgs e)
        {
            var destinationPath = State.ActiveListView == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;

            var confirmResult = _textHandler.ShowQuestion(Constants.SureToMove, "Confirm Paste");
            if (confirmResult != true)
            {
                return;
            }

            PasteSelectedItem(destinationPath);
        }

        private void PasteSelectedItem(string destinationPath)
        {
            foreach (ListViewItem selectedItem in State.CutItems)
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
            State.CutItems.Clear();
        }
    }
}