using DMS_Domain.AppConstants;
using DMS_Domain.DTOs;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Display
        public void DisplayFolderContents(string folderPath, ListView targetListView)
        {
            var items = _setupService.LoadListViewContent(folderPath, State.ShowHiddenItems);
            targetListView.Items.Clear();

            var hasParentDirectory = CheckForParentFolder(targetListView, folderPath);

            AddIconsAndItems(targetListView, items);

            SelectTextBox(folderPath, targetListView);

            UpdateCurrentFolderPath(targetListView, folderPath);
            UpdateInfoDisplay(targetListView, hasParentDirectory);
        }

        private void AddIconsAndItems(ListView targetListView, List<ListItemDTO> itemDTOs)
        {
            SetSmallImageList(targetListView);
            SetLargeImageList(targetListView);

            foreach (var dto in itemDTOs)
            {
                var item = _controlItemConverter.ConvertToListViewItem(dto);
                AddItemWithSystemIcon(item, targetListView);
                targetListView.Items.Add(item);
            }
        }

        private static void SetLargeImageList(ListView targetListView)
        {
            if (targetListView.LargeImageList == null)
            {
                targetListView.LargeImageList = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(32, 32)
                };
            }
        }

        private static void SetSmallImageList(ListView targetListView)
        {
            if (targetListView.SmallImageList == null)
            {
                targetListView.SmallImageList = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };
            }
        }

        private void TryExpandNodes(TreeViewCancelEventArgs e)
        {
            try
            {
                var path = e.Node?.Tag.ToString();
                var expansionResult = _treeNodeService.ExpandNodes(path, State.ShowHiddenItems);

                GetSubNodes(e, expansionResult);

                if (expansionResult.RestrictedDirectories.Any())
                {
                    _textHandler.ShowAccessDenied(expansionResult.RestrictedDirectories.ToList());
                }
            }
            catch (Exception ex)
            {
                _errorHandler.HandleError(ex);
            }
        }

        private static void GetSubNodes(TreeViewCancelEventArgs e, TreeNodeExpansionResultDTO expansionResult)
        {
            foreach (var dir in expansionResult.SubDirectories)
            {
                var newNode = new TreeNode(dir.Name) { Tag = dir.FullName };
                e.Node?.Nodes.Add(newNode);

                if (dir.GetDirectories().Any())
                {
                    newNode.Nodes.Add("dummy");
                }
            }
        }

        private void DisplayDriveDetails(string driveName, Control targetControl)
        {
            var driveDetails = _setupService.GetDriveDetails(driveName);
            targetControl.Text = driveDetails;
        }

        private void DisplayListInfo(object sender)
        {
            if (sender is ListView listView)
            {
                var info = GetListViewSelectionInfo(listView);
                var infoTextBox = (listView == LeftList) ? MiddleLeftInfo : MiddleRightInfo;

                var totalSizeDisplay = info.totalSize == 0 ? " - " : _formatter.FormatBytes(info.totalSize);
                var itemTotalCount = listView.Items.Count - listView.Items.Cast<ListViewItem>().Count(item => item.Text == Constants.FolderUp);

                infoTextBox.Text = $"Items: {itemTotalCount}  |  " +
                                   $"Total Size: {totalSizeDisplay}  |  " +
                                   $"Selected: {info.selectedItemDetails}";
            }
        }
    }
}