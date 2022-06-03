using ManagementApi.ViewModel;
using Services.Abstractions.Dto;

namespace ManagementApi.Mappers
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
