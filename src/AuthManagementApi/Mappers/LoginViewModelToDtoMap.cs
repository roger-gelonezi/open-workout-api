using AuthManagementApi.ViewModels;
using AuthSdk.Dto;

namespace AuthManagementApi.Mappers
{
    public static class LoginViewModelToDtoMap
    {
        public static LoginDto ToDto(this LoginViewModel loginViewModel)
        {
            return new LoginDto
            {
                UserName = loginViewModel.UserName,
                Password = loginViewModel.Password,
            };
        }
    }
}
