using OpenWorkout.Entities;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Services.Mappers
{
    internal static class MuscleGroupUpdateDtoToEntityMap
    {
        public static MuscleGroup ToEntity(this MuscleGroupUpdateDto muscleGroupDto)
        {
            var muscleGroup = new MuscleGroup()
            {
                Id = muscleGroupDto.Id,
                MuscleGroupName = muscleGroupDto.MuscleGroupName,
            };

            return muscleGroup;
        }
    }
}
