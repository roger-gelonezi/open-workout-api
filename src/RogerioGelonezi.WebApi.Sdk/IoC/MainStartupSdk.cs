using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace RogerioGelonezi.WebApi.Sdk.IoC
{
    public static class MainStartupSdk
    {
        public static IServiceCollection MainStartup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwagger(configuration);
            services.AddAuthentication(configuration);
            services.AddFilters();
            services.AddNewtonsoftJson();

            return services;
        }
    }
}
