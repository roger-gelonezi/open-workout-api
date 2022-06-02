using Repository.Abstractions.Interfaces;
using Services.Abstractions.Dto;
using Services.Abstractions.Interfaces;
using Services.Mappers;

namespace Services
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupService(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }

        public async Task<MuscleGroupDto> InsertAsync(MuscleGroupInsertDto muscleGroupDto, CancellationToken cancellationToken)
        {
            var muscleGroup = muscleGroupDto.ToEntity();

            await _muscleGroupRepository.InsertAsync(muscleGroup, cancellationToken);

            return muscleGroup.ToDto();
        }

        public async Task<MuscleGroupDto?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var muscleGroup = await _muscleGroupRepository.SelectByIdAsync(id, cancellationToken);

            return muscleGroup?.ToDto();
        }
    }
}