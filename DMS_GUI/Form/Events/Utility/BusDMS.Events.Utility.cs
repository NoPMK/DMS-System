using DMS_Domain.AppConstants;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Tree View
        private void RefreshListOnNodeSelect(TreeViewEventArgs e, ListView list)
        {
            if (e.Node?.Tag != null)
            {
                var selectedPath = e.Node.Tag.ToString();
                DisplayFolderContents(selectedPath, list);
            }
        }

        // Path Text Box
        private void UpdateListViewFromPath(TextBox textBox, ListView targetListView, ref string currentFolderPath)
        {
            var newPath = textBox.Text;

            if (_fileSystemValidator.DirectoryExists(newPath))
            {
                currentFolderPath = RefreshListViewWithPath(targetListView, newPath);
            }
            else
            {
                ShowPathError(textBox, ref currentFolderPath);
            }

            textBox.SelectionStart = textBox.Text.Length;
            textBox.SelectionLength = 0;
        }

        private string RefreshListViewWithPath(ListView targetListView, string newPath)
        {
            UpdatePathEditingState(true);
            DisplayFolderContents(newPath, targetListView);
            var currentFolderPath = newPath;
            UpdatePathEditingState(false);
            return currentFolderPath;
        }

        private void UpdatePathEditingState(bool isUpdating)
        {
            State.UpdatingPathFromTextBox = isUpdating;
        }

        private void ShowPathError(TextBox textBox, ref string currentFolderPath)
        {
            _textHandler.ShowError(Constants.InvalidPath, "Error");
            _logger.LogError(Constants.InvalidPath);
            textBox.Text = currentFolderPath;
        }

        private void SearchTreeView(TreeView treeView, string searchQuery)
        {
            var found = false;

            treeView.BeginUpdate();
            treeView.CollapseAll();

            foreach (TreeNode node in treeView.Nodes)
            {
                if (SearchInNode(node, searchQuery, treeView))
                {
                    found = true;
                    break;
                }
            }

            treeView.EndUpdate();

            if (!found)
            {
                _textHandler.ShowError(Constants.ItemNotFound, "Search Results");
                _logger.LogError($"{Constants.ItemNotFound} -> {searchQuery}");
            }
        }

        private bool SearchInNode(TreeNode treeNode, string searchQuery, TreeView treeView)
        {
            if (treeNode.Text.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                ShowResultFound(treeNode, treeView);

                return true;
            }

            // Recursively search in the tree
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (SearchInNode(node, searchQuery, treeView))
                {
                    node.Parent.Expand();
                    return true;
                }
            }

            return false;
        }

        private static void ShowResultFound(TreeNode treeNode, TreeView treeView)
        {
            treeNode.BackColor = SystemColors.Highlight;
            treeNode.ForeColor = SystemColors.HighlightText;

            treeView.SelectedNode = treeNode;
            treeNode.Expand();
            treeView.Focus();
        }
    }
}