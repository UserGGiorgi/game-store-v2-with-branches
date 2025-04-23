using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
            _logger.LogError(exception, "An unexpected error occurred");

            var statusCode = GetStatusCode(exception);
            var response = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = GetTitle(exception),
                Status = statusCode,
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            if (exception is BadRequestException badRequestException)
            {
                response.Extensions.Add("errors", badRequestException.Message);
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(response);
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                BadRequestException => "Bad Request",
                NotFoundException => "Not Found",
                _ => "Internal Server Error"
            };
    }
}
