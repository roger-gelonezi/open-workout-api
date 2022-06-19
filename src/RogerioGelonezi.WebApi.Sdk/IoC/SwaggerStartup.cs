using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RogerioGelonezi.WebApi.Sdk.Constants;

namespace RogerioGelonezi.WebApi.Sdk.IoC
{
    internal static class SwaggerStartup
    {
        internal static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerTitle = configuration["SwaggerTitle"] ?? SwaggerConstants.SwaggerTitle;
            var swaggerApiVersion = configuration["SwaggerApiVersion"] ?? SwaggerConstants.SwaggerApiVersion;
            var swaggerDescription = configuration["SwaggerDescription"] ?? SwaggerConstants.SwaggerDescription;
            var swaggerLicenseName = configuration["SwaggerLicenseName"] ?? SwaggerConstants.SwaggerLicenseName;
            var swaggerLicenseUrl = configuration["SwaggerLicenseUrl"] ?? SwaggerConstants.SwaggerLicenseUrl;
            var swaggerContactName = configuration["SwaggerContactName"] ?? SwaggerConstants.SwaggerContactName;
            var swaggerContactUrl = configuration["SwaggerContactUrl"] ?? SwaggerConstants.SwaggerContactUrl;
            var swaggerContactEmail = configuration["SwaggerContactEmail"] ?? SwaggerConstants.SwaggerContactEmail;
            var swaggerTermsOfService = configuration["SwaggerTermsOfService"] ?? SwaggerConstants.SwaggerTermsOfService;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = swaggerTitle,
                    Version = swaggerApiVersion,
                    Description = swaggerDescription,
                    Contact = new OpenApiContact
                    {
                        Name = swaggerContactName,
                        Url = new Uri(swaggerContactUrl),
                        Email = swaggerContactEmail
                    },
                    License = new OpenApiLicense
                    {
                        Name = swaggerLicenseName,
                        Url = new Uri(swaggerLicenseUrl)
                    },
                    TermsOfService = new Uri(swaggerTermsOfService)
                });

                c.CustomSchemaIds(x =>
                    x.GetCustomAttributes<DisplayNameAttribute>()?.SingleOrDefault()?.DisplayName
                    ?? x.Name);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "JWT Bearer token is missing",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }
    }
}
