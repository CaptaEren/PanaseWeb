namespace PanaseWeb.Dtos.PatientJournals
{
    public class JournalEntryResponseDto
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Mood { get; set; }
        public bool SharedWithTherapist { get; set; }
    }
}
