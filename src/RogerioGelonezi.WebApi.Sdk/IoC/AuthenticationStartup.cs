using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RogerioGelonezi.WebApi.Sdk.IoC;
using RogerioGelonezi.WebApi.Sdk.Constants;

namespace RogerioGelonezi.WebApi.Sdk.IoC
{
    internal static class AuthenticationStartup
    {
        internal static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSecret = JwtConstants.GetJwtSecret(configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                };
            });

            return services;
        }
    }
}
