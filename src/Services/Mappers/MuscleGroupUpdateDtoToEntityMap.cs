using Entities;
using Services.Abstractions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
