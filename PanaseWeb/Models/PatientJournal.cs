using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class PatientJournal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string Mood { get; set; }

        [Range(1, 10)]
        public int? StressLevel { get; set; }

        public bool SharedWithTherapist { get; set; } = false;
    }
}
