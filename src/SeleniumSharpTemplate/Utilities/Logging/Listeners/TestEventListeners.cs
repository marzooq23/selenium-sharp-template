using Serilog.Context;

namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    public static class TestEventListeners
    {
        private const string TESTCASE_PROPERTY = "TestCase";

        private const string DOTTED_LINE =
            "---------------------------------------------------------------------------------------------------";

        public static void TestSuiteStartEvent() =>
            Logger.Log.Information($"\n{DOTTED_LINE}\nTest starts\n");

        public static void TestExecutionStartEvent()
        {
            var testCase = Contexts.GetScenarioTitle;
            LogContext.PushProperty(TESTCASE_PROPERTY, testCase);
            Logger.Log.Information($"\n{DOTTED_LINE}\nExecution begins for test '{testCase}'\n");
        }

        public static void TestExecutionEndEvent()
        {
            var testCase = Contexts.GetScenarioTitle;
            LogContext.PushProperty(TESTCASE_PROPERTY, null);
            Logger.Log.Information($"\nExecution ends for test '{testCase}'\n{DOTTED_LINE}\n");
        }

        public static void TestSuiteEndEvent() =>
            Logger.Log.Information($"\nTest ends\n{DOTTED_LINE}\n");
    }
}