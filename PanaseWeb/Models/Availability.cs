using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Psychologist")]
        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        public bool IsRecurring { get; set; } = true;

        [DataType(DataType.Date)]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidTo { get; set; }
    }
}
