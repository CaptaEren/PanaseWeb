namespace PanaseWeb.Dtos.Assignments
{
    public class AssignmentResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; } // "Pending", "Completed"
        public DateTime? CompletedAt { get; set; }
    }
}
