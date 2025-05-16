using System;
using System.IO;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace GameStore.Web.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;
        private static readonly object _staticLock = new();
        private static bool _warnedAboutPermissions = false;

        public FileLogger(string categoryName, string filePath)
        {
            _categoryName = categoryName ?? "Default";
            _filePath = GetSafeLogPath(filePath);
        }

        private static string GetSafeLogPath(string requestedPath)
        {
            // Validate requestedPath
            if (string.IsNullOrWhiteSpace(requestedPath))
            {
                requestedPath = Path.Combine(Directory.GetCurrentDirectory(), "application.log");
            }

            // First try the requested path
            try
            {
                var directory = Path.GetDirectoryName(requestedPath) ??
                    throw new InvalidOperationException("Invalid log path");

                Directory.CreateDirectory(directory);
                return requestedPath;
            }
            catch
            {
                return GetFallbackPath();
            }
        }

        private static string GetFallbackPath()
        {
            lock (_staticLock)
            {
                try
                {
                    var appDataPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "GameStore",
                        "Logs",
                        "application.log");

                    var fallbackDir = Path.GetDirectoryName(appDataPath) ??
                        throw new InvalidOperationException("Invalid fallback path");

                    Directory.CreateDirectory(fallbackDir);

                    if (!_warnedAboutPermissions)
                    {
                        Console.WriteLine($"Using fallback location: {appDataPath}");
                        _warnedAboutPermissions = true;
                    }

                    return appDataPath;
                }
                catch
                {
                    var currentDirPath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");
                    Console.WriteLine($"Using emergency location: {currentDirPath}");
                    return currentDirPath;
                }
            }
        }

        [return: MaybeNull]
        public IDisposable BeginScope<TState>(TState state) where TState : notnull => null!;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
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

                lock (_staticLock)
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
            _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _basePath));

        public void Dispose() => _loggers.Clear();
    }
}