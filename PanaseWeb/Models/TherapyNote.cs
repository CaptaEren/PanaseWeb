using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class TherapyNote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Psychologist")]
        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SessionDate { get; set; }

        [Required]
        public string Notes { get; set; }

        [StringLength(50)]
        public string DiagnosisCode { get; set; }

        [StringLength(1000)]
        public string TreatmentGoals { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        public bool IsLocked { get; set; } = false; // Prevents further edits
    }
}
