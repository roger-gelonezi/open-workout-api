using Services.Abstractions.Dto;

namespace Services.Abstractions.Interfaces
{
    public interface IMuscleGroupService
    {
        Task<MuscleGroupDto> InsertAsync(MuscleGroupInsertDto muscleGroupDto, CancellationToken cancellationToken);
        Task<MuscleGroupDto> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
