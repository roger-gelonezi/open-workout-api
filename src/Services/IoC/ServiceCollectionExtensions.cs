using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Repository.Context;
using Repository.Abstractions.Interfaces;
using Repository;
using Services.Abstractions.Interfaces;

namespace Services.IoC
{
    public static class ServiceCollectionExtensions
    {        
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OpenWorkoutContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OpenWorkoutDb"));
            });

            services.AddTransient<IMuscleGroupRepository, MuscleGroupRepository>();

            return services;
        }

        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddTransient<IMuscleGroupService, MuscleGroupService>();

            return services;
        }
    }
}
