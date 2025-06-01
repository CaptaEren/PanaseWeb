using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Assignments
{
    public class AssignmentCreateDto
    {
        [Required] 
        public string UserId { get; set; }

        [Required] 
        public string Title { get; set; }

        [Required] 
        public DateTime DueDate { get; set; }

        public string Description { get; set; }
    }
}
