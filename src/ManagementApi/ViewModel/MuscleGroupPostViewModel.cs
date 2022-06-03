using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementApi.ViewModel
{
    [DisplayName("MuscleGroupPost")]
    public class MuscleGroupPostViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string MuscleGroupName { get; set; }
    }
}
