namespace PanaseWeb.Dtos.Psychologists
{
    public class PsychologistResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string PhotoUrl { get; set; }
        public int YearsOfExperience { get; set; }
        public IEnumerable<string> AvailabilitySlots { get; set; }
    }
}
