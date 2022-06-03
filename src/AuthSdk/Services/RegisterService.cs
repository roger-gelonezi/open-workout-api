using AuthSdk.Dto;
using AuthSdk.Interfaces;
using AuthSdk.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthSdk.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<Login> _userManager;

        public RegisterService(UserManager<Login> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterDto registerViewModel)
        {
            var user = new Login
            {
                UserName = registerViewModel.UserName,
                UserId = registerViewModel.UserId
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            return result;
        }
    }
}
