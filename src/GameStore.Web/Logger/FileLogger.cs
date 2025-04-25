namespace GameStore.Web.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _filePath;

        public FileLogger(string categoryName, string basePath)
        {
            _categoryName = categoryName;
            _filePath = Path.Combine(basePath, $"logs-{DateTime.Today:yyyyMMdd}.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_categoryName}: {formatter(state, exception)}";

            File.AppendAllText(_filePath, message + Environment.NewLine);
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
