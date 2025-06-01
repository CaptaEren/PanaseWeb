using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.TherapySessions
{
    public class TherapySessionCreateDto
    {
        [Required] public int AppointmentId { get; set; }
        [Required] public string SessionNotes { get; set; }
        public string TreatmentPlan { get; set; }
    }
}
