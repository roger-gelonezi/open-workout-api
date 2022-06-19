using Auth.Management.Api.ViewModels;
using Auth.Services.Abstractions.Dto;

namespace Auth.Management.Api.Mappers
{
    public static class LoginViewModelToDtoMap
    {
        public static LoginDto ToDto(this LoginViewModel loginViewModel)
        {
            return new LoginDto
            {
                UserName = loginViewModel.UserName,
                Email = loginViewModel.Email,
                Password = loginViewModel.Password,
            };
        }
    }
}
