using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ManagementApi.Filters
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag> {
                new  OpenApiTag { Name = "MuscleGroup", Description = "Allow you to connect a exercise into an muscle group, making filters easier." },
            };
        }
    }
}
