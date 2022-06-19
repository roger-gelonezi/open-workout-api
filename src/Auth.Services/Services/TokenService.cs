using Auth.Services.Abstractions.Dto;
using Auth.Services.Abstractions.Interfaces;
using Auth.Services.Abstractions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<Login> _userManager;

        private readonly IConfiguration _configuration;

        public TokenService(UserManager<Login> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateTokenAsync(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("UserName", login.UserName),
                        new Claim("Email", login.Email)
                    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtSecret = RogerioGelonezi.WebApi.Sdk.Constants.JwtConstants.GetJwtSecret(_configuration);

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSecret));
            var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(60)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
