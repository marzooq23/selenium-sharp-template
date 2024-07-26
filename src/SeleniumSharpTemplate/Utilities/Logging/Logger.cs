namespace SeleniumSharpTemplate.Utilities.Logging
{
    public class Logger : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public Logger() => _logger = LoggingInitializer.InitializeLogger;

        public static Logger? Log { get; set; }

        public static void RegisterLogger(Logger logger) =>
            Log = logger ?? throw new NullReferenceException("Please configure Serilog");

        public void Debug(string message) => _logger.Debug(message);

        public void Error(string message) => _logger.Error(message);

        public void Fatal(string message) => _logger.Fatal(message);

        public void Information(string message) => _logger.Information(message);

        public void Warning(string message) => _logger.Warning(message);
    }
}