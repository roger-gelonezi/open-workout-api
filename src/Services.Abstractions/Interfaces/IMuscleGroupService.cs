using Services.Abstractions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Interfaces
{
    public interface IMuscleGroupService
    {
        Task<MuscleGroupDto> InsertAsync(MuscleGroupInsertDto muscleGroupDto, CancellationToken cancellationToken);
        Task<MuscleGroupDto> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
