using System.ComponentModel;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // RightClick
        private void RightClickMenu_Opening(object sender, CancelEventArgs e)
        {
            if (State.CutItems.Count > 0)
            {
                State.RightClickSourcePath = State.CutItems[0].Tag.ToString();
            }
        }

        private void RightClickCreateFile_Click(object sender, EventArgs e)
        {
            TryCreateFile();
        }

        private void RightClickCreateFolder_Click(object sender, EventArgs e)
        {
            TryCreateFolder();
        }

        private void RightClickRename_Click(object sender, EventArgs e)
        {
            TryRenameItem();
        }

        private void RightClickCopy_Click(object sender, EventArgs e)
        {
            TryCopyItem();
        }

        private void RightClickMove_Click(object sender, EventArgs e)
        {
            TryMoveItem();
        }

        private void RightClickDelete_Click(object sender, EventArgs e)
        {
            TryDeleteItem();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryCutItem();
        }

        private void RightClickPaste_MouseDown(object sender, MouseEventArgs e)
        {
            TryPasteItemOnRightClick(e);
        }
    }
}