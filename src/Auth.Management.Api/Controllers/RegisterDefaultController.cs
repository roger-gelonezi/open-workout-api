using Auth.Management.Api.Constants;
using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RogerioGelonezi.WebApi.Sdk.Models;

namespace Auth.Management.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterDefaultController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IConfiguration _configuration;

        public RegisterDefaultController(IRegisterService registerService, IConfiguration configuration)
        {
            _registerService = registerService;
            _configuration = configuration;
        }

        /// <summary>
        /// Register the default user from environment variables.
        /// </summary>
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> RegisterDefaultAsync()
        {
            var registerDto = new RegisterDto
            {
                UserName = DefaultLoginConstants.GetDefaultUserName(_configuration),
                Password = DefaultLoginConstants.GetDefaulPassword(_configuration)
            };

            var result = await _registerService.RegisterAsync(registerDto);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(ErrorResponse.FromIdentity(result.Errors));
        }
    }
}
