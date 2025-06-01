namespace PanaseWeb.Dtos.Appointments
{
    public class AppointmentUpdateDto
    {
        public DateTime? DateTime { get; set; }
        public string Status { get; set; } // "Cancelled", "Completed"
        public string Notes { get; set; }
    }
}
