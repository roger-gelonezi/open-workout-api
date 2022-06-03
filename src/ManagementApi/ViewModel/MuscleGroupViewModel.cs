using System.ComponentModel;

namespace ManagementApi.ViewModel
{
    [DisplayName("MuscleGroup")]
    public class MuscleGroupViewModel
    {
        public Guid Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public string MuscleGroupName {get;set;}
    }
}
