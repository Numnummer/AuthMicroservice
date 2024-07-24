using Microsoft.AspNetCore.Identity;

namespace AuthMicroservice.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsEmailConfirmed { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
