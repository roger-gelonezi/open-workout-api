using AuthManagementApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthManagementApi.Interfaces
{
    public interface IRegisterService
    {
        Task<IdentityResult> Register(RegisterViewModel model);
    }
}
