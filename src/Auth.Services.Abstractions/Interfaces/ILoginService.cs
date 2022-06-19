using Auth.Services.Abstractions.Dto;

namespace Auth.Services.Abstractions.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginDto login);
    }
}