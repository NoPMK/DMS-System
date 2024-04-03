using DMS_Domain.AppConstants;
using DMS_GUI.Extensions;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Utility
        private void GetStructureTree(ComboBox comboBox, TreeView treeView)
        {
            if (comboBox.SelectedItem != null)
            {
                treeView.Nodes.Clear();

                var selectedDriveRight = comboBox.SelectedItem.ToString().Split(' ')[0];
                PopulateStructureTree(treeView, selectedDriveRight);
            }
        }

        private void DisplayInitialFolderContents(ComboBox comboBox, ListView listView)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
                var selectedDrive = comboBox.Items[0].ToString().Split(' ')[0];
                DisplayFolderContents(selectedDrive, listView);
            }
        }

        private void UpdateInfoDisplay(ListView listView, bool hasParentDirectory)
        {
            var infoTextBox = listView == LeftList ? MiddleLeftInfo : MiddleRightInfo;
            var itemCount = listView.Items.Count - (hasParentDirectory ? 1 : 0);
            infoTextBox.Text = $"Items: {itemCount}";
        }

        private void ExpandTreeNode(TreeViewCancelEventArgs e)
        {
            _logger.LogInfo($"Expanding {e.Node.Text} node");
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "dummy")
            {
                e.Node.Nodes.Clear();
                TryExpandNodes(e);
            }
        }

        private static bool CheckForParentFolder(ListView targetListView, string folderPath)
        {
            var parentDirectoryPath = folderPath.HasParentFolder();

            if (parentDirectoryPath != null)
            {
                var backItem = new ListViewItem(Constants.FolderUp) { Tag = parentDirectoryPath };
                targetListView.Items.Add(backItem);
                return true;
            }

            return false;
        }

        private void UpdateCurrentFolderPath(ListView listView, string folderPath)
        {
            if (listView == LeftList)
            {
                State.LeftPanelCurrentFolderPath = folderPath;
            }
            else if (listView == RightList)
            {
                State.RightPanelCurrentFolderPath = folderPath;
            }
        }

        private (long totalSize, string selectedItemDetails) GetListViewSelectionInfo(ListView listView)
        {
            try
            {
                var totalSize = _calculator.CalculateTotalSize(listView);

                var selectedItemDetails = GetSelectedItemDetails(listView.SelectedItems);

                foreach (var item in listView.SelectedItems)
                {
                    if (listView.Text == Constants.FolderUp) continue;
                }

                return (totalSize, selectedItemDetails);
            }
            catch (ArgumentOutOfRangeException)
            {
                return (0, "");
            }
        }

        private string GetSelectedItemDetails(ListView.SelectedListViewItemCollection selectedItems)
        {
            if (selectedItems.Count == 1)
            {
                return selectedItems[0].Text == Constants.FolderUp ? "" : selectedItems[0].Text;
            }
            else if (selectedItems.Count > 1)
            {
                return $"{selectedItems.Count} items";
            }
            return "";
        }

        private string GetCurrentDirectoryPath()
        {
            var directoryPath = State.ActiveListView == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;
            return directoryPath;
        }

        private void SelectTextBox(string folderPath, ListView targetListView)
        {
            if (!State.UpdatingPathFromTextBox)
            {
                var correspondingTextBox = (targetListView == LeftList) ? MiddleLeftPath : MiddleRightPath;
                correspondingTextBox.Text = folderPath;
            }
        }

        private void RefreshPanels()
        {
            RefreshPanel(LeftPanelComboBox, LeftList);
            RefreshPanel(RightPanelComboBox, RightList);
        }

        private void RefreshPanel(ComboBox comboBox, ListView listView)
        {
            var folderPath = SelectPanel(comboBox, listView);
            DisplayFolderContents(folderPath, listView);
        }

        private string SelectPanel(ComboBox comboBox, ListView listView)
        {
            var folderPath = listView == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = comboBox.SelectedItem.ToString().Split(' ')[0];
            }

            return folderPath;
        }
    }
}