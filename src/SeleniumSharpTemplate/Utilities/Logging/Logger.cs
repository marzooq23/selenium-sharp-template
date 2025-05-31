using Serilog.Events;

namespace SeleniumSharpTemplate.Utilities.Logging;

public class Logger : ILogger
{
    public static void Debug(string message) => Log.Debug(message);

    public static void Error(string message) => Log.Error(message);

    public static void Fatal(string message) => Log.Fatal(message);

    public static void Information(string message) => Log.Information(message);

    public static void Warning(string message) => Log.Warning(message);

    public void Write(LogEvent logEvent) => Log.Write(logEvent);
}