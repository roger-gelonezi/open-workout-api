using System.ComponentModel;

namespace OpenWorkout.Management.Api.ViewModel
{
    [DisplayName("MuscleGroup")]
    public class MuscleGroupViewModel
    {
        public Guid Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public string MuscleGroupName { get; set; }
    }
}
