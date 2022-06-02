using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthManagementApi.Models
{
    [DisplayName("Login")]
    public class LoginViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
