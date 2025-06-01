using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Appointments
{
    public class AppointmentCreateDto
    {
        [Required] public DateTime DateTime { get; set; }
        [Required] public int PsychologistId { get; set; }
        [Required] public string MeetingType { get; set; } // "InPerson", "Video", "Phone"
        public string Description { get; set; }

    }
}
