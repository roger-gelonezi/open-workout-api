using System.ComponentModel.DataAnnotations;

namespace ManagementApi.ViewModel
{
    public class MuscleGroupPostViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string MuscleGroupName { get; set; }
    }
}
