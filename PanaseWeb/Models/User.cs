using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Models
{
    public class User:IdentityUser
    {
        [PersonalData]
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        [StringLength(20)]
        [Display(Name = "Emergency Phone")]
        public string EmergencyPhone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime MemberSince { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<PatientJournal> Journals { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<TherapyNote> TherapyNotes { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}