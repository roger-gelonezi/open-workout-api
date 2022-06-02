using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AuthManagementApi.Filters
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag> {
                new  OpenApiTag { Name = "Login", Description = "Provides a new token." },
                new  OpenApiTag { Name = "Register", Description = "Register a new authorized user." },
                new  OpenApiTag { Name = "RegisterDefault", Description = "Register the default user from environment variables." },
            };
        }
    }
}
