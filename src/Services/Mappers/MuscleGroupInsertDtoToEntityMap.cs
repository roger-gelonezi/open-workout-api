using Entities;
using Services.Abstractions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
