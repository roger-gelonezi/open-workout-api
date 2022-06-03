using ManagementApi.ViewModel;
using Services.Abstractions.Dto;

namespace ManagementApi.Mappers
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
