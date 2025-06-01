using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Psychologists
{
    public class PsychologistUpdateDto
    {
        [StringLength(100)]
        public string Name { get; set; }

        public string Specialty { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }

        [Url]
        public string PhotoUrl { get; set; }
    }
}
