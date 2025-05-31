namespace SeleniumSharpTemplate.Utilities.Exceptions;

[Binding]
internal static class GlobalExceptionHandler
{
    [BeforeTestRun]
    public static void RegisterHandlers() =>
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args) =>
        Logger.Error($"Exception in AppDomain.UnhandledException: {((Exception)args.ExceptionObject).Message}");
}