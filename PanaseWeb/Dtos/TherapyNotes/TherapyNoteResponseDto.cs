namespace PanaseWeb.Dtos.TherapyNotes
{
    public class TherapyNoteResponseDto
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public string PsychologistName { get; set; }
        public string DiagnosisCode { get; set; }
        public bool IsLocked { get; set; }
    }
}
