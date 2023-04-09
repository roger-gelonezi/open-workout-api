using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RogerioGelonezi.WebApi.Sdk.Models;

namespace RogerioGelonezi.WebApi.Sdk.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = ErrorResponseFactory.FromException(context.Exception);
            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = ResolveStatusCode(context.Exception)
            };
        }

        private static int ResolveStatusCode(Exception exception)
        {
            return exception switch
            {
                KeyNotFoundException => 404,
                ArgumentException => 400,
                _ => 500,
            };
        }
    }
}
