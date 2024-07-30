namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    public static class TestEventListeners
    {
        private const string DOTTED_LINE =
            "---------------------------------------------------------------------------------------------------";

        public static void TestSuiteStartEvent() =>
            Logger.Information($"\n{DOTTED_LINE}\n\nTest starts\n");

        public static void TestExecutionStartEvent(string testCase) =>
            Logger.Information($"\n{DOTTED_LINE}\n\nExecution begins for test '{testCase}'\n");

        public static void TestExecutionEndEvent(string testCase) =>
            Logger.Information($"\n\nExecution ends for test '{testCase}'\n{DOTTED_LINE}\n");

        public static void TestSuiteEndEvent() =>
            Logger.Information($"\n\nTest ends\n{DOTTED_LINE}\n");
    }
}