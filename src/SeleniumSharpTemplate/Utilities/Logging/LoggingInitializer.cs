namespace SeleniumSharpTemplate.Utilities.Logging
{
    [Binding]
    [DebuggerStepThrough]
    public static class LoggingInitializer
    {
        private const string LOG_FILE_NAME = "log.txt";

        public static Serilog.ILogger InitializeLogger
        {
            get
            {
                return new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(Path.Combine(PathFinder.Logs, LOG_FILE_NAME))
                    .CreateLogger();
            }
        }

        [BeforeTestRun]
        public static void RegisterLogger(IObjectContainer objectContainer)
        {
            Logger logger = new();

#pragma warning disable S2589 // Boolean expressions should not be gratuitous
            if (logger != null)
            {
                objectContainer.RegisterInstanceAs(logger);
                Logger.RegisterLogger(logger);
            }
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
        }

        [BeforeTestRun]
        public static void RegisterLogger(Logger logger) =>
            logger.Information("Test run initiated");
    }
}