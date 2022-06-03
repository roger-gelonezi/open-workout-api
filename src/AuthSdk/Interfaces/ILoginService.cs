using AuthSdk.Dto;

namespace AuthSdk.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(LoginDto login);
    }
}