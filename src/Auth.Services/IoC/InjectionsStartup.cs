using Auth.Services.Abstractions.Interfaces;
using Auth.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Services.IoC
{
    internal static class InjectionsStartup
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
