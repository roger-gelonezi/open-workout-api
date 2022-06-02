using AuthManagementApi.Interfaces;
using AuthManagementApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthManagementApi.Services
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

        public async Task<string> Login (LoginViewModel login)
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
                        new Claim("AthleteId", user.AthleteId.ToString()),
                    };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["SecretJWT"]));
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
