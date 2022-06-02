using ManagementApi.Mappers;
using ManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Interfaces;

namespace ManagementApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MuscleGroupPostViewModel muscleGroupViewModel, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.InsertAsync(muscleGroupViewModel.ToDto(), cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = muscleGroupDto.Id }, muscleGroupDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.GetAsync(id, cancellationToken);

            if (muscleGroupDto == null) 
                return NotFound();

            return Ok(muscleGroupDto);
        }
    }
}
