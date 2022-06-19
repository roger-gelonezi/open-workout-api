using Microsoft.EntityFrameworkCore;
using OpenWorkout.Repository.Abstractions.Interfaces;
using OpenWorkout.Services.Extensions;
using OpenWorkout.Services.Mappers;
using OpenWorkout.Services.Abstractions.Interfaces;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Services.Services
{
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupService(IMuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }
        public async Task<MuscleGroupDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var muscleGroup = await _muscleGroupRepository.SelectByIdAsync(id, cancellationToken);

            return muscleGroup?.ToDto();
        }

        public async Task<MuscleGroupDto> InsertAsync(MuscleGroupInsertDto muscleGroupDto, CancellationToken cancellationToken)
        {
            var muscleGroup = muscleGroupDto.ToEntity();

            await _muscleGroupRepository.InsertAsync(muscleGroup, cancellationToken);

            return muscleGroup.ToDto();
        }

        public async Task<MuscleGroupDto> UpdateAsync(MuscleGroupUpdateDto muscleGroupDto, CancellationToken cancellationToken)
        {
            var muscleGroup = muscleGroupDto.ToEntity();

            await _muscleGroupRepository.UpdateAsync(muscleGroup, cancellationToken);

            return muscleGroup.ToDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _muscleGroupRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IList<MuscleGroupDto>> GetListAsync(MuscleGroupGetListDto muscleGroupListDto)
        {
            var muscleGroupList = await _muscleGroupRepository.All
                .SetFilter(muscleGroupListDto.MuscleGroupName)
                .SetQueryParams(muscleGroupListDto)
                .Select(m => m.ToDto())
                .ToListAsync();

            return muscleGroupList;
        }

        public async Task<int> GetListCountAsync(MuscleGroupGetListDto muscleGroupListDto)
        {
            var muscleGroupListCount = await _muscleGroupRepository.All
                .SetFilter(muscleGroupListDto.MuscleGroupName)
                .SetLastUpdateFilter(muscleGroupListDto.LastUpdateSince)
                .CountAsync();

            return muscleGroupListCount;
        }
    }
}