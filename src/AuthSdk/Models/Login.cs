using Microsoft.AspNetCore.Identity;

namespace AuthSdk.Models
{
    public class Login : IdentityUser
    {
        public Guid UserId { get; set; }
    }
}
