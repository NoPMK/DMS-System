namespace DMS_GUI
{
    public partial class BusDMS
    {
        private readonly Color LightThemeForeColor = Color.Black;
        private readonly Color LightThemeCutForeColor = Color.FromArgb(60, 60, 60);
        private readonly Color LightThemeCutBackColor = Color.FromArgb(246, 246, 246);
        private readonly Color LightThemeBackgroundColor = Color.FromArgb(251, 249, 249);
        private readonly Color LightThemeFieldColor = Color.FromArgb(229, 225, 218);

        private void SetRightPanelToLight()
        {
            RightPanel.BackColor = LightThemeBackgroundColor;

            RightPanelSearch.BackColor = LightThemeFieldColor;
            RightPanelSearch.ForeColor = LightThemeForeColor;

            RightPanelSearchButton.BackColor = LightThemeBackgroundColor;
            RightPanelSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-search.png");

            RightPanelComboBox.BackColor = LightThemeFieldColor;
            RightPanelComboBox.ForeColor = LightThemeForeColor;

            RightPanelDriveDetails.BackColor = LightThemeBackgroundColor;
            RightPanelDriveDetails.ForeColor = LightThemeForeColor;

            RightPanelStructure.BackColor = LightThemeFieldColor;
            RightPanelStructure.ForeColor = LightThemeForeColor;
        }

        private void SetMenuStripToLight()
        {
            MainMenuStrip.BackColor = LightThemeBackgroundColor;

            FileStripItem.BackColor = LightThemeBackgroundColor;
            FileStripItem.ForeColor = LightThemeForeColor;
            FileStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-file.png");

            NewToolStripItem.BackColor = LightThemeBackgroundColor;
            NewToolStripItem.ForeColor = LightThemeForeColor;

            CreateNewFile.BackColor = LightThemeBackgroundColor;
            CreateNewFile.ForeColor = LightThemeForeColor;

            CreateNewFolder.BackColor = LightThemeBackgroundColor;
            CreateNewFolder.ForeColor = LightThemeForeColor;

            ViewStripItem.BackColor = LightThemeBackgroundColor;
            ViewStripItem.ForeColor = LightThemeForeColor;
            ViewStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-view.png");

            LargeIconsToolStripMenuItem.BackColor = LightThemeBackgroundColor;
            LargeIconsToolStripMenuItem.ForeColor = LightThemeForeColor;

            SmallIconsViewOption.BackColor = LightThemeBackgroundColor;
            SmallIconsViewOption.ForeColor = LightThemeForeColor;

            ListViewOption.BackColor = LightThemeBackgroundColor;
            ListViewOption.ForeColor = LightThemeForeColor;

            DetailsViewOption.BackColor = LightThemeBackgroundColor;
            DetailsViewOption.ForeColor = LightThemeForeColor;

            ShowHiddenItemsToolStripMenuItem.BackColor = LightThemeBackgroundColor;
            ShowHiddenItemsToolStripMenuItem.ForeColor = LightThemeForeColor;

            StripDivider.BackColor = LightThemeBackgroundColor;
            StripDivider.ForeColor = LightThemeForeColor;

            RenameStripItem.BackColor = LightThemeBackgroundColor;
            RenameStripItem.ForeColor = LightThemeForeColor;
            RenameStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-rename.png");

            CutStripItem.BackColor = LightThemeBackgroundColor;
            CutStripItem.ForeColor = LightThemeForeColor;
            State.CutItems.ForEach(item => item.ForeColor = LightThemeCutForeColor);
            State.CutItems.ForEach(item => item.BackColor = LightThemeCutBackColor);
            CutStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-cut.png");

            PasteStripItem.BackColor = LightThemeBackgroundColor;
            PasteStripItem.ForeColor = LightThemeForeColor;
            PasteStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-paste.png");

            CopyStripItem.BackColor = LightThemeBackgroundColor;
            CopyStripItem.ForeColor = LightThemeForeColor;
            CopyStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-copy.png");

            MoveStripItem.BackColor = LightThemeBackgroundColor;
            MoveStripItem.ForeColor = LightThemeForeColor;
            MoveStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-move.png");

            DeleteStripItem.BackColor = LightThemeBackgroundColor;
            DeleteStripItem.ForeColor = LightThemeForeColor;
            DeleteStripItem.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-delete.png");
        }

        private void SetMiddlePanelToLight()
        {
            MiddleVerticalPanel.BackColor = LightThemeBackgroundColor;
            MiddleVerticalPanel.Panel1.BackColor = LightThemeBackgroundColor;

            ToggleLeftPanelButton.BackColor = LightThemeBackgroundColor;
            ToggleLeftPanelButton.ForeColor = LightThemeForeColor;

            ToggleRightPanelButton.BackColor = LightThemeBackgroundColor;
            ToggleRightPanelButton.ForeColor = LightThemeForeColor;

            MiddleLeftPath.BackColor = LightThemeFieldColor;
            MiddleLeftPath.ForeColor = LightThemeForeColor;

            MiddleRightPath.BackColor = LightThemeFieldColor;
            MiddleRightPath.ForeColor = LightThemeForeColor;

            LeftList.BackColor = LightThemeFieldColor;
            LeftList.ForeColor = LightThemeForeColor;

            RightList.BackColor = LightThemeFieldColor;
            RightList.ForeColor = LightThemeForeColor;

            MiddleLeftInfo.BackColor = LightThemeBackgroundColor;
            MiddleLeftInfo.ForeColor = LightThemeForeColor;

            MiddleRightInfo.BackColor = LightThemeBackgroundColor;
            MiddleRightInfo.ForeColor = LightThemeForeColor;

            ThemeSwitcher.BackColor = LightThemeBackgroundColor;
        }

        private void SetLeftPanelToLight()
        {
            LeftPanel.BackColor = LightThemeBackgroundColor;

            LeftPanelSearch.BackColor = LightThemeFieldColor;
            LeftPanelSearch.ForeColor = LightThemeForeColor;

            LeftPanelSearchButton.BackColor = LightThemeBackgroundColor;
            LeftPanelSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-search.png");

            LeftPanelComboBox.BackColor = LightThemeFieldColor;
            LeftPanelComboBox.ForeColor = LightThemeForeColor;

            LeftPanelDriveDetails.BackColor = LightThemeBackgroundColor;
            LeftPanelDriveDetails.ForeColor = LightThemeForeColor;

            LeftPanelStructure.BackColor = LightThemeFieldColor;
            LeftPanelStructure.ForeColor = LightThemeForeColor;
        }

        private void SetOutputWindowToLight()
        {
            OutputWindow.BackColor = LightThemeFieldColor;
            OutputWindow.ForeColor = LightThemeForeColor;

            OutputWindowClearButton.BackColor = LightThemeBackgroundColor;
            OutputWindowClearButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-clear.png");

            OutputWindowSearchButton.BackColor = LightThemeBackgroundColor;
            OutputWindowSearchButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-search.png");

            OutputWindowSearchField.BackColor = LightThemeFieldColor;
            OutputWindowSearchField.ForeColor = LightThemeForeColor;

            OutputWindowNextButton.BackColor = LightThemeBackgroundColor;
            OutputWindowNextButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-next.png");

            OutputWindowPrevButton.BackColor = LightThemeBackgroundColor;
            OutputWindowPrevButton.Image = Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-prev.png");

            OutputWindowExpandButton.BackColor = LightThemeBackgroundColor;
            OutputWindowExpandButton.Image = LoggerSplitContainer.Panel2Collapsed ?
                Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-lazy.png") :
                Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-active.png");
        }
    }
}