using Auth.Services.Abstractions.Dto;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Abstractions.Interfaces
{
    public interface IRegisterService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto model);
        Task<string> GenerateEmailConfirmationTokenAsync(GenerateEmailTokenDto emailDto);
        Task<IdentityResult> ConfirmEmailTokenAsync(ActivateEmailDto emailDto);
    }
}
