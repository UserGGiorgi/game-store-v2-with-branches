using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace GameStore.Web.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly bool _isDevelopment;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _isDevelopment = env.IsDevelopment();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            var statusCode = GetStatusCode(exception);
            var response = CreateErrorResponse(context, exception, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private object CreateErrorResponse(HttpContext context, Exception exception, int statusCode)
        {
            var errorResponse = new
            {
                Status = statusCode,
                Title = GetTitle(exception),
                Detail = exception.Message,
                Instance = context.Request.Path,
                TraceId = context.TraceIdentifier,
                Errors = GetErrors(exception)
            };

            if (_isDevelopment)
            {
                return new
                {
                    errorResponse.Status,
                    errorResponse.Title,
                    errorResponse.Detail,
                    errorResponse.Instance,
                    errorResponse.TraceId,
                    errorResponse.Errors,
                    StackTrace = exception.StackTrace?.Split('\n'),
                    InnerException = exception.InnerException?.Message
                };
            }

            return errorResponse;
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                BadRequestException => "Bad Request",
                NotFoundException => "Not Found",
                UnauthorizedAccessException => "Unauthorized",
                _ => "Internal Server Error"
            };

        private static object? GetErrors(Exception exception) =>
            exception switch
            {
                BadRequestException badRequest => badRequest.Errors,
                _ => null
            };
    }

    public class BadRequestException : Exception
    {
        public object? Errors { get; }

        public BadRequestException(string message, object? errors = null)
            : base(message)
        {
            Errors = errors;
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}