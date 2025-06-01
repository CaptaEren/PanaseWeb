using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [StringLength(200)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Appointment, Payment, System, Reminder

        [Required]
        public bool IsRead { get; set; } = false;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime? ReadAt { get; set; }

        public string RelatedEntityType { get; set; } // e.g., "Appointment"
        public int? RelatedEntityId { get; set; } // e.g., AppointmentId
    }
}
