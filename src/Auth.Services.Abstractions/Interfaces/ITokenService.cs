using Auth.Services.Abstractions.Dto;

namespace Auth.Services.Abstractions.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(LoginDto login);
    }
}
