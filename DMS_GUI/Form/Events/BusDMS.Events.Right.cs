namespace DMS_GUI
{
    public partial class BusDMS
    {
        // RightList
        private void RightList_MouseClick(object sender, MouseEventArgs e)
        {
            State.ActiveListView = RightList;
            if (e.Button == MouseButtons.Right)
            {
                RightClickMenu.Show(RightList, e.Location);
            }
        }

        private void RightList_MouseEnter(object sender, EventArgs e)
        {
            State.ActiveListView = RightList;
        }

        private void RightList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayListInfo(sender);
        }

        private void RightList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = RightList.GetItemAt(e.X, e.Y);
            ProcessListDoubleClick(sender, item);
        }

        private void RightList_DragEnter(object sender, DragEventArgs e)
        {
            BeginDrag(e);
        }
        private void RightList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ProcessDrag(sender);
        }

        private void RightList_DragDrop(object sender, DragEventArgs e)
        {
            EndDrag(sender, e);
        }

        private void RightList_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDowns(sender, e);
        }

        // RightPanel FileTree
        private void RightPanelStructure_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ExpandTreeNode(e);
        }

        private void RightPanelStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshListOnNodeSelect(e, RightList);
        }

        // RightPanel SearchBox
        private void RightPanelSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchQuery = RightPanelSearch.Text;
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    SearchTreeView(RightPanelStructure, searchQuery);
                }
            }
        }

        // RightTree SearchButton
        private void RigthPanelSearchButton_Click(object sender, EventArgs e)
        {
            var searchQuery = RightPanelSearch.Text;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                SearchTreeView(RightPanelStructure, searchQuery);
            }
        }

        // RightComboBox
        private void RightPanelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RightPanelComboBox.SelectedItem != null)
            {
                var selectedDrive = RightPanelComboBox.SelectedItem.ToString();
                DisplayDriveDetails(selectedDrive, RightPanelDriveDetails);

                GetStructureTree(RightPanelComboBox, RightPanelStructure);
            }
        }

        // RightPathTextBox
        private void MiddleRightPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox && e.KeyCode == Keys.Enter)
            {
                var currentFolderPath = State.RightPanelCurrentFolderPath;
                UpdateListViewFromPath(textBox, RightList, ref currentFolderPath);
                State.RightPanelCurrentFolderPath = currentFolderPath;
            }
        }

        // ToggleRightPanelButton
        private void ToggleRightPanelButton_Click(object sender, EventArgs e)
        {
            RightPanel.Panel2Collapsed = !RightPanel.Panel2Collapsed;

            ToggleRightPanelButton.Text = RightPanel.Panel2Collapsed ? ">>" : "<<";
        }
    }
}