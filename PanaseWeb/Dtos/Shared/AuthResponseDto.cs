using PanaseWeb.Dtos.Users;

namespace PanaseWeb.Dtos.Shared
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public UserProfileDto UserProfile { get; set; }
    }
}
