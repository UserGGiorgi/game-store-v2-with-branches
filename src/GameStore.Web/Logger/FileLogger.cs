using System.Collections.Concurrent;

namespace GameStore.Web.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;
        private readonly object _lock = new object();

        public FileLogger(string categoryName, string filePath)
        {
            _categoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            ArgumentNullException.ThrowIfNull(formatter);

            var message = formatter(state, exception);
            var logEntry = $"[{DateTime.UtcNow:o}] [{logLevel}] {_categoryName}: {message}";

            if (exception != null)
            {
                logEntry += $"{Environment.NewLine}{exception}";
            }

            lock (_lock)
            {
                File.AppendAllText(_filePath, logEntry + Environment.NewLine);
            }
        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _basePath;
        private readonly ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();
        private bool _disposed;

        public FileLoggerProvider(string basePath)
        {
            _basePath = basePath ?? throw new ArgumentNullException(nameof(basePath));

            var directory = Path.GetDirectoryName(_basePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new FileLogger(name, _basePath));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _loggers.Clear();
                }
                _disposed = true;
            }
        }
    }
}
