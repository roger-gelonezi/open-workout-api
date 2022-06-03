using StartupSdk.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Global.Models;

namespace StartupSdk.IoC
{
    internal static class FiltersStartup
    {
        internal static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ErrorResponseFilter)))
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    return new BadRequestObjectResult(ErrorResponse.FromModelState(context.ModelState));
                };
            });

            return services;
        }
    }
}
