namespace PanaseWeb.Dtos.Psychologists
{
    public class PsychologistWithAvailabilityDto: PsychologistDto
    {
        public IEnumerable<AvailabilityDto> Availabilities { get; set; }
    }
}
