using Microsoft.AspNetCore.Identity;

namespace AuthManagementApi.Models
{
    public class Login : IdentityUser
    {
        public Guid AthleteId { get; set; }
    }
}
