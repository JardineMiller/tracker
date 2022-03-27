using Newtonsoft.Json;

namespace Tracker.API.Features.Identity.Models
{
    public class LoginResponseModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        [JsonIgnore] public string RefreshToken { get; set; }
    }
}