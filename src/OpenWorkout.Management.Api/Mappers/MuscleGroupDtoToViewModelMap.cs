using OpenWorkout.Management.Api.ViewModel;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Management.Api.Mappers
{
    public static class MuscleGroupDtoToViewModelMap
    {
        public static MuscleGroupViewModel ToViewModel(this MuscleGroupDto muscleGroupDto)
        {
            return new MuscleGroupViewModel
            {
                Id = muscleGroupDto.Id,
                MuscleGroupName = muscleGroupDto.MuscleGroupName,
                LastUpdate = muscleGroupDto.LastUpdate,
            };
        }
    }
}
