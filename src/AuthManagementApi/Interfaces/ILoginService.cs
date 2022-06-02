using AuthManagementApi.Models;

namespace AuthManagementApi.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(LoginViewModel login);
    }
}
