using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthManagementApi.ViewModels
{
    [DisplayName("Register")]
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        public Guid UserId { get; set; }
    }
}
