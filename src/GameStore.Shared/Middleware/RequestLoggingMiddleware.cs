using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var originalResponseBody = context.Response.Body;

            var requestBuffer = new MemoryStream();
            var responseBuffer = new MemoryStream();

            var requestBody = await CaptureRequest(context.Request, requestBuffer);

            context.Response.Body = responseBuffer;

            try
            {
                await _next(context);
                stopwatch.Stop();
            }
            finally
            {
                var responseBody = await CaptureResponse(responseBuffer);

                var elapsedMs = stopwatch.ElapsedMilliseconds;

                _logger.LogInformation(
                    "Request: IP: {IP}, Method: {Method}, Path: {Path}, Status: {StatusCode}, Elapsed: {Elapsed}ms\n" +
                    "Request Headers: {RequestHeaders}\nRequest Body: {RequestBody}\n" +
                    "Response Headers: {ResponseHeaders}\nResponse Body: {ResponseBody}",
                    context.Connection.RemoteIpAddress,
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    elapsedMs,
                    FormatHeaders(context.Request.Headers),
                    requestBody,
                    FormatHeaders(context.Response.Headers),
                    responseBody);

                responseBuffer.Seek(0, SeekOrigin.Begin);
                await responseBuffer.CopyToAsync(originalResponseBody);
                context.Response.Body = originalResponseBody;

                requestBuffer.Dispose();
                responseBuffer.Dispose();
            }
        }

        private async Task<string> CaptureRequest(HttpRequest request, MemoryStream buffer)
        {
            await request.Body.CopyToAsync(buffer);
            buffer.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(buffer, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            buffer.Seek(0, SeekOrigin.Begin);

            request.Body = buffer;

            return body;
        }

        private async Task<string> CaptureResponse(MemoryStream responseBuffer)
        {
            responseBuffer.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(responseBuffer, Encoding.UTF8, leaveOpen: true);
            return await reader.ReadToEndAsync();
        }

        private string FormatHeaders(IHeaderDictionary headers)
        {
            return string.Join(", ", headers.Select(h => $"{h.Key}: {h.Value}"));
        }
    }
}