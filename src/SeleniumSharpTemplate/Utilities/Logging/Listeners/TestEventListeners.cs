namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    public class TestEventListeners
    {
        private const string DOTTED_LINE =
            "---------------------------------------------------------------------------------------------------";

        public static void TestSuiteStartEvent() =>
            Logger.Information($"Test starts");

        public static void TestExecutionStartEvent(string testCase) =>
            Logger.Information($"\n{DOTTED_LINE}\nExecution begins for test '{testCase}'\n");

        public static void TestExecutionEndEvent(string testCase) =>
            Logger.Information($"\nExecution ends for test '{testCase}'\n{DOTTED_LINE}\n");

        public static void TestSuiteEndEvent() =>
            Logger.Information($"Test ends");
    }
}