using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthManagementApi.Models
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }
        public string? TraceId { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(int code, string title, string message)
        {
            Code = code;
            Title = title;
            Message = message;
        }

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
            if (ex == null)
            {
                return null;
            }

            return new ErrorResponse
            {
                Code = ex.HResult,
                Title = "Exception",
                Message = ex.Message,
                InnerError = ErrorResponse.FromException(ex.InnerException),
                TraceId = ex.StackTrace
            };
        }

        public static ErrorResponse FromIdentity(IEnumerable<IdentityError> errors)
        {
            if (errors == null)
            {
                return null;
            }

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
