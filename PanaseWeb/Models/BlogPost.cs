using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(500)]
        public string Excerpt { get; set; }

        [StringLength(50)]
        public string Category { get; set; } // Mental Health, Relationships, etc.

        public bool IsFeatured { get; set; } = false;

        [ForeignKey("Psychologist")]
        public int? PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }
    }
}
