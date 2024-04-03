namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Hidden Items
        private void ToggleShoHiddenItems(object sender)
        {
            var showHidden = sender as ToolStripMenuItem;
            State.ShowHiddenItems = showHidden.Checked;


            _logger.LogInfo($"Show hidden items: {State.ShowHiddenItems}");
            RefreshPanels();
        }

        // Large Icons
        private void ChangeViewToLargeIcons()
        {
            LeftList.View = View.LargeIcon;
            RightList.View = View.LargeIcon;

            _logger.LogInfo($"View changed to Large Icons");

            RefreshPanels();
        }

        // Small Icons
        private void ChangeViewToSmallIcons()
        {
            LeftList.View = View.SmallIcon;
            RightList.View = View.SmallIcon;

            _logger.LogInfo($"View changed to Small Icons");

            RefreshPanels();
        }

        // List
        private void ChangeViewToList()
        {
            LeftList.View = View.List;
            RightList.View = View.List;

            _logger.LogInfo($"View changed to List");

            RefreshPanels();
        }

        // Details
        private void ChangeViewToDetails()
        {
            LeftList.View = View.Details;
            RightList.View = View.Details;

            _logger.LogInfo($"View changed to Details");

            RefreshPanels();
        }
    }
}