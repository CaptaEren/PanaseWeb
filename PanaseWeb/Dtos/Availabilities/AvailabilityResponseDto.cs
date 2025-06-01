namespace PanaseWeb.Dtos.Availabilities
{
    public class AvailabilityResponseDto
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string DayName => this.DayOfWeek.ToString();
        public string TimeRange => $"{this.StartTime:hh\\:mm} - {this.EndTime:hh\\:mm}";
    }
}
