using System.ComponentModel.DataAnnotations;

namespace ManagementApi.ViewModel
{
    public class MuscleGroupPostViewModel
    {
        [Required]
        public string MuscleGroupName { get; set; }
    }
}
