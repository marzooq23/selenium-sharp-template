using SeleniumSharpTemplate.Utilities.Logging.Events;

namespace SeleniumSharpTemplate.Utilities.Logging.Event
{
    [Binding]
    [DebuggerStepThrough]
    internal static class TestEventsLogger
    {
        [BeforeTestRun]
        public static void LogTestSuiteInitiation() =>
            TestEventListeners.TestSuiteStartEvent();

        [BeforeScenario]
        public static void LogTestInitiation(ScenarioContext ScenarioContext) =>
            TestEventListeners.TestExecutionStartEvent(ScenarioContext.ScenarioInfo.Title);

        [AfterScenario]
        public static void LogTestCompletion(ScenarioContext ScenarioContext) =>
            TestEventListeners.TestExecutionEndEvent(ScenarioContext.ScenarioInfo.Title);

        [AfterTestRun]
        public static void LogTestSuiteCompletion() =>
            TestEventListeners.TestSuiteEndEvent();
    }
}