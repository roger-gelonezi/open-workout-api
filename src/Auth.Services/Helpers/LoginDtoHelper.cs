using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Services.Helpers
{
    internal static class LoginDtoHelper
    {
        internal static async Task ResolveProperties(LoginDto login, SignInManager<Login> signInManager)
        {
            if (!string.IsNullOrEmpty(login.UserName))
                return;

            var user = await signInManager
                .UserManager.FindByEmailAsync(login.Email);

            login.UserName = user.UserName;
        }
    }
}
