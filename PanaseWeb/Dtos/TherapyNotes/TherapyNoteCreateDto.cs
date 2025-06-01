using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.TherapyNotes
{
    public class TherapyNoteCreateDto
    {
        [Required] public string UserId { get; set; }
        [Required] public int PsychologistId { get; set; }
        [Required] public string Notes { get; set; }
        public string DiagnosisCode { get; set; } // ICD-10 codes
    }
}
