using System.Net;
using System.Text.Json;
using UpSkills.Api.Exceptions;

namespace UpSkills.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var appError = new AppError(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)appError.StatusCode;
            await context.Response.WriteAsync(appError.ToString());
        }
    }

    public class AppError
    {
        public string Message { get; set; }

        // object pour la sérialisation
        public object? Details { get; set; }

        public ErrorKeys ErrorKey { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public AppError(Exception exception)
        {
            Message = exception.Message;

            if (exception is ExceptionBase exceptionBase)
            {
                StatusCode = HttpStatusCode.BadRequest;
                ErrorKey = exceptionBase.ErrorKey;
            }
            else
            {
                StatusCode = HttpStatusCode.InternalServerError;
                ErrorKey = ErrorKeys.Undefined;
            }


            if (exception is IHasErrorDetails hasErrorDetails)
                Details = hasErrorDetails.ErrorDetails;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
