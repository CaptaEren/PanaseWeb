namespace PanaseWeb.Dtos.Appointments
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PsychologistName { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; } // "Scheduled", "Completed", "Cancelled"
        public string MeetingType { get; set; }
    }
}
