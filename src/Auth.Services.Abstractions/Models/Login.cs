using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Abstractions.Models
{
    public class Login : IdentityUser
    {
        public Guid UserId { get; set; }
    }
}
