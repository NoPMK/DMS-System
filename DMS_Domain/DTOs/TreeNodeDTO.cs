namespace DMS_Domain.DTOs
{
    public class TreeNodeDTO
    {
        public TreeNodeDTO(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public List<TreeNodeDTO> Children { get; set; } = new List<TreeNodeDTO>();
        public object Tag { get; set; } = string.Empty;
    }
}