using Auth.Management.Api.ViewModels;
using Auth.Services.Abstractions.Dto;

namespace Auth.Management.Api.Mappers
{
    public static class RegisterViewModelToDtoMap
    {
        public static RegisterDto ToDto(this RegisterViewModel registerViewModel)
        {
            return new RegisterDto
            {
                UserName = registerViewModel.UserName,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                UserId = registerViewModel.UserId
            };
        }
    }
}
