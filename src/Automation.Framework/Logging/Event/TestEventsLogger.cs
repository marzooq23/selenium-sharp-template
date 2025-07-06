using Automation.Framework.DateTime;
using Automation.Framework.Logging.Listeners;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Automation.Framework.Logging.Event;

[Binding]
[DebuggerStepThrough]
internal static class TestEventsLogger
{
#pragma warning disable CS8618
    private static Stopwatch _stopwatch;
    public static string TestExecutionStartTime;
    public static string TestExecutionEndTime;
    public static string TestExecutionDurationTime;
    public static int TotalTests;
    public static int TotalPassedTests;
    public static int TotalFailedTests;
    public static int TotalSkippedTests;
    public static int TotalInconclusiveTests;
#pragma warning restore CS8618

    [BeforeTestRun]
    public static void LogTestSuiteInitiation()
    {
        _stopwatch = Stopwatch.StartNew();
        TestExecutionStartTime = DateTimeFormatter.NOW_DD_MM_YYYY_HH_MM_SS_UTC;
        TestEventListeners.TestSuiteStartEvent();
    }

    [BeforeScenario]
    public static void LogTestInitiation(ScenarioContext ScenarioContext)
    {
        TestEventListeners.TestExecutionStartEvent(ScenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public static void LogTestCompletion(ScenarioContext ScenarioContext)
    {
        TestEventListeners.TestExecutionEndEvent(ScenarioContext.ScenarioInfo.Title);
    }

    [AfterTestRun(Order = 0)]
    public static void LogTestSuiteCompletion()
    {
        _stopwatch.Stop();
        TestExecutionEndTime = DateTimeFormatter.NOW_DD_MM_YYYY_HH_MM_SS_UTC;
        TestEventListeners.TestSuiteEndEvent();
        TestExecutionDurationTime = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");

        ITestResult finalResult = TestExecutionContext.CurrentContext.CurrentResult;

        TotalTests = finalResult.PassCount + finalResult.FailCount + finalResult.SkipCount + finalResult.InconclusiveCount;
        TotalPassedTests = finalResult.PassCount;
        TotalFailedTests = finalResult.FailCount;
        TotalSkippedTests = finalResult.SkipCount;
        TotalInconclusiveTests = finalResult.InconclusiveCount;
    }
}