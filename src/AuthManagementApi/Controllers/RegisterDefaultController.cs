using AuthManagementApi.Interfaces;
using AuthManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthManagementApi.Controllers
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

        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> RegisterDefault()
        {
            var registerViewModel = new RegisterViewModel
            {
                UserName = _configuration["DefaultUserName"],
                Password = _configuration["DefaultPassword"]
            };

            var result = await _registerService.Register(registerViewModel);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(ErrorResponse.FromIdentity(result.Errors));
        }
    }
}
