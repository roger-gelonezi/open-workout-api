using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ManagementApi.Models
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        public static ErrorResponse FromException(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return new ErrorResponse
            {
                Code = ex.HResult,
                Message = ex.Message,
                InnerError = ErrorResponse.FromException(ex.InnerException)
            };
        }

        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            return new ErrorResponse
            {
                Code = 100,
                Message = "There were error(s) in the request.",
                Details = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }

        public static ErrorResponse FromBadRequest(string message, string detail = null)
        {
            var details = new string[] { detail };

            return new ErrorResponse
            {
                Code = 400,
                Message = message,
                Details = details,
            };
        }
    }
}
