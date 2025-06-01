using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class TherapySession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [Required]
        public string SessionNotes { get; set; }

        [StringLength(1000)]
        public string TreatmentPlan { get; set; }

        [Range(1, 10)]
        public int? ProgressRating { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public string MoodAssessment { get; set; }

        public bool HomeworkAssigned { get; set; } = false;
    }
}
