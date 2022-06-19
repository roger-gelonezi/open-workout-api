using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OpenWorkout.Services.Services;
using OpenWorkout.Repository.Context;
using OpenWorkout.Repository.Abstractions.Interfaces;
using OpenWorkout.Repository.Repositories;
using OpenWorkout.Services.Abstractions.Interfaces;

namespace OpenWorkout.Services.IoC
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
