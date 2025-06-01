using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class Psychologist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        [Required]
        public string Bio { get; set; }

        [StringLength(255)]
        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Education { get; set; }

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<TherapySession> TherapySessions { get; set; }
        public ICollection<Availability> Availabilities { get; set; }
    }
}
