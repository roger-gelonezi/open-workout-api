using Entities;
using Repository.Abstractions;
using Repository.Abstractions.Interfaces;
using Repository.Context;

namespace Repository
{
    public class MuscleGroupRepository : RepositoryBase<MuscleGroup>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(OpenWorkoutContext context) : base(context) { }
    }
}
