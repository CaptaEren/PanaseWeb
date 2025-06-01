namespace PanaseWeb.Dtos.Users
{
    public class UserProfileDto
    {
        public required string Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age => CalculateAge();

        private int CalculateAge()
        {
            if (!DateOfBirth.HasValue) return 0;
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Value.Year;
            if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
