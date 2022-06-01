using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstractions;

namespace Entities
{
    public class MuscleGroup : Entity
    {
        public string MuscleGroupName { get; set; }
    }
}