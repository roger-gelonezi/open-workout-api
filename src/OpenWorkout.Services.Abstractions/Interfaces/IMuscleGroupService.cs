using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Services.Abstractions.Interfaces
{
    public interface IMuscleGroupService
    {
        Task<MuscleGroupDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<MuscleGroupDto> InsertAsync(MuscleGroupInsertDto muscleGroupDto, CancellationToken cancellationToken);
        Task<MuscleGroupDto> UpdateAsync(MuscleGroupUpdateDto muscleGroupDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IList<MuscleGroupDto>> GetListAsync(MuscleGroupGetListDto muscleGroupListDto);
        Task<int> GetListCountAsync(MuscleGroupGetListDto muscleGroupListDto);
    }
}
