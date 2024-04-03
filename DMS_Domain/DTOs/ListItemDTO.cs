namespace DMS_Domain.DTOs
{
    public class ListItemDTO
    {
        public ListItemDTO(string primaryText, IEnumerable<string> subItems, string tag, string lastWriteTime)
        {
            PrimaryText = primaryText;
            SubItems = subItems.ToList();
            Tag = tag;
            LastWriteTime = lastWriteTime;
        }

        public string PrimaryText { get; set; }
        public List<string> SubItems { get; set; } = new List<string>();
        public string Tag { get; set; }
        public string LastWriteTime { get; set; }
    }
}