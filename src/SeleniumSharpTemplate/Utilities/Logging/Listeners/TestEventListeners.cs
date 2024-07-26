namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    public static class TestEventListeners
    {
        private const string DOTTED_LINE =
            "---------------------------------------------------------------------------------------------------";

        public static void TestSuiteStartEvent() =>
            Logger.Log.Information($"\n{DOTTED_LINE}\nTest starts\n");

        public static void TestExecutionStartEvent() =>
            Logger.Log.Information($"\n{DOTTED_LINE}\nExecution begins for test '{Contexts.GetScenarioTitle}'\n");

        public static void TestExecutionEndEvent() =>
            Logger.Log.Information($"\nExecution ends for test '{Contexts.GetScenarioTitle}'\n{DOTTED_LINE}\n");

        public static void TestSuiteEndEvent() =>
            Logger.Log.Information($"\nTest ends\n{DOTTED_LINE}\n");
    }
}