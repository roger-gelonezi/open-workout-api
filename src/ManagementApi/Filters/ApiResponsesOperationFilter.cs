using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ManagementApi.Filters
{
    public class ApiResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add(
                "401",
                new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add(
                "400",
                new OpenApiResponse { Description = "Bad Request" });
        }
    }
}
