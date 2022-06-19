using OpenWorkout.Management.Api.ViewModel;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Management.Api.Mappers
{
    public static class MuscleGroupPutViewModelToDtoMap
    {
        public static MuscleGroupUpdateDto ToDto(this MuscleGroupPutViewModel muscleGroupPutViewModel)
        {
            return new MuscleGroupUpdateDto
            {
                Id = muscleGroupPutViewModel.Id,
                MuscleGroupName = muscleGroupPutViewModel.MuscleGroupName
            };
        }
    }
}
