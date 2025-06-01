using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.BlogPosts
{
    public class BlogPostCreateDto
    {
        [Required] 
        public string Title { get; set; }

        [Required] 
        public string Content { get; set; }
        public int? PsychologistId { get; set; }
    }
}
