namespace GameStore.Web.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;

        public FileLogger(string categoryName, string filePath)
        {
            _categoryName = categoryName;
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);
        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _basePath;

        public FileLoggerProvider(string basePath)
        {
            _basePath = basePath;
        }

        public ILogger CreateLogger(string categoryName) =>
            new FileLogger(categoryName, _basePath);

        public void Dispose() { }
    }
}
