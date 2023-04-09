using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogerioGelonezi.WebApi.Sdk.Models
{
    public static class ErrorResponseFactory
    {
        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(m => m.Errors);
            return new ErrorResponse
            {
                Code = 100,
                Title = "Request Error",
                Message = "There were error(s) in the request.",
                Details = errors.Select(e => e.ErrorMessage).ToArray()
            };
        }

        public static ErrorResponse FromException(Exception ex)
        {
            return new ErrorResponse
            {
                Code = ex.HResult,
                Title = "Exception",
                Message = ex.Message,
                InnerError = FromException(ex.InnerException),
                TraceId = ex.StackTrace
            };
        }

        public static ErrorResponse FromIdentity(IEnumerable<IdentityError> errors)
        {
            return new ErrorResponse
            {
                Code = 400,
                Title = "Request Error",
                Message = "There were error(s) in the request.",
                Details = errors.Select(e => e.Description).ToArray()
            };
        }
    }
}
