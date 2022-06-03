using AuthSdk.Dto;
using Microsoft.AspNetCore.Identity;

namespace AuthSdk.Interfaces
{
    public interface IRegisterService
    {
        Task<IdentityResult> Register(RegisterDto model);
    }
}
