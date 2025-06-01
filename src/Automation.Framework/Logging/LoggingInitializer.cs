namespace Automation.Framework.Logging;

[Binding]
//[DebuggerStepThrough]
internal static class LoggingInitializer
{
    [BeforeTestRun]
    public static void RegisterLogger()
    {
        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(Path.Combine(PathFinder.Logs, PathFinder.LOG_TXT))
                .CreateLogger();
    }
}