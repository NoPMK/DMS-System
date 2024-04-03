namespace DMS_GUI
{
    public partial class BusDMS
    {
        // MenuStrip - New File
        private void CreateFile_Click(object sender, EventArgs e)
        {
            TryCreateFile();
        }

        // MenuStrip - New Folder
        private void CreateFolder_Click(object sender, EventArgs e)
        {
            TryCreateFolder();
        }

        // MenuStrip - Delete
        private void DeleteStripItem_Click(object sender, EventArgs e)
        {
            TryDeleteItem();
        }

        // MenuStrip - Rename
        private void RenameStripItem_Click(object sender, EventArgs e)
        {
            TryRenameItem();
        }

        // MenuStrip - Move
        private void MoveStripItem_Click(object sender, EventArgs e)
        {
            TryMoveItem();
        }

        // MenuStrip - Copy
        private void CopyStripItem_Click(object sender, EventArgs e)
        {
            TryCopyItem();
        }

        // MenuStrip - Cut
        private void CutStripItem_Click(object sender, EventArgs e)
        {
            TryCutItem();
        }

        // MenuStrip - Paste
        private void PasteStripItem_Click(object sender, EventArgs e)
        {
            TryPasteItem();
        }

        // MenuStrip - View - Hidden Items
        private void ShowHiddenItemsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToggleShoHiddenItems(sender);
        }

        // MenuStrip - View - LargeIcons
        private void LargeIconsViewOption_Click(object sender, EventArgs e)
        {
            ChangeViewToLargeIcons();
        }

        // MenuStrip - View - MediumIcons
        private void SmallIconsViewOption_Click(object sender, EventArgs e)
        {
            ChangeViewToSmallIcons();
        }

        // MenuStrip - View - List
        private void ListViewOption_Click(object sender, EventArgs e)
        {
            ChangeViewToList();
        }

        // MenuStrip - View - Details
        private void DetailsViewOption_Click(object sender, EventArgs e)
        {
            ChangeViewToDetails();
        }

        // On editing name
        private void LeftList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ProcessItemAction(e, State.ActiveListView);
        }

        private void RightList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ProcessItemAction(e, State.ActiveListView);
        }
    }
}