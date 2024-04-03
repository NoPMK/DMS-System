namespace DMS_GUI.States
{
    public class FormState
    {
        public bool ShowHiddenItems { get; set; }
        public ListView ActiveListView { get; set; }
        public string LeftPanelCurrentFolderPath { get; set; }
        public string RightPanelCurrentFolderPath { get; set; }
        public string RightClickSourcePath { get; set; }
        public bool UpdatingPathFromTextBox { get; set; } = false;
        public bool IsFile { get; set; }
        public bool IsThemeDark { get; set; }
        public int LastSearchIndex { get; set; }
        public List<ListViewItem> CutItems { get; set; } = new List<ListViewItem>();
        public Dictionary<string, int> IconCache { get; set; } = new Dictionary<string, int>();
    }
}