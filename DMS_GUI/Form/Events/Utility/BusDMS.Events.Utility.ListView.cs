using DMS_Domain.AppConstants;
using DMS_GUI.Extensions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // ListView
        private void HandleKeyDowns(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ProcessEnterKey(sender);
                    break;

                case Keys.Back:
                    ProcessBackKey();
                    break;

                case Keys.Delete:
                    TryDeleteItem();
                    break;

                case Keys.ControlKey:
                    SwapPanelFocus();
                    break;
            }
        }

        private void ProcessListDoubleClick(object sender, ListViewItem item)
        {
            var listView = sender as ListView;

            if (item != null)
            {
                var folderPath = item.Tag as string;

                if (item.Text == Constants.FolderUp)
                {
                    DisplayFolderContents(folderPath, listView);
                }
            }

            ProcessItemDoubleClick(item);
        }

        private void SwapPanelFocus()
        {
            var nextListView = State.ActiveListView == LeftList ? RightList : LeftList;
            nextListView.Focus();
        }

        private void ProcessEnterKey(object sender)
        {
            var listView = sender as ListView;
            if (listView?.SelectedItems.Count != 0)
            {
                var selectedItem = listView.SelectedItems[0];
                ProcessListDoubleClick(sender, selectedItem);
            }
        }

        private void ProcessBackKey()
        {
            var currentPath = GetCurrentDirectoryPath();
            var parentDirectory = Directory.GetParent(currentPath);

            if (parentDirectory != null)
            {
                DisplayFolderContents(parentDirectory.FullName, State.ActiveListView);
            }
        }

        private void ProcessItemDoubleClick(ListViewItem item)
        {
            if (item != null && item.Tag is string itemPath)
            {
                if (_fileSystemValidator.FileExists(itemPath))
                {
                    ReadFileOrPromptUser(itemPath);
                }
                else if (_fileSystemValidator.DirectoryExists(itemPath))
                {
                    _folderOperations.Open(itemPath);
                }
                else
                {
                    _textHandler.ShowError(Constants.NoItemToDelete + $"{itemPath}", "Error");
                    _logger.LogError(Constants.NoItemToDelete + $"{itemPath}");
                }
            }
        }

        private void ReadFileOrPromptUser(string itemPath)
        {
            try
            {
                _fileOperations.Read(itemPath);
            }
            catch (COMException comEx)
            {
                if (IsSpecialFileType(itemPath))
                {
                    _logger.LogWarning(comEx.Message);
                    OpenSpecialFile(itemPath);
                    return;
                }

                ReadFileWithSelectedApp();
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }
        }

        private void OpenSpecialFile(string itemPath)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Open With...",
                Filter = "Executable Files|*.exe|All Files|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Process.Start(openFileDialog.FileName, "\"" + itemPath + "\"");
            }
        }

        private bool IsSpecialFileType(string itemPath)
        {
            var specialFileTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".dll"
            };

            var extension = itemPath.ExtractExtension();
            return specialFileTypes.Contains(extension);
        }

        private void ReadFileWithSelectedApp()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Open With...",
                Filter = "Executable Files|*.exe|All Files|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Process.Start(dialog.FileName);
            }
        }

        private string GetDestinationPathForListView(ListView targetListView, DragEventArgs e, string originalItemName)
        {
            var point = targetListView.PointToClient(new Point(e.X, e.Y));
            var targetItem = targetListView.GetItemAt(point.X, point.Y);

            return CalculateDestinationPath(targetListView, targetItem, originalItemName);
        }

        private string CalculateDestinationPath(ListView targetListView, ListViewItem targetItem, string originalItemName)
        {
            string destinationDirectory;
            if (targetItem != null && targetItem.Tag is string)
            {
                var targetPath = targetItem.Tag.ToString();
                destinationDirectory = _fileSystemValidator.DirectoryExists(targetPath) ? targetPath : Path.GetDirectoryName(targetPath);
            }
            else
            {
                destinationDirectory = targetListView == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;
            }

            return destinationDirectory.CombineWithFileName(originalItemName);
        }

        private void BeginDrag(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void ProcessDrag(object sender)
        {
            var listView = sender as ListView;
            listView?.DoDragDrop(listView.SelectedItems, DragDropEffects.Move);
        }

        private void EndDrag(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                var targetListView = sender as ListView;
                var items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                foreach (ListViewItem item in items)
                {
                    DragMoveItems(e, targetListView, item);
                }

                RefreshPanels();
            }
        }

        private void DragMoveItems(DragEventArgs e, ListView targetListView, ListViewItem item)
        {
            var sourcePath = item.Tag.ToString();
            var destinationPath = GetDestinationPathForListView(targetListView, e, item.Text);

            var confirmResult = _textHandler.ShowQuestion(Constants.SureToMove, "Confirm Move");
            if (confirmResult != true)
            {
                return;
            }

            if (_fileSystemValidator.FileExists(sourcePath))
            {
                _fileOperations.Move(sourcePath, destinationPath);
            }
            else if (_fileSystemValidator.DirectoryExists(sourcePath))
            {
                _folderOperations.Move(sourcePath, destinationPath);
            }
        }
    }
}