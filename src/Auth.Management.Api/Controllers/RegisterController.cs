using Auth.Management.Api.Mappers;
using Auth.Management.Api.ViewModels;
using Auth.Services.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RogerioGelonezi.WebApi.Sdk.Models;

namespace Auth.Management.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        /// <summary>
        /// Register a new authorized user.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerViewModel)
        {
            var result = await _registerService.RegisterAsync(registerViewModel.ToDto());

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(ErrorResponseFactory.FromIdentity(result.Errors));
        }
    }
}
