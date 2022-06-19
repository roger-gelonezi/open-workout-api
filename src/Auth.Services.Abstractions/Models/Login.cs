using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Abstractions.Models
{
    public class Login : IdentityUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
