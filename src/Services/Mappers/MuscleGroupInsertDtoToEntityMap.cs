using Entities;
using Services.Abstractions.Dto;

namespace Services.Mappers
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
