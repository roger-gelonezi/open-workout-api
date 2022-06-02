using AuthManagementApi.Interfaces;
using AuthManagementApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthManagementApi.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<Login> _userManager;
        public RegisterService(UserManager<Login> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterViewModel registerViewModel)
        {
            var user = new Login
            {
                UserName = registerViewModel.UserName,
                AthleteId = registerViewModel.AthleteId
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            return result;
        }
    }
}
