using OpenWorkout.Management.Api.ViewModel;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Management.Api.Mappers
{
    public static class MuscleGroupPostViewModelToDtoMap
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
