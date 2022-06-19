using OpenWorkout.Entities;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Services.Mappers
{
    internal static class MuscleGroupEntityToDtoMap
    {
        public static MuscleGroupDto ToDto(this MuscleGroup muscleGroup)
        {
            var muscleGroupDto = new MuscleGroupDto()
            {
                Id = muscleGroup.Id,
                LastUpdate = muscleGroup.LastUpdate,
                MuscleGroupName = muscleGroup.MuscleGroupName,
            };

            return muscleGroupDto;
        }
    }
}
