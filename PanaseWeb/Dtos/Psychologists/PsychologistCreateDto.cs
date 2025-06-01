using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Psychologists
{
    public class PsychologistCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Specialty { get; set; } // "Clinical", "Child", "Trauma"

        [Required]
        [StringLength(500)]
        public string Bio { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
