using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Abstractions.Interfaces;
using Repository.Context;
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

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMuscleGroupService, MuscleGroupService>();

            return services;
        }
    }
}
