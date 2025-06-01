using System.ComponentModel.DataAnnotations;

namespace PanaseWeb.Dtos.Users
{
    public class UserUpdateDto
    {
        [StringLength(50)]
        public string FullName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string EmergencyContact { get; set; }
    }
}
