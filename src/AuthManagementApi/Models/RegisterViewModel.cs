using System.ComponentModel;

namespace AuthManagementApi.Models
{
    [DisplayName("Register")]
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid AthleteId { get; set; }
    }
}
