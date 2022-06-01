using ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ManagementApi.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = ErrorResponse.FromException(context.Exception);
            if (context.Exception is ArgumentException)
            {
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                context.Result = new ObjectResult(errorResponse) { StatusCode = 500 };
            }
        }
    }
}
