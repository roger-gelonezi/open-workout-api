using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Interfaces;
using Auth.Services.Abstractions.Models;
using Auth.Services.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Login> _signInManager;

        public LoginService(ITokenService tokenService, SignInManager<Login> signInManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<string> LoginAsync(LoginDto login)
        {
            await LoginDtoHelper.ResolveProperties(login, _signInManager);
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if (result.Succeeded)
            {
                return await _tokenService.CreateTokenAsync(login);
            }

            return string.Empty;
        }
    }
}
