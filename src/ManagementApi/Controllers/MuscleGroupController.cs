using ManagementApi.Mappers;
using ManagementApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Dto;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.GetByIdAsync(id, cancellationToken);

            if (muscleGroupDto == null)
                return NotFound();

            return Ok(muscleGroupDto.ToViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Post(MuscleGroupPostViewModel muscleGroupViewModel, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.InsertAsync(muscleGroupViewModel.ToDto(), cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = muscleGroupDto.Id }, muscleGroupDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MuscleGroupPutViewModel muscleGroupViewModel, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.UpdateAsync(muscleGroupViewModel.ToDto(), cancellationToken);

            return Ok(muscleGroupDto.ToViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _muscleGroupService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery(Name = "muscle-group-name")] string? muscleGroupName,
            [FromQuery(Name = "last-update-since")] DateTime? lastUpdateSince,
            [FromQuery(Name = "order-by")] string? orderBy,
            [FromQuery(Name = "page-size")] int? pageSize,
            [FromQuery] int? page)
        {
            var muscleGroupGetListDto = new MuscleGroupGetListDto
            {
                MuscleGroupName = muscleGroupName,
                LastUpdateSince = lastUpdateSince,
                OrderBy = orderBy,
                PageSize = pageSize,
                Page = page
            };

            var muscleGroupList = await _muscleGroupService.GetListAsync(muscleGroupGetListDto);            
            var muscleGroupListCount = await _muscleGroupService.GetListCountAsync(muscleGroupGetListDto);

            var muscleGroupListViewModel = muscleGroupList.Select(m => m.ToViewModel()).ToList();

            var muscleGroupPaged = new PagedListViewModel<MuscleGroupViewModel>
            (
                page,
                pageSize,
                muscleGroupListCount,
                muscleGroupListViewModel
            );
            
            return Ok(muscleGroupPaged);
        }
    }
}
