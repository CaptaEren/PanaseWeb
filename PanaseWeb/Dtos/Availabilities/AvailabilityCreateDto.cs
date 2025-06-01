using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Availabilities
{
    public class AvailabilityCreateDto
    {
        [Required]
        public int PsychologistId { get; set; }
        [Required] 
        public DayOfWeek DayOfWeek { get; set; }
        [Required] 
        public TimeSpan StartTime { get; set; }
        [Required] 
        public TimeSpan EndTime { get; set; }
    }
}
