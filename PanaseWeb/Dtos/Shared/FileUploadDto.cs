using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Shared
{
    public class FileUploadDto
    {
        [Required]
        public IFormFile File { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
