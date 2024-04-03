namespace DMS_GUI
{
    partial class BusDMS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fileOperations.Unsubscribe(_operationsEvents);
                _folderOperations.Unsubscribe(_operationsEvents);

                if (_logger != null)
                {
                    _logger.MessageLogged -= Logger_MessageLogged;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusDMS));
            MiddleVerticalPanel = new SplitContainer();
            ToggleLeftPanelButton = new Button();
            ThemeSwitcher = new TrackBar();
            ToggleRightPanelButton = new Button();
            MainMenuStrip = new MenuStrip();
            FileStripItem = new ToolStripMenuItem();
            NewToolStripItem = new ToolStripMenuItem();
            CreateNewFile = new ToolStripMenuItem();
            CreateNewFolder = new ToolStripMenuItem();
            ViewStripItem = new ToolStripMenuItem();
            LargeIconsToolStripMenuItem = new ToolStripMenuItem();
            SmallIconsViewOption = new ToolStripMenuItem();
            ListViewOption = new ToolStripMenuItem();
            DetailsViewOption = new ToolStripMenuItem();
            ShowHiddenItemsToolStripMenuItem = new ToolStripMenuItem();
            StripDivider = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            RenameStripItem = new ToolStripMenuItem();
            CutStripItem = new ToolStripMenuItem();
            CopyStripItem = new ToolStripMenuItem();
            PasteStripItem = new ToolStripMenuItem();
            MoveStripItem = new ToolStripMenuItem();
            DeleteStripItem = new ToolStripMenuItem();
            LoggerSplitContainer = new SplitContainer();
            OutputWindowExpandButton = new Button();
            OutputWindowPrevButton = new Button();
            OutputWindowContainer = new Panel();
            OutputWindow = new RichTextBox();
            OutputWindowSearchButton = new Button();
            OutputWindowSearchField = new TextBox();
            OutputWindowNextButton = new Button();
            OutputWindowClearButton = new Button();
            Middle = new SplitContainer();
            MiddleLeftPath = new TextBox();
            LeftList = new ListView();
            NameLeft = new ColumnHeader();
            TypeLeft = new ColumnHeader();
            SizeLeft = new ColumnHeader();
            DateLeft = new ColumnHeader();
            MiddleLeftInfo = new TextBox();
            RightList = new ListView();
            NameRight = new ColumnHeader();
            TypeRight = new ColumnHeader();
            SizeRight = new ColumnHeader();
            DateRight = new ColumnHeader();
            MiddleRightInfo = new TextBox();
            MiddleRightPath = new TextBox();
            RightPanel = new SplitContainer();
            RightPanelStructure = new TreeView();
            RightPanelComboBox = new ComboBox();
            RightPanelDriveDetails = new TextBox();
            RightPanelSearch = new TextBox();
            RightPanelSearchButton = new Button();
            LeftPanel = new SplitContainer();
            LeftPanelStructure = new TreeView();
            LeftPanelSearch = new TextBox();
            LeftPanelSearchButton = new Button();
            LeftPanelComboBox = new ComboBox();
            LeftPanelDriveDetails = new TextBox();
            RightClickMenu = new ContextMenuStrip(components);
            RightClickNewMenu = new ToolStripMenuItem();
            RightClickCreateFile = new ToolStripMenuItem();
            RightClickCreateFolder = new ToolStripMenuItem();
            RightClickRename = new ToolStripMenuItem();
            RightClickCopy = new ToolStripMenuItem();
            RightClickCut = new ToolStripMenuItem();
            RightClickPaste = new ToolStripMenuItem();
            RightClickMove = new ToolStripMenuItem();
            RightClickDelete = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)MiddleVerticalPanel).BeginInit();
            MiddleVerticalPanel.Panel1.SuspendLayout();
            MiddleVerticalPanel.Panel2.SuspendLayout();
            MiddleVerticalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThemeSwitcher).BeginInit();
            MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoggerSplitContainer).BeginInit();
            LoggerSplitContainer.Panel1.SuspendLayout();
            LoggerSplitContainer.Panel2.SuspendLayout();
            LoggerSplitContainer.SuspendLayout();
            OutputWindowContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Middle).BeginInit();
            Middle.Panel1.SuspendLayout();
            Middle.Panel2.SuspendLayout();
            Middle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RightPanel).BeginInit();
            RightPanel.Panel1.SuspendLayout();
            RightPanel.Panel2.SuspendLayout();
            RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LeftPanel).BeginInit();
            LeftPanel.Panel1.SuspendLayout();
            LeftPanel.Panel2.SuspendLayout();
            LeftPanel.SuspendLayout();
            RightClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MiddleVerticalPanel
            // 
            MiddleVerticalPanel.BackColor = SystemColors.Desktop;
            resources.ApplyResources(MiddleVerticalPanel, "MiddleVerticalPanel");
            MiddleVerticalPanel.Name = "MiddleVerticalPanel";
            // 
            // MiddleVerticalPanel.Panel1
            // 
            MiddleVerticalPanel.Panel1.BackColor = SystemColors.ActiveCaptionText;
            MiddleVerticalPanel.Panel1.Controls.Add(ToggleLeftPanelButton);
            MiddleVerticalPanel.Panel1.Controls.Add(ThemeSwitcher);
            MiddleVerticalPanel.Panel1.Controls.Add(ToggleRightPanelButton);
            MiddleVerticalPanel.Panel1.Controls.Add(MainMenuStrip);
            // 
            // MiddleVerticalPanel.Panel2
            // 
            MiddleVerticalPanel.Panel2.Controls.Add(LoggerSplitContainer);
            MiddleVerticalPanel.Panel2.Controls.Add(Middle);
            // 
            // ToggleLeftPanelButton
            // 
            ToggleLeftPanelButton.BackColor = Color.Black;
            ToggleLeftPanelButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(ToggleLeftPanelButton, "ToggleLeftPanelButton");
            ToggleLeftPanelButton.ForeColor = Color.White;
            ToggleLeftPanelButton.Name = "ToggleLeftPanelButton";
            ToggleLeftPanelButton.UseVisualStyleBackColor = false;
            ToggleLeftPanelButton.Click += ToggleLeftPanelButton_Click;
            // 
            // ThemeSwitcher
            // 
            resources.ApplyResources(ThemeSwitcher, "ThemeSwitcher");
            ThemeSwitcher.Maximum = 1;
            ThemeSwitcher.Name = "ThemeSwitcher";
            ThemeSwitcher.ValueChanged += ThemeSwitcher_ValueChanged;
            // 
            // ToggleRightPanelButton
            // 
            resources.ApplyResources(ToggleRightPanelButton, "ToggleRightPanelButton");
            ToggleRightPanelButton.BackColor = Color.Black;
            ToggleRightPanelButton.FlatAppearance.BorderSize = 0;
            ToggleRightPanelButton.ForeColor = Color.White;
            ToggleRightPanelButton.Name = "ToggleRightPanelButton";
            ToggleRightPanelButton.UseVisualStyleBackColor = false;
            ToggleRightPanelButton.Click += ToggleRightPanelButton_Click;
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.BackColor = Color.Black;
            resources.ApplyResources(MainMenuStrip, "MainMenuStrip");
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { FileStripItem, ViewStripItem, StripDivider, RenameStripItem, CutStripItem, CopyStripItem, PasteStripItem, MoveStripItem, DeleteStripItem });
            MainMenuStrip.Name = "MainMenuStrip";
            // 
            // FileStripItem
            // 
            FileStripItem.DropDownItems.AddRange(new ToolStripItem[] { NewToolStripItem });
            FileStripItem.ForeColor = Color.Azure;
            FileStripItem.Name = "FileStripItem";
            resources.ApplyResources(FileStripItem, "FileStripItem");
            // 
            // NewToolStripItem
            // 
            NewToolStripItem.BackColor = SystemColors.ScrollBar;
            NewToolStripItem.DropDownItems.AddRange(new ToolStripItem[] { CreateNewFile, CreateNewFolder });
            NewToolStripItem.Name = "NewToolStripItem";
            resources.ApplyResources(NewToolStripItem, "NewToolStripItem");
            // 
            // CreateNewFile
            // 
            CreateNewFile.BackColor = SystemColors.ScrollBar;
            CreateNewFile.Name = "CreateNewFile";
            resources.ApplyResources(CreateNewFile, "CreateNewFile");
            CreateNewFile.Click += CreateFile_Click;
            // 
            // CreateNewFolder
            // 
            CreateNewFolder.BackColor = SystemColors.ScrollBar;
            CreateNewFolder.Name = "CreateNewFolder";
            resources.ApplyResources(CreateNewFolder, "CreateNewFolder");
            CreateNewFolder.Click += CreateFolder_Click;
            // 
            // ViewStripItem
            // 
            ViewStripItem.BackColor = Color.Black;
            ViewStripItem.DropDownItems.AddRange(new ToolStripItem[] { LargeIconsToolStripMenuItem, SmallIconsViewOption, ListViewOption, DetailsViewOption, ShowHiddenItemsToolStripMenuItem });
            ViewStripItem.ForeColor = Color.Azure;
            ViewStripItem.Name = "ViewStripItem";
            resources.ApplyResources(ViewStripItem, "ViewStripItem");
            // 
            // LargeIconsToolStripMenuItem
            // 
            LargeIconsToolStripMenuItem.BackColor = SystemColors.ScrollBar;
            LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem";
            resources.ApplyResources(LargeIconsToolStripMenuItem, "LargeIconsToolStripMenuItem");
            LargeIconsToolStripMenuItem.Click += LargeIconsViewOption_Click;
            // 
            // SmallIconsViewOption
            // 
            SmallIconsViewOption.BackColor = SystemColors.ScrollBar;
            SmallIconsViewOption.Name = "SmallIconsViewOption";
            resources.ApplyResources(SmallIconsViewOption, "SmallIconsViewOption");
            SmallIconsViewOption.Click += SmallIconsViewOption_Click;
            // 
            // ListViewOption
            // 
            ListViewOption.BackColor = SystemColors.ScrollBar;
            ListViewOption.Name = "ListViewOption";
            resources.ApplyResources(ListViewOption, "ListViewOption");
            ListViewOption.Click += ListViewOption_Click;
            // 
            // DetailsViewOption
            // 
            DetailsViewOption.BackColor = SystemColors.ScrollBar;
            DetailsViewOption.Name = "DetailsViewOption";
            resources.ApplyResources(DetailsViewOption, "DetailsViewOption");
            DetailsViewOption.Click += DetailsViewOption_Click;
            // 
            // ShowHiddenItemsToolStripMenuItem
            // 
            ShowHiddenItemsToolStripMenuItem.BackColor = SystemColors.ScrollBar;
            ShowHiddenItemsToolStripMenuItem.CheckOnClick = true;
            ShowHiddenItemsToolStripMenuItem.Name = "ShowHiddenItemsToolStripMenuItem";
            resources.ApplyResources(ShowHiddenItemsToolStripMenuItem, "ShowHiddenItemsToolStripMenuItem");
            ShowHiddenItemsToolStripMenuItem.CheckedChanged += ShowHiddenItemsToolStripMenuItem_CheckedChanged;
            // 
            // StripDivider
            // 
            StripDivider.BackColor = Color.Black;
            StripDivider.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator2 });
            StripDivider.ForeColor = Color.White;
            StripDivider.Name = "StripDivider";
            resources.ApplyResources(StripDivider, "StripDivider");
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // RenameStripItem
            // 
            RenameStripItem.ForeColor = Color.Azure;
            RenameStripItem.Name = "RenameStripItem";
            resources.ApplyResources(RenameStripItem, "RenameStripItem");
            RenameStripItem.Click += RenameStripItem_Click;
            // 
            // CutStripItem
            // 
            CutStripItem.ForeColor = Color.Azure;
            CutStripItem.Name = "CutStripItem";
            resources.ApplyResources(CutStripItem, "CutStripItem");
            CutStripItem.Click += CutStripItem_Click;
            // 
            // CopyStripItem
            // 
            CopyStripItem.ForeColor = Color.Azure;
            CopyStripItem.Name = "CopyStripItem";
            resources.ApplyResources(CopyStripItem, "CopyStripItem");
            CopyStripItem.Click += CopyStripItem_Click;
            // 
            // PasteStripItem
            // 
            PasteStripItem.ForeColor = SystemColors.Control;
            PasteStripItem.Name = "PasteStripItem";
            resources.ApplyResources(PasteStripItem, "PasteStripItem");
            PasteStripItem.Click += PasteStripItem_Click;
            // 
            // MoveStripItem
            // 
            MoveStripItem.ForeColor = Color.Azure;
            MoveStripItem.Name = "MoveStripItem";
            resources.ApplyResources(MoveStripItem, "MoveStripItem");
            MoveStripItem.Click += MoveStripItem_Click;
            // 
            // DeleteStripItem
            // 
            DeleteStripItem.ForeColor = Color.Azure;
            DeleteStripItem.Name = "DeleteStripItem";
            resources.ApplyResources(DeleteStripItem, "DeleteStripItem");
            DeleteStripItem.Click += DeleteStripItem_Click;
            // 
            // LoggerSplitContainer
            // 
            resources.ApplyResources(LoggerSplitContainer, "LoggerSplitContainer");
            LoggerSplitContainer.FixedPanel = FixedPanel.Panel1;
            LoggerSplitContainer.Name = "LoggerSplitContainer";
            // 
            // LoggerSplitContainer.Panel1
            // 
            LoggerSplitContainer.Panel1.Controls.Add(OutputWindowExpandButton);
            // 
            // LoggerSplitContainer.Panel2
            // 
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowPrevButton);
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowContainer);
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowSearchButton);
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowSearchField);
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowNextButton);
            LoggerSplitContainer.Panel2.Controls.Add(OutputWindowClearButton);
            // 
            // OutputWindowExpandButton
            // 
            resources.ApplyResources(OutputWindowExpandButton, "OutputWindowExpandButton");
            OutputWindowExpandButton.ForeColor = SystemColors.Menu;
            OutputWindowExpandButton.Name = "OutputWindowExpandButton";
            OutputWindowExpandButton.UseVisualStyleBackColor = true;
            OutputWindowExpandButton.Click += OutputWindowExpandButton_Click;
            // 
            // OutputWindowPrevButton
            // 
            OutputWindowPrevButton.BackColor = SystemColors.MenuText;
            resources.ApplyResources(OutputWindowPrevButton, "OutputWindowPrevButton");
            OutputWindowPrevButton.ForeColor = Color.Azure;
            OutputWindowPrevButton.Name = "OutputWindowPrevButton";
            OutputWindowPrevButton.UseVisualStyleBackColor = false;
            OutputWindowPrevButton.Click += OutputWindowPrevButton_Click;
            // 
            // OutputWindowContainer
            // 
            resources.ApplyResources(OutputWindowContainer, "OutputWindowContainer");
            OutputWindowContainer.BackColor = SystemColors.Desktop;
            OutputWindowContainer.Controls.Add(OutputWindow);
            OutputWindowContainer.Name = "OutputWindowContainer";
            // 
            // OutputWindow
            // 
            OutputWindow.BackColor = Color.FromArgb(30, 35, 35);
            OutputWindow.BorderStyle = BorderStyle.None;
            resources.ApplyResources(OutputWindow, "OutputWindow");
            OutputWindow.Name = "OutputWindow";
            OutputWindow.ReadOnly = true;
            // 
            // OutputWindowSearchButton
            // 
            OutputWindowSearchButton.BackColor = Color.Black;
            OutputWindowSearchButton.Cursor = Cursors.Hand;
            OutputWindowSearchButton.FlatAppearance.BorderSize = 0;
            OutputWindowSearchButton.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            resources.ApplyResources(OutputWindowSearchButton, "OutputWindowSearchButton");
            OutputWindowSearchButton.ForeColor = Color.FromArgb(30, 35, 35);
            OutputWindowSearchButton.Name = "OutputWindowSearchButton";
            OutputWindowSearchButton.UseVisualStyleBackColor = false;
            OutputWindowSearchButton.Click += OutputWindowSearchButton_Click;
            // 
            // OutputWindowSearchField
            // 
            OutputWindowSearchField.BackColor = Color.FromArgb(30, 35, 35);
            OutputWindowSearchField.BorderStyle = BorderStyle.None;
            resources.ApplyResources(OutputWindowSearchField, "OutputWindowSearchField");
            OutputWindowSearchField.ForeColor = Color.Azure;
            OutputWindowSearchField.Name = "OutputWindowSearchField";
            // 
            // OutputWindowNextButton
            // 
            OutputWindowNextButton.BackColor = SystemColors.MenuText;
            resources.ApplyResources(OutputWindowNextButton, "OutputWindowNextButton");
            OutputWindowNextButton.ForeColor = Color.Azure;
            OutputWindowNextButton.Name = "OutputWindowNextButton";
            OutputWindowNextButton.UseVisualStyleBackColor = false;
            OutputWindowNextButton.Click += OutputWindowNextButton_Click;
            // 
            // OutputWindowClearButton
            // 
            resources.ApplyResources(OutputWindowClearButton, "OutputWindowClearButton");
            OutputWindowClearButton.BackColor = SystemColors.MenuText;
            OutputWindowClearButton.Name = "OutputWindowClearButton";
            OutputWindowClearButton.UseVisualStyleBackColor = false;
            OutputWindowClearButton.Click += OutputWindowClearButton_Click;
            // 
            // Middle
            // 
            resources.ApplyResources(Middle, "Middle");
            Middle.Name = "Middle";
            // 
            // Middle.Panel1
            // 
            Middle.Panel1.Controls.Add(MiddleLeftPath);
            Middle.Panel1.Controls.Add(LeftList);
            Middle.Panel1.Controls.Add(MiddleLeftInfo);
            // 
            // Middle.Panel2
            // 
            Middle.Panel2.Controls.Add(RightList);
            Middle.Panel2.Controls.Add(MiddleRightInfo);
            Middle.Panel2.Controls.Add(MiddleRightPath);
            // 
            // MiddleLeftPath
            // 
            MiddleLeftPath.BackColor = Color.FromArgb(30, 35, 35);
            MiddleLeftPath.BorderStyle = BorderStyle.None;
            resources.ApplyResources(MiddleLeftPath, "MiddleLeftPath");
            MiddleLeftPath.ForeColor = Color.Azure;
            MiddleLeftPath.Name = "MiddleLeftPath";
            MiddleLeftPath.KeyDown += MiddleLeftPath_KeyDown;
            // 
            // LeftList
            // 
            LeftList.AllowColumnReorder = true;
            LeftList.AllowDrop = true;
            resources.ApplyResources(LeftList, "LeftList");
            LeftList.BackColor = Color.FromArgb(30, 35, 35);
            LeftList.BorderStyle = BorderStyle.FixedSingle;
            LeftList.Columns.AddRange(new ColumnHeader[] { NameLeft, TypeLeft, SizeLeft, DateLeft });
            LeftList.ForeColor = Color.Azure;
            LeftList.FullRowSelect = true;
            LeftList.Name = "LeftList";
            LeftList.UseCompatibleStateImageBehavior = false;
            LeftList.View = View.Details;
            LeftList.AfterLabelEdit += LeftList_AfterLabelEdit;
            LeftList.ItemDrag += LeftList_ItemDrag;
            LeftList.SelectedIndexChanged += LeftList_SelectedIndexChanged;
            LeftList.DragDrop += LeftList_DragDrop;
            LeftList.DragEnter += LeftList_DragEnter;
            LeftList.KeyDown += LeftList_KeyDown;
            LeftList.MouseClick += LeftList_MouseClick;
            LeftList.MouseDoubleClick += LeftList_MouseDoubleClick;
            LeftList.MouseEnter += LeftList_MouseEnter;
            // 
            // NameLeft
            // 
            resources.ApplyResources(NameLeft, "NameLeft");
            // 
            // TypeLeft
            // 
            resources.ApplyResources(TypeLeft, "TypeLeft");
            // 
            // SizeLeft
            // 
            resources.ApplyResources(SizeLeft, "SizeLeft");
            // 
            // DateLeft
            // 
            resources.ApplyResources(DateLeft, "DateLeft");
            // 
            // MiddleLeftInfo
            // 
            MiddleLeftInfo.BackColor = SystemColors.Desktop;
            MiddleLeftInfo.BorderStyle = BorderStyle.None;
            resources.ApplyResources(MiddleLeftInfo, "MiddleLeftInfo");
            MiddleLeftInfo.ForeColor = SystemColors.Window;
            MiddleLeftInfo.Name = "MiddleLeftInfo";
            MiddleLeftInfo.ReadOnly = true;
            // 
            // RightList
            // 
            RightList.AllowColumnReorder = true;
            RightList.AllowDrop = true;
            resources.ApplyResources(RightList, "RightList");
            RightList.BackColor = Color.FromArgb(30, 35, 35);
            RightList.BorderStyle = BorderStyle.FixedSingle;
            RightList.Columns.AddRange(new ColumnHeader[] { NameRight, TypeRight, SizeRight, DateRight });
            RightList.ForeColor = Color.Azure;
            RightList.FullRowSelect = true;
            RightList.Name = "RightList";
            RightList.UseCompatibleStateImageBehavior = false;
            RightList.View = View.Details;
            RightList.AfterLabelEdit += RightList_AfterLabelEdit;
            RightList.ItemDrag += RightList_ItemDrag;
            RightList.SelectedIndexChanged += RightList_SelectedIndexChanged;
            RightList.DragDrop += RightList_DragDrop;
            RightList.DragEnter += RightList_DragEnter;
            RightList.KeyDown += RightList_KeyDown;
            RightList.MouseClick += RightList_MouseClick;
            RightList.MouseDoubleClick += RightList_MouseDoubleClick;
            RightList.MouseEnter += RightList_MouseEnter;
            // 
            // NameRight
            // 
            resources.ApplyResources(NameRight, "NameRight");
            // 
            // TypeRight
            // 
            resources.ApplyResources(TypeRight, "TypeRight");
            // 
            // SizeRight
            // 
            resources.ApplyResources(SizeRight, "SizeRight");
            // 
            // DateRight
            // 
            resources.ApplyResources(DateRight, "DateRight");
            // 
            // MiddleRightInfo
            // 
            MiddleRightInfo.BackColor = SystemColors.Desktop;
            MiddleRightInfo.BorderStyle = BorderStyle.None;
            resources.ApplyResources(MiddleRightInfo, "MiddleRightInfo");
            MiddleRightInfo.ForeColor = SystemColors.Window;
            MiddleRightInfo.Name = "MiddleRightInfo";
            MiddleRightInfo.ReadOnly = true;
            // 
            // MiddleRightPath
            // 
            MiddleRightPath.BackColor = Color.FromArgb(30, 35, 35);
            MiddleRightPath.BorderStyle = BorderStyle.None;
            resources.ApplyResources(MiddleRightPath, "MiddleRightPath");
            MiddleRightPath.ForeColor = Color.Azure;
            MiddleRightPath.Name = "MiddleRightPath";
            MiddleRightPath.KeyDown += MiddleRightPath_KeyDown;
            // 
            // RightPanel
            // 
            RightPanel.BackColor = SystemColors.Desktop;
            resources.ApplyResources(RightPanel, "RightPanel");
            RightPanel.Name = "RightPanel";
            // 
            // RightPanel.Panel1
            // 
            RightPanel.Panel1.Controls.Add(MiddleVerticalPanel);
            // 
            // RightPanel.Panel2
            // 
            RightPanel.Panel2.Controls.Add(RightPanelStructure);
            RightPanel.Panel2.Controls.Add(RightPanelComboBox);
            RightPanel.Panel2.Controls.Add(RightPanelDriveDetails);
            RightPanel.Panel2.Controls.Add(RightPanelSearch);
            RightPanel.Panel2.Controls.Add(RightPanelSearchButton);
            // 
            // RightPanelStructure
            // 
            resources.ApplyResources(RightPanelStructure, "RightPanelStructure");
            RightPanelStructure.BackColor = Color.FromArgb(30, 35, 35);
            RightPanelStructure.BorderStyle = BorderStyle.FixedSingle;
            RightPanelStructure.ForeColor = Color.Azure;
            RightPanelStructure.Name = "RightPanelStructure";
            RightPanelStructure.BeforeExpand += RightPanelStructure_BeforeExpand;
            RightPanelStructure.AfterSelect += RightPanelStructure_AfterSelect;
            // 
            // RightPanelComboBox
            // 
            resources.ApplyResources(RightPanelComboBox, "RightPanelComboBox");
            RightPanelComboBox.BackColor = Color.FromArgb(30, 35, 35);
            RightPanelComboBox.ForeColor = Color.Azure;
            RightPanelComboBox.FormattingEnabled = true;
            RightPanelComboBox.Name = "RightPanelComboBox";
            RightPanelComboBox.SelectedIndexChanged += RightPanelComboBox_SelectedIndexChanged;
            // 
            // RightPanelDriveDetails
            // 
            resources.ApplyResources(RightPanelDriveDetails, "RightPanelDriveDetails");
            RightPanelDriveDetails.BackColor = SystemColors.MenuText;
            RightPanelDriveDetails.BorderStyle = BorderStyle.None;
            RightPanelDriveDetails.ForeColor = SystemColors.Window;
            RightPanelDriveDetails.Name = "RightPanelDriveDetails";
            RightPanelDriveDetails.ReadOnly = true;
            // 
            // RightPanelSearch
            // 
            resources.ApplyResources(RightPanelSearch, "RightPanelSearch");
            RightPanelSearch.BackColor = Color.FromArgb(30, 35, 35);
            RightPanelSearch.BorderStyle = BorderStyle.None;
            RightPanelSearch.ForeColor = Color.Azure;
            RightPanelSearch.Name = "RightPanelSearch";
            RightPanelSearch.KeyDown += RightPanelSearch_KeyDown;
            // 
            // RightPanelSearchButton
            // 
            RightPanelSearchButton.BackColor = Color.Black;
            RightPanelSearchButton.Cursor = Cursors.Hand;
            RightPanelSearchButton.FlatAppearance.BorderSize = 0;
            RightPanelSearchButton.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            resources.ApplyResources(RightPanelSearchButton, "RightPanelSearchButton");
            RightPanelSearchButton.ForeColor = Color.FromArgb(30, 35, 35);
            RightPanelSearchButton.Name = "RightPanelSearchButton";
            RightPanelSearchButton.UseVisualStyleBackColor = false;
            RightPanelSearchButton.Click += RigthPanelSearchButton_Click;
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = SystemColors.Desktop;
            resources.ApplyResources(LeftPanel, "LeftPanel");
            LeftPanel.Name = "LeftPanel";
            // 
            // LeftPanel.Panel1
            // 
            LeftPanel.Panel1.Controls.Add(LeftPanelStructure);
            LeftPanel.Panel1.Controls.Add(LeftPanelSearch);
            LeftPanel.Panel1.Controls.Add(LeftPanelSearchButton);
            LeftPanel.Panel1.Controls.Add(LeftPanelComboBox);
            LeftPanel.Panel1.Controls.Add(LeftPanelDriveDetails);
            // 
            // LeftPanel.Panel2
            // 
            LeftPanel.Panel2.Controls.Add(RightPanel);
            // 
            // LeftPanelStructure
            // 
            resources.ApplyResources(LeftPanelStructure, "LeftPanelStructure");
            LeftPanelStructure.BackColor = Color.FromArgb(30, 35, 35);
            LeftPanelStructure.BorderStyle = BorderStyle.FixedSingle;
            LeftPanelStructure.ForeColor = Color.Azure;
            LeftPanelStructure.Name = "LeftPanelStructure";
            LeftPanelStructure.BeforeExpand += LeftPanelStructure_BeforeExpand;
            LeftPanelStructure.AfterSelect += LeftPanelStructure_AfterSelect;
            // 
            // LeftPanelSearch
            // 
            resources.ApplyResources(LeftPanelSearch, "LeftPanelSearch");
            LeftPanelSearch.BackColor = Color.FromArgb(30, 35, 35);
            LeftPanelSearch.BorderStyle = BorderStyle.None;
            LeftPanelSearch.ForeColor = Color.Azure;
            LeftPanelSearch.Name = "LeftPanelSearch";
            LeftPanelSearch.KeyDown += LeftPanelSearch_KeyDown;
            // 
            // LeftPanelSearchButton
            // 
            resources.ApplyResources(LeftPanelSearchButton, "LeftPanelSearchButton");
            LeftPanelSearchButton.BackColor = Color.Black;
            LeftPanelSearchButton.Cursor = Cursors.Hand;
            LeftPanelSearchButton.FlatAppearance.BorderColor = Color.Black;
            LeftPanelSearchButton.FlatAppearance.BorderSize = 0;
            LeftPanelSearchButton.FlatAppearance.MouseOverBackColor = SystemColors.GradientActiveCaption;
            LeftPanelSearchButton.ForeColor = Color.FromArgb(30, 35, 35);
            LeftPanelSearchButton.Name = "LeftPanelSearchButton";
            LeftPanelSearchButton.UseVisualStyleBackColor = false;
            LeftPanelSearchButton.Click += LeftPanelSearchButton_Click;
            // 
            // LeftPanelComboBox
            // 
            resources.ApplyResources(LeftPanelComboBox, "LeftPanelComboBox");
            LeftPanelComboBox.BackColor = Color.FromArgb(30, 35, 35);
            LeftPanelComboBox.ForeColor = Color.Azure;
            LeftPanelComboBox.FormattingEnabled = true;
            LeftPanelComboBox.Name = "LeftPanelComboBox";
            LeftPanelComboBox.SelectedIndexChanged += LeftPanelComboBox_SelectedIndexChanged;
            // 
            // LeftPanelDriveDetails
            // 
            resources.ApplyResources(LeftPanelDriveDetails, "LeftPanelDriveDetails");
            LeftPanelDriveDetails.BackColor = SystemColors.MenuText;
            LeftPanelDriveDetails.BorderStyle = BorderStyle.None;
            LeftPanelDriveDetails.ForeColor = SystemColors.Window;
            LeftPanelDriveDetails.Name = "LeftPanelDriveDetails";
            LeftPanelDriveDetails.ReadOnly = true;
            // 
            // RightClickMenu
            // 
            RightClickMenu.BackColor = SystemColors.Window;
            RightClickMenu.Items.AddRange(new ToolStripItem[] { RightClickNewMenu, RightClickRename, RightClickCopy, RightClickCut, RightClickPaste, RightClickMove, RightClickDelete });
            RightClickMenu.Name = "RightClickMenu";
            resources.ApplyResources(RightClickMenu, "RightClickMenu");
            RightClickMenu.Opening += RightClickMenu_Opening;
            // 
            // RightClickNewMenu
            // 
            RightClickNewMenu.DropDownItems.AddRange(new ToolStripItem[] { RightClickCreateFile, RightClickCreateFolder });
            RightClickNewMenu.Name = "RightClickNewMenu";
            resources.ApplyResources(RightClickNewMenu, "RightClickNewMenu");
            // 
            // RightClickCreateFile
            // 
            RightClickCreateFile.Name = "RightClickCreateFile";
            resources.ApplyResources(RightClickCreateFile, "RightClickCreateFile");
            RightClickCreateFile.Click += RightClickCreateFile_Click;
            // 
            // RightClickCreateFolder
            // 
            RightClickCreateFolder.Name = "RightClickCreateFolder";
            resources.ApplyResources(RightClickCreateFolder, "RightClickCreateFolder");
            RightClickCreateFolder.Click += RightClickCreateFolder_Click;
            // 
            // RightClickRename
            // 
            RightClickRename.Name = "RightClickRename";
            resources.ApplyResources(RightClickRename, "RightClickRename");
            RightClickRename.Click += RightClickRename_Click;
            // 
            // RightClickCopy
            // 
            RightClickCopy.Name = "RightClickCopy";
            resources.ApplyResources(RightClickCopy, "RightClickCopy");
            RightClickCopy.Click += RightClickCopy_Click;
            // 
            // RightClickCut
            // 
            RightClickCut.Name = "RightClickCut";
            resources.ApplyResources(RightClickCut, "RightClickCut");
            RightClickCut.Click += cutToolStripMenuItem_Click;
            // 
            // RightClickPaste
            // 
            RightClickPaste.Name = "RightClickPaste";
            resources.ApplyResources(RightClickPaste, "RightClickPaste");
            RightClickPaste.MouseDown += RightClickPaste_MouseDown;
            // 
            // RightClickMove
            // 
            RightClickMove.Name = "RightClickMove";
            resources.ApplyResources(RightClickMove, "RightClickMove");
            RightClickMove.Click += RightClickMove_Click;
            // 
            // RightClickDelete
            // 
            RightClickDelete.Name = "RightClickDelete";
            resources.ApplyResources(RightClickDelete, "RightClickDelete");
            RightClickDelete.Click += RightClickDelete_Click;
            // 
            // BusDMS
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            Controls.Add(LeftPanel);
            Name = "BusDMS";
            MiddleVerticalPanel.Panel1.ResumeLayout(false);
            MiddleVerticalPanel.Panel1.PerformLayout();
            MiddleVerticalPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MiddleVerticalPanel).EndInit();
            MiddleVerticalPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ThemeSwitcher).EndInit();
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            LoggerSplitContainer.Panel1.ResumeLayout(false);
            LoggerSplitContainer.Panel2.ResumeLayout(false);
            LoggerSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LoggerSplitContainer).EndInit();
            LoggerSplitContainer.ResumeLayout(false);
            OutputWindowContainer.ResumeLayout(false);
            Middle.Panel1.ResumeLayout(false);
            Middle.Panel1.PerformLayout();
            Middle.Panel2.ResumeLayout(false);
            Middle.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Middle).EndInit();
            Middle.ResumeLayout(false);
            RightPanel.Panel1.ResumeLayout(false);
            RightPanel.Panel2.ResumeLayout(false);
            RightPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RightPanel).EndInit();
            RightPanel.ResumeLayout(false);
            LeftPanel.Panel1.ResumeLayout(false);
            LeftPanel.Panel1.PerformLayout();
            LeftPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LeftPanel).EndInit();
            LeftPanel.ResumeLayout(false);
            RightClickMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer RightPanel;
        private System.Windows.Forms.SplitContainer LeftPanel;
        private System.Windows.Forms.Button LeftPanelSearchButton;
        private System.Windows.Forms.TextBox LeftPanelSearch;
        private System.Windows.Forms.Button RightPanelSearchButton;
        private System.Windows.Forms.TextBox RightPanelSearch;
        private System.Windows.Forms.ComboBox LeftPanelComboBox;
        private System.Windows.Forms.ComboBox RightPanelComboBox;
        private System.Windows.Forms.SplitContainer MiddleVerticalPanel;
        private System.Windows.Forms.SplitContainer Middle;
        private System.Windows.Forms.TextBox MiddleLeftPath;
        private System.Windows.Forms.TreeView LeftPanelStructure;
        private System.Windows.Forms.TextBox MiddleRightPath;
        private System.Windows.Forms.TreeView RightPanelStructure;
        private System.Windows.Forms.TextBox MiddleLeftInfo;
        private System.Windows.Forms.TextBox MiddleRightInfo;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStripItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem ViewStripItem;
        private System.Windows.Forms.ToolStripMenuItem LargeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmallIconsViewOption;
        private System.Windows.Forms.ToolStripMenuItem ListViewOption;
        private System.Windows.Forms.ToolStripMenuItem DetailsViewOption;
        private System.Windows.Forms.ToolStripMenuItem CutStripItem;
        private System.Windows.Forms.ToolStripMenuItem CopyStripItem;
        private System.Windows.Forms.ToolStripMenuItem RenameStripItem;
        private System.Windows.Forms.ToolStripMenuItem MoveStripItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteStripItem;
        private System.Windows.Forms.TextBox RightPanelDriveDetails;
        private System.Windows.Forms.TextBox LeftPanelDriveDetails;
        private System.Windows.Forms.ListView LeftList;
        private System.Windows.Forms.ColumnHeader NameLeft;
        private System.Windows.Forms.ColumnHeader TypeLeft;
        private System.Windows.Forms.ColumnHeader SizeLeft;
        private System.Windows.Forms.ColumnHeader DateLeft;
        private System.Windows.Forms.ListView RightList;
        private System.Windows.Forms.ColumnHeader NameRight;
        private System.Windows.Forms.ColumnHeader TypeRight;
        private System.Windows.Forms.ColumnHeader SizeRight;
        private System.Windows.Forms.ColumnHeader DateRight;
        private ToolStripMenuItem StripDivider;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ShowHiddenItemsToolStripMenuItem;
        private ToolStripMenuItem CreateNewFile;
        private ToolStripMenuItem CreateNewFolder;
        private Button ToggleRightPanelButton;
        private Button ToggleLeftPanelButton;
        private TrackBar ThemeSwitcher;
        private ContextMenuStrip RightClickMenu;
        private ToolStripMenuItem RightClickNewMenu;
        private ToolStripMenuItem RightClickCreateFile;
        private ToolStripMenuItem RightClickCreateFolder;
        private ToolStripMenuItem RightClickRename;
        private ToolStripMenuItem RightClickCopy;
        private ToolStripMenuItem RightClickMove;
        private ToolStripMenuItem RightClickDelete;
        private ToolStripMenuItem PasteStripItem;
        private ToolStripMenuItem RightClickCut;
        private ToolStripMenuItem RightClickPaste;
        private Panel OutputWindowContainer;
        private RichTextBox OutputWindow;
        private Button OutputWindowClearButton;
        private Button OutputWindowSearchButton;
        private TextBox OutputWindowSearchField;
        private Button OutputWindowNextButton;
        private Button OutputWindowPrevButton;
        private SplitContainer LoggerSplitContainer;
        private Button OutputWindowExpandButton;
    }
}

