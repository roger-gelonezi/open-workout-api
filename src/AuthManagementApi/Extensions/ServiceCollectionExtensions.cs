using AuthSdk.Interfaces;
using AuthSdk.Services;

namespace AuthManagementApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IRegisterService, RegisterService>();

            return services;
        }
    }
}
