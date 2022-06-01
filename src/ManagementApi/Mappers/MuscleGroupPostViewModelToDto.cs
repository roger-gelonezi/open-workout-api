using ManagementApi.ViewModel;
using Services.Abstractions.Dto;

namespace ManagementApi.Mappers
{
    public static class MuscleGroupPostViewModelToDto
    {
        public static MuscleGroupInsertDto ToDto(this MuscleGroupPostViewModel muscleGroupPostViewModel)
        {
            return new MuscleGroupInsertDto
            {
                MuscleGroupName = muscleGroupPostViewModel.MuscleGroupName
            };
        }
    }
}
