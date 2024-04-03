using DMS_Domain.AppConstants;
using DMS_GUI.Extensions;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - New File
        private void TryCreateFile()
        {
            if (State.ActiveListView == null)
            {
                _textHandler.ShowWarning(Constants.MustSelectFirst, "No Folder Selected");
                return;
            }

            State.IsFile = true;
            NameItem("NewFile.txt", "File");
        }

        private void CreateFile(string filePath)
        {
            try
            {
                _fileOperations.Create(filePath);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }
        }

        // MenuStrip - New Folder
        private void TryCreateFolder()
        {
            if (State.ActiveListView == null)
            {
                _textHandler.ShowWarning(Constants.MustSelectFirst, "No Folder Selected");
                return;
            }

            State.IsFile = false;
            NameItem("NewFolder", "Folder");
        }

        private void CreateFolder(string filePath)
        {
            try
            {
                _folderOperations.Create(filePath);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }
        }

        // MenuStrip - Common for creation
        private void NameItem(string name, string type)
        {
            State.ActiveListView.BeginUpdate();
            UpdateItem(name, type);
            State.ActiveListView.EndUpdate();
        }

        private void UpdateItem(string name, string type)
        {
            var item = new ListViewItem(name) { Name = Constants.Editable, Tag = type };
            State.ActiveListView.Items.Add(item);

            State.ActiveListView.LabelEdit = true;
            item.BeginEdit();
        }

        private void ProcessItemAction(LabelEditEventArgs e, ListView list)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                list.Items.RemoveByKey(Constants.Editable);
                return;
            }

            var fullPath = GetItemFullPath(e, list);

            if (IsEditable(e, list))
            {
                ProcessCreation(e, list, fullPath);
            }
            else
            {
                RenameItem(list.Items[e.Item], fullPath);
            }
        }

        private bool IsEditable(LabelEditEventArgs e, ListView list)
        {
            if (e.Item >= 0 && e.Item < list.Items.Count)
            {
                return list.Items[e.Item].Name == Constants.Editable;
            }
            return false;
        }

        private void ProcessCreation(LabelEditEventArgs e, ListView list, string fullPath)
        {
            var success = CreateBasedOnType(fullPath);
            if (success)
            {
                var editableItem = list.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Name == Constants.Editable);
                if (editableItem != null)
                {
                    UpdateOrCreateListViewItem(e, list, fullPath, editableItem);
                    list.Items.Remove(editableItem);
                }
            }
            else
            {
                list.Items.RemoveAt(e.Item);
            }
        }

        private void UpdateOrCreateListViewItem(LabelEditEventArgs e, ListView list, string fullPath, ListViewItem editableItem)
        {
            if (editableItem != null)
            {
                var newItem = new ListViewItem(e.Label)
                {
                    Tag = fullPath,
                    Name = fullPath,
                    
                };
                list.Items.Add(newItem);
                AddItemWithSystemIcon(newItem, list);
            }
            else
            {
                var item = list.Items[e.Item];
                item = list.Items[e.Item];
                item.Text = fullPath.ExtractFileName();
                item.Tag = fullPath;
            }
        }

        private bool CreateBasedOnType(string fullPath)
        {
            try
            {
                if (State.IsFile)
                {
                    CreateFile(fullPath);
                }
                else
                {
                    CreateFolder(fullPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
                return false;
            }
        }

        private string GetItemFullPath(LabelEditEventArgs e, ListView list)
        {
            var fileName = e.Label;
            var directoryPath = list == LeftList ? State.LeftPanelCurrentFolderPath : State.RightPanelCurrentFolderPath;
            var fullPath = directoryPath.CombineWithFileName(fileName);
            return fullPath;
        }

        private void GetDestinationPath(string destinationPath, ListViewItem selectedItem, out string sourcePath, out string destination)
        {
            sourcePath = selectedItem.Tag.ToString();
            var fileName = sourcePath.ExtractFileName();
            destination = destinationPath.CombineWithFileName(fileName);
        }
    }
}