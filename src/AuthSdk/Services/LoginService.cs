using AuthSdk.Dto;
using AuthSdk.Interfaces;
using AuthSdk.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthSdk.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<Login> _userManager;
        private readonly SignInManager<Login> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginService(UserManager<Login> userManager, SignInManager<Login> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> Login (LoginDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>()
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, login.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                    };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var jwtSecret = Global.Constants.JwtConstants.GetJwtSecret(_configuration);

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSecret));
                var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }

            return string.Empty;
        }
    }
}
