using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Resources
{
    public class ResourceCreateDto
    {
        [Required] public string Title { get; set; }
        [Required] public string Type { get; set; } // "PDF", "Video", "Audio"
        [Required] public string FileUrl { get; set; }
        public string Category { get; set; } // "Anxiety", "Depression"
    }
}
