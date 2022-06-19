using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auth.Management.Api.ViewModels
{
    [DisplayName("Login")]
    public class LoginViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
