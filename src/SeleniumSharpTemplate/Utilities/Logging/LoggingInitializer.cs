namespace SeleniumSharpTemplate.Utilities.Logging
{
    [Binding]
    [DebuggerStepThrough]
    public static class LoggingInitializer
    {
        public static Serilog.ILogger InitializeLogger
        {
            get
            {
                return new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(Path.Combine(PathFinder.Logs, FileAndFolderName.LOG_TXT))
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
    }
}