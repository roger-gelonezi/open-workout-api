using Entities;
using Services.Abstractions.Dto;

namespace Services.Mappers
{
    internal static class MuscleGroupEntityToDtoMap
    {
        public static MuscleGroupDto ToDto(this MuscleGroup muscleGroup)
        {
            var muscleGroupDto = new MuscleGroupDto()
            {
                Id = muscleGroup.Id,
                CreationDate = muscleGroup.CreationDate,
                LastUpdate = muscleGroup.LastUpdate,
                MuscleGroupName = muscleGroup.MuscleGroupName,
            };

            return muscleGroupDto;
        }
    }
}
