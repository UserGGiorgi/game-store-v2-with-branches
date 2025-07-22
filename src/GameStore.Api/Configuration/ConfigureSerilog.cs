using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;

namespace GameStore.Api.Configuration
{
    public static class SerilogConfig
    {
        public static void ConfigureSerilog(this WebApplicationBuilder builder)
        {
            var logPath = Path.Combine(builder.Environment.ContentRootPath, "Logs");
            Directory.CreateDirectory(logPath);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()

                .WriteTo.File(
                    Path.Combine(logPath, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

                .WriteTo.File(
                    Path.Combine(logPath, "errors-.txt"),
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}