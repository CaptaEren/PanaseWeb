﻿namespace PanaseWeb.Dtos.Users
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // "Patient", "Psychologist", "Admin"
    }
}
