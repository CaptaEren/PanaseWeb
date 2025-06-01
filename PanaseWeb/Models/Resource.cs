using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // PDF, Video, Link, Audio

        [Required]
        public string FileUrl { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [ForeignKey("Psychologist")]
        public int? PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
