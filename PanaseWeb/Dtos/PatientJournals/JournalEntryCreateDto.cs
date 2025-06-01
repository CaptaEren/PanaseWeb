using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.PatientJournals
{
    public class JournalEntryCreateDto
    {
        [Required]
        public string UserId { get; set; }
        [Required] 
        public string Content { get; set; }
        public string Mood { get; set; } // "Happy", "Anxious", "Neutral"
    }
}
