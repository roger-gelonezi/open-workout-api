using AuthManagementApi.ViewModels;
using AuthSdk.Dto;

namespace AuthManagementApi.Mappers
{
    public static class RegisterViewModelToDtoMap
    {
        public static RegisterDto ToDto(this RegisterViewModel registerViewModel)
        {
            return new RegisterDto
            {
                UserName = registerViewModel.UserName,
                Password = registerViewModel.Password,
                UserId = registerViewModel.UserId
            };
        }
    }
}
