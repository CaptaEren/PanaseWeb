using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Notifications
{
    public class NotificationCreateDto
    {
        [Required] public string UserId { get; set; }
        [Required] public string Message { get; set; }
        [Required] public string Type { get; set; } // "Appointment", "System", "Assignment"
    }
}
