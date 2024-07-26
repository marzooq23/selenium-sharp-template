using SeleniumSharpTemplate.Utilities.Logging.Events;

namespace SeleniumSharpTemplate.Utilities.Logging.Event
{
    [Binding]
    [DebuggerStepThrough]
    public static class TestEventsLogger
    {
        [BeforeTestRun]
        public static void LogTestSuiteInitiation() =>
            TestEventListeners.TestSuiteStartEvent();

        [BeforeScenario]
        public static void LogTestInitiation() =>
            TestEventListeners.TestExecutionStartEvent();

        [AfterScenario]
        public static void LogTestCompletion() =>
            TestEventListeners.TestExecutionEndEvent();

        [AfterTestRun]
        public static void LogTestSuiteCompletion() =>
            TestEventListeners.TestSuiteEndEvent();
    }
}