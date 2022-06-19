using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RogerioGelonezi.WebApi.Sdk.Filters;
using RogerioGelonezi.WebApi.Sdk.Models;

namespace RogerioGelonezi.WebApi.Sdk.IoC
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
