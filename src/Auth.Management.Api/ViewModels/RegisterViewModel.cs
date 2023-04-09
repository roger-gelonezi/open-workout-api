using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auth.Management.Api.ViewModels
{
    [DisplayName("Register")]
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Repassword { get; set; }

        public Guid UserId { get; set; }
    }
}
