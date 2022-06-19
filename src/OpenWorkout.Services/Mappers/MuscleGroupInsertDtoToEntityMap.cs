using OpenWorkout.Entities;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Services.Mappers
{
    internal static class MuscleGroupInsertDtoToEntityMap
    {
        public static MuscleGroup ToEntity(this MuscleGroupInsertDto muscleGroupDto)
        {
            var muscleGroup = new MuscleGroup()
            {
                MuscleGroupName = muscleGroupDto.MuscleGroupName,
            };

            return muscleGroup;
        }
    }
}
