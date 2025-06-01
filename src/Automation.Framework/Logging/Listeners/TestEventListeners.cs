namespace Automation.Framework.Logging.Listeners;

public static class TestEventListeners
{
    private static string Context(string testId) => $"[TID:{Environment.CurrentManagedThreadId} - {testId}]";

    public static void TestSuiteStartEvent()
    {
        Logger.Information("Test starts");
    }

    public static void TestExecutionStartEvent(string testCase)
    {
        Logger.Information($"{Context(testCase)} Execution begins for test '{testCase}'");
    }

    public static void TestExecutionEndEvent(string testCase)
    {
        Logger.Information($"{Context(testCase)} Execution ends for test '{testCase}'");
    }

    public static void TestSuiteEndEvent()
    {
        Logger.Information("Test ends");
    }
}