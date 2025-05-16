using System;
using System.IO;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace GameStore.Web.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;
        private readonly object _lock = new object();
        private static bool _warnedAboutPermissions = false;

        public FileLogger(string categoryName, string filePath)
        {
            _categoryName = categoryName ?? "Default";
            _filePath = GetSafeLogPath(filePath);
        }

        private string GetSafeLogPath(string requestedPath)
        {
            // First try the requested path
            try
            {
                var directory = Path.GetDirectoryName(requestedPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                return requestedPath;
            }
            catch
            {
                var appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "GameStore",
                    "Logs",
                    "application.log");

                try
                {
                    var fallbackDir = Path.GetDirectoryName(appDataPath);
                    if (!Directory.Exists(fallbackDir))
                    {
                        Directory.CreateDirectory(fallbackDir);
                    }

                    if (!_warnedAboutPermissions)
                    {
                        Console.WriteLine($"Warning: Could not write to {requestedPath}. Using fallback location: {appDataPath}");
                        _warnedAboutPermissions = true;
                    }

                    return appDataPath;
                }
                catch
                {
                    var currentDirPath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");
                    Console.WriteLine($"Warning: Could not write to any standard location. Using current directory: {currentDirPath}");
                    return currentDirPath;
                }
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            try
            {
                if (formatter == null) return;

                var message = formatter(state, exception);
                var logEntry = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] [{logLevel}] {_categoryName}: {message}";

                if (exception != null)
                {
                    logEntry += $"{Environment.NewLine}{exception}";
                }

                lock (_lock)
                {
                    File.AppendAllText(_filePath, logEntry + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _basePath;
        private readonly ConcurrentDictionary<string, FileLogger> _loggers = new();

        public FileLoggerProvider(string basePath)
        {
            _basePath = basePath;
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _basePath));

        public void Dispose() => _loggers.Clear();
    }
}