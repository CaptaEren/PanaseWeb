namespace PanaseWeb.Dtos.Resources
{
    public class ResourceResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
