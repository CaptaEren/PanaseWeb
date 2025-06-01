namespace PanaseWeb.Dtos.Psychologists
{
    public class PsychologistDetailDto : PsychologistResponseDto
    {
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<string> TreatmentMethods { get; set; } // "CBT", "EMDR"
    }
}
