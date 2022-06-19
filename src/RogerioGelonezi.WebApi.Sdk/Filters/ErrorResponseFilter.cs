using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RogerioGelonezi.WebApi.Sdk.Models;

namespace RogerioGelonezi.WebApi.Sdk.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = ErrorResponse.FromException(context.Exception);
            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = ResolveStatusCode(context.Exception)
            };
        }

        private static int ResolveStatusCode(Exception exception)
        {
            switch (exception)
            {
                case KeyNotFoundException:
                    return 404;
                case ArgumentException:
                    return 400;
                default:
                    return 500;
            }
        }
    }
}
