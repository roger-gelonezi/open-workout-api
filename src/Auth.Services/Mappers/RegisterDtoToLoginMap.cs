using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Services.Mappers
{
    internal static class RegisterDtoToLoginMap
    {
        internal static Login ToLogin(this RegisterDto registerDto)
        {
            return new Login
            {
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserId = registerDto.UserId
            };
        }
    }
}
