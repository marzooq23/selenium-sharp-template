﻿namespace SeleniumSharpTemplate.Utilities.Logging
{
    [Binding]
    [DebuggerStepThrough]
    public static class LoggingInitializer
    {
        [BeforeTestRun]
        public static void RegisterLogger()
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.File(Path.Combine(PathFinder.Logs, FileAndFolderName.LOG_TXT))
                    .CreateLogger();
        }
    }
}