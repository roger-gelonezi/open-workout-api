using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Auth.Services.Context;

namespace Auth.Services.IoC
{
    internal static class DatabaseStartup
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthContext>(options =>
            {
                // options.UseMySQL(configuration.GetConnectionString("AuthDb"));
                options.UseSqlServer(configuration.GetConnectionString("AuthDb"));
            });

            return services;
        }
    }
}
