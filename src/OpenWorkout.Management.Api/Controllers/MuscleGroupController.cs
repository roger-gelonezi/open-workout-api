using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWorkout.Management.Api.Mappers;
using OpenWorkout.Management.Api.ViewModel;
using OpenWorkout.Services.Abstractions.Interfaces;
using RogerioGelonezi.WebApi.Sdk.Models;
using RogerioGelonezi.WebApi.Sdk.ViewModels;
using OpenWorkout.Services.Abstractions.Dto;

namespace OpenWorkout.Management.Api.Controllers
{
    // [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }

        /// <summary>
        /// Returns a Muscle Group by its ID.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MuscleGroupViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.GetByIdAsync(id, cancellationToken);

            if (muscleGroupDto == null)
                return NotFound();

            return Ok(muscleGroupDto.ToViewModel());
        }

        /// <summary>
        /// Register new muscle group.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> Post(MuscleGroupPostViewModel muscleGroupViewModel, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.InsertAsync(muscleGroupViewModel.ToDto(), cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = muscleGroupDto.Id }, muscleGroupDto);
        }

        /// <summary>
        /// Changes muscle group.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MuscleGroupViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPut]
        public async Task<IActionResult> Put(MuscleGroupPutViewModel muscleGroupViewModel, CancellationToken cancellationToken)
        {
            var muscleGroupDto = await _muscleGroupService.UpdateAsync(muscleGroupViewModel.ToDto(), cancellationToken);

            return Ok(muscleGroupDto.ToViewModel());
        }

        /// <summary>
        /// Deletes muscle group, the exercises linked to it will get unlinked.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _muscleGroupService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Brings a list of muscle group, it can be paged.
        /// </summary>
        /// <param name="muscleGroupName"></param>
        /// <param name="lastUpdateSince"></param>
        /// <param name="orderBy">Inform the field name. Use sulfix " desc" for descendent order</param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListViewModel<MuscleGroupViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
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
