namespace PanaseWeb.Dtos.TherapySessions
{
    public class TherapySessionResponseDto
    {
        public int Id { get; set; }
        public string PsychologistName { get; set; }
        public DateTime SessionDate { get; set; }
        public int? ProgressRating { get; set; } // 1-10
    }
}
