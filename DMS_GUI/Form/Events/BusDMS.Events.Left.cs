namespace DMS_GUI
{
    public partial class BusDMS
    {
        // LeftList
        private void LeftList_MouseClick(object sender, MouseEventArgs e)
        {
            State.ActiveListView = LeftList;
            if (e.Button == MouseButtons.Right)
            {
                RightClickMenu.Show(LeftList, e.Location);
            }
        }

        private void LeftList_MouseEnter(object sender, EventArgs e)
        {
            State.ActiveListView = LeftList;
        }

        private void LeftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayListInfo(sender);
        }

        private void LeftList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = LeftList.GetItemAt(e.X, e.Y);
            ProcessListDoubleClick(sender, item);
        }

        private void LeftList_DragEnter(object sender, DragEventArgs e)
        {
            BeginDrag(e);
        }
        private void LeftList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ProcessDrag(sender);
        }

        private void LeftList_DragDrop(object sender, DragEventArgs e)
        {
            EndDrag(sender, e);
        }

        private void LeftList_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDowns(sender, e);
        }

        // LeftPanel FileTree
        private void LeftPanelStructure_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ExpandTreeNode(e);
        }

        private void LeftPanelStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshListOnNodeSelect(e, LeftList);
        }

        // LeftPanel SearchBox
        private void LeftPanelSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchQuery = LeftPanelSearch.Text;
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    SearchTreeView(LeftPanelStructure, searchQuery);
                }
            }
        }

        // LeftTree SearchButton
        private void LeftPanelSearchButton_Click(object sender, EventArgs e)
        {
            var searchQuery = LeftPanelSearch.Text;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                SearchTreeView(LeftPanelStructure, searchQuery);
            }
        }

        // LeftComboBox
        private void LeftPanelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LeftPanelComboBox.SelectedItem != null)
            {
                var selectedDrive = LeftPanelComboBox.SelectedItem.ToString();
                DisplayDriveDetails(selectedDrive, LeftPanelDriveDetails);

                GetStructureTree(LeftPanelComboBox, LeftPanelStructure);
            }
        }

        // LeftPathTextBox
        private void MiddleLeftPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox && e.KeyCode == Keys.Enter)
            {
                var currentFolderPath = State.LeftPanelCurrentFolderPath;
                UpdateListViewFromPath(textBox, LeftList, ref currentFolderPath);
                State.LeftPanelCurrentFolderPath = currentFolderPath;
            }
        }

        // ToggleLeftPanelButton
        private void ToggleLeftPanelButton_Click(object sender, EventArgs e)
        {
            LeftPanel.Panel1Collapsed = !LeftPanel.Panel1Collapsed;

            ToggleLeftPanelButton.Text = LeftPanel.Panel1Collapsed ? "<<" : ">>";
        }
    }
}