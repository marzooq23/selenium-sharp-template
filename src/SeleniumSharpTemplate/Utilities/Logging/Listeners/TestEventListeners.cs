using Serilog.Context;

namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    public static class TestEventListeners
    {
        private const string TESTCASE_PROPERTY = "TestCase";

        private const string DOTTED_LINE =
            "---------------------------------------------------------------------------------------------------";

        public static void TestSuiteStartEvent() =>
            Logger.Log.Information($"Test starts");

        public static void TestExecutionStartEvent()
        {
            var testCase = Contexts.GetScenarioTitle;
            LogContext.PushProperty(TESTCASE_PROPERTY, testCase);
            Logger.Log.Information($"Execution begins for test '{testCase}'");
        }

        public static void TestExecutionEndEvent()
        {
            var testCase = Contexts.GetScenarioTitle;
            LogContext.PushProperty(TESTCASE_PROPERTY, null);
            Logger.Log.Information($"Execution ends for test '{testCase}'");
        }

        public static void TestSuiteEndEvent() =>
            Logger.Log.Information($"Test ends");
    }
}