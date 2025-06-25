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
                var exception = ex is AggregateException aggregate && aggregate.InnerExceptions.Count == 1
                    ? aggregate.InnerExceptions[0]
                    : ex;

                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(
                exception,
                "Exception Details: Type: {ExceptionType}, Message: {Message}",
                exception.GetType().Name,
                exception.Message);

            var statusCode = GetStatusCode(exception);
            var response = CreateErrorResponse(context, exception, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private sealed class ErrorResponse
        {
            public int Status { get; init; }
            public string Title { get; init; } = string.Empty;
            public string Detail { get; init; } = string.Empty;
            public PathString Instance { get; init; }
            public string TraceId { get; init; } = string.Empty;
            public object? Errors { get; init; }
            public string[]? StackTrace { get; init; }
            public string? InnerException { get; init; }
        }

        private ErrorResponse CreateErrorResponse(HttpContext context, Exception exception, int statusCode)
        {
            return new ErrorResponse
            {
                Status = statusCode,
                Title = GetTitle(exception),
                Detail = exception.Message,
                Instance = context.Request.Path,
                TraceId = context.TraceIdentifier,
                Errors = GetErrors(exception),
                StackTrace = _isDevelopment ? exception.StackTrace?.Split('\n') : null,
                InnerException = _isDevelopment ? exception.InnerException?.Message : null
            };
        }

        private static int GetStatusCode(Exception exception)
        {
            if (exception.InnerException != null)
            {
                var innerStatusCode = GetStatusCode(exception.InnerException);
                if (innerStatusCode != (int)HttpStatusCode.InternalServerError)
                    return innerStatusCode;
            }

            return exception switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }

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