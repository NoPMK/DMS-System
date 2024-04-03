namespace DMS_GUI
{
    public partial class BusDMS
    {
        private readonly Color DarkThemeForeColor = Color.Azure;
        private readonly Color DarkThemeBackgroundColor = Color.FromArgb(30, 30, 30);
        private readonly Color DarkThemeCutForeColor = Color.FromArgb(246, 246, 246);
        private readonly Color DarkThemeCutBackColor = Color.FromArgb(70, 70, 70);
        private readonly Color DarkThemeFieldColor = Color.FromArgb(45, 45, 48);

        private void SetRightPanelToDark()
        {
            RightPanel.BackColor = DarkThemeBackgroundColor;

            RightPanelSearch.BackColor = DarkThemeFieldColor;
            RightPanelSearch.ForeColor = DarkThemeForeColor;

            RightPanelSearchButton.BackColor = DarkThemeBackgroundColor;
            RightPanelSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-search.png");

            RightPanelComboBox.BackColor = DarkThemeFieldColor;
            RightPanelComboBox.ForeColor = DarkThemeForeColor;

            RightPanelDriveDetails.BackColor = DarkThemeBackgroundColor;
            RightPanelDriveDetails.ForeColor = DarkThemeForeColor;

            RightPanelStructure.BackColor = DarkThemeFieldColor;
            RightPanelStructure.ForeColor = DarkThemeForeColor;
        }

        private void SetMenuStripToDark()
        {
            MainMenuStrip.BackColor = DarkThemeBackgroundColor;

            FileStripItem.BackColor = DarkThemeBackgroundColor;
            FileStripItem.ForeColor = DarkThemeForeColor;
            FileStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-file.png");

            NewToolStripItem.BackColor = DarkThemeBackgroundColor;
            NewToolStripItem.ForeColor = DarkThemeForeColor;

            CreateNewFile.BackColor = DarkThemeBackgroundColor;
            CreateNewFile.ForeColor = DarkThemeForeColor;

            CreateNewFolder.BackColor = DarkThemeBackgroundColor;
            CreateNewFolder.ForeColor = DarkThemeForeColor;

            ViewStripItem.BackColor = DarkThemeBackgroundColor;
            ViewStripItem.ForeColor = DarkThemeForeColor;
            ViewStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-view.png");

            LargeIconsToolStripMenuItem.BackColor = DarkThemeBackgroundColor;
            LargeIconsToolStripMenuItem.ForeColor = DarkThemeForeColor;

            SmallIconsViewOption.BackColor = DarkThemeBackgroundColor;
            SmallIconsViewOption.ForeColor = DarkThemeForeColor;

            ListViewOption.BackColor = DarkThemeBackgroundColor;
            ListViewOption.ForeColor = DarkThemeForeColor;

            DetailsViewOption.BackColor = DarkThemeBackgroundColor;
            DetailsViewOption.ForeColor = DarkThemeForeColor;

            ShowHiddenItemsToolStripMenuItem.BackColor = DarkThemeBackgroundColor;
            ShowHiddenItemsToolStripMenuItem.ForeColor = DarkThemeForeColor;

            StripDivider.BackColor = DarkThemeBackgroundColor;
            StripDivider.ForeColor = DarkThemeForeColor;

            RenameStripItem.BackColor = DarkThemeBackgroundColor;
            RenameStripItem.ForeColor = DarkThemeForeColor;
            RenameStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-rename.png");

            CutStripItem.BackColor = DarkThemeBackgroundColor;
            CutStripItem.ForeColor = DarkThemeForeColor;
            State.CutItems.ForEach(item => item.ForeColor = DarkThemeCutForeColor);
            State.CutItems.ForEach(item => item.BackColor = DarkThemeCutBackColor);
            CutStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-cut.png");

            PasteStripItem.BackColor = DarkThemeBackgroundColor;
            PasteStripItem.ForeColor = DarkThemeForeColor;
            PasteStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-paste.png");

            CopyStripItem.BackColor = DarkThemeBackgroundColor;
            CopyStripItem.ForeColor = DarkThemeForeColor;
            CopyStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-copy.png");

            MoveStripItem.BackColor = DarkThemeBackgroundColor;
            MoveStripItem.ForeColor = DarkThemeForeColor;
            MoveStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-move.png");

            DeleteStripItem.BackColor = DarkThemeBackgroundColor;
            DeleteStripItem.ForeColor = DarkThemeForeColor;
            DeleteStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-delete.png");
        }

        private void SetMiddlePanelToDark()
        {
            MiddleVerticalPanel.BackColor = DarkThemeBackgroundColor;
            MiddleVerticalPanel.Panel1.BackColor = DarkThemeBackgroundColor;

            ToggleLeftPanelButton.BackColor = DarkThemeBackgroundColor;
            ToggleLeftPanelButton.ForeColor = DarkThemeForeColor;

            ToggleRightPanelButton.BackColor = DarkThemeBackgroundColor;
            ToggleRightPanelButton.ForeColor = DarkThemeForeColor;

            MiddleLeftPath.BackColor = DarkThemeFieldColor;
            MiddleLeftPath.ForeColor = DarkThemeForeColor;

            MiddleRightPath.BackColor = DarkThemeFieldColor;
            MiddleRightPath.ForeColor = DarkThemeForeColor;

            LeftList.BackColor = DarkThemeFieldColor;
            LeftList.ForeColor = DarkThemeForeColor;

            RightList.BackColor = DarkThemeFieldColor;
            RightList.ForeColor = DarkThemeForeColor;

            MiddleLeftInfo.BackColor = DarkThemeBackgroundColor;
            MiddleLeftInfo.ForeColor = DarkThemeForeColor;

            MiddleRightInfo.BackColor = DarkThemeBackgroundColor;
            MiddleRightInfo.ForeColor = DarkThemeForeColor;

            ThemeSwitcher.BackColor = DarkThemeBackgroundColor;
        }

        private void SetLeftPanelToDark()
        {
            LeftPanel.BackColor = DarkThemeBackgroundColor;

            LeftPanelSearch.BackColor = DarkThemeFieldColor;
            LeftPanelSearch.ForeColor = DarkThemeForeColor;

            LeftPanelSearchButton.BackColor = DarkThemeBackgroundColor;
            LeftPanelSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-search.png");

            LeftPanelComboBox.BackColor = DarkThemeFieldColor;
            LeftPanelComboBox.ForeColor = DarkThemeForeColor;

            LeftPanelDriveDetails.BackColor = DarkThemeBackgroundColor;
            LeftPanelDriveDetails.ForeColor = DarkThemeForeColor;

            LeftPanelStructure.BackColor = DarkThemeFieldColor;
            LeftPanelStructure.ForeColor = DarkThemeForeColor;

        }

        private void SetOutputWindowToDark()
        {
            OutputWindow.BackColor = DarkThemeFieldColor;
            OutputWindow.ForeColor = DarkThemeForeColor;

            OutputWindowClearButton.BackColor = DarkThemeBackgroundColor;
            OutputWindowClearButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-clear.png");

            OutputWindowSearchButton.BackColor = DarkThemeBackgroundColor;
            OutputWindowSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-search.png");
        
            OutputWindowSearchField.BackColor = DarkThemeFieldColor;
            OutputWindowSearchField.ForeColor = DarkThemeForeColor;

            OutputWindowNextButton.BackColor = DarkThemeBackgroundColor;
            OutputWindowNextButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-next.png");

            OutputWindowPrevButton.BackColor = DarkThemeBackgroundColor;
            OutputWindowPrevButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-prev.png");

            OutputWindowExpandButton.BackColor = DarkThemeBackgroundColor;
            OutputWindowExpandButton.Image = LoggerSplitContainer.Panel2Collapsed ?
                Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-lazy.png") :
                Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-active.png");
        } 
    }
}