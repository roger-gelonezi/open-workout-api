using AuthManagementApi.Interfaces;
using AuthManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginSucessoViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse))]
        [HttpPost]
        public async Task<IActionResult> Token(LoginViewModel login)
        {
            var token = await _loginService.Login(login);

            if (!string.IsNullOrEmpty(token))
            {                
                var loginSucesso = new LoginSucessoViewModel(login.UserName, token); ;

                return Ok(loginSucesso);
            }

            return Unauthorized(new ErrorResponse(401, "Unauthorized", "The user or password was not valid"));
        }
    }
}
