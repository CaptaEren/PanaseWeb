namespace PanaseWeb.Dtos.Utilities
{
    public class ErrorResponseDto
    {
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string StackTrace { get; set; }
    }
}
