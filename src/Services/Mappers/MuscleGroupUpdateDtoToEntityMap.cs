using Entities;
using Services.Abstractions.Dto;

namespace Services.Mappers
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
