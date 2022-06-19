using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Interfaces;
using Auth.Services.Abstractions.Models;
using Auth.Services.Mappers;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<Login> _userManager;

        public RegisterService(UserManager<Login> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var user = registerDto.ToLogin();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            return result;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(GenerateEmailTokenDto emailDto)
        {
            var user = await _userManager.FindByEmailAsync(emailDto.Email);
            if (user == null)
                throw new KeyNotFoundException("Email not found");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return code;
        }

        public async Task<IdentityResult> ConfirmEmailTokenAsync(ActivateEmailDto emailDto)
        {
            var user = await _userManager.FindByEmailAsync(emailDto.Email);
            if (user == null)
                throw new KeyNotFoundException("Email not found");

            var identityResult = await _userManager.ConfirmEmailAsync(user, emailDto.Token);

            return identityResult;
        }
    }
}
