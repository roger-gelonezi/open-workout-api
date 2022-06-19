using OpenWorkout.Entities;
using OpenWorkout.Repository.Abstractions.Interfaces;
using OpenWorkout.Repository.Context;
using RogerioGelonezi.Repository.Sdk;

namespace OpenWorkout.Repository.Repositories
{
    public class MuscleGroupRepository : RepositoryBase<MuscleGroup>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(OpenWorkoutContext context) : base(context) { }
    }
}
