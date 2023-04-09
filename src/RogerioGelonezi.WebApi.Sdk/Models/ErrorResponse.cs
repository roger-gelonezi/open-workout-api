using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RogerioGelonezi.WebApi.Sdk.Models
{
    public class ErrorResponse
    {
        public int? Code { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public ErrorResponse? InnerError { get; set; }
        public string[]? Details { get; set; }
        public string? TraceId { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(int code, string title, string message)
        {
            Code = code;
            Title = title;
            Message = message;
        }
    }
}
