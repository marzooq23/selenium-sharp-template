namespace SeleniumSharpTemplate.Utilities.Specflow
{
    public static class Contexts
    {
        private static FeatureContext? FeatureContext;
        private static ScenarioContext? ScenarioContext;

        public static void RegisterFeatureContext(FeatureContext featureContext) =>
            FeatureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));

        public static void RegisterScenarioContext(ScenarioContext scenarioContext) =>
            ScenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));

        public static FeatureContext GetFeatureContext =>
            FeatureContext ?? throw new NullReferenceException(nameof(FeatureContext));

        public static string GetFeatureTitle =>
            FeatureContext!.FeatureInfo.Title ?? throw new NullReferenceException(nameof(FeatureContext));

        public static ScenarioContext GetScenarioContext =>
            ScenarioContext ?? throw new NullReferenceException(nameof(ScenarioContext));

        public static string GetScenarioTitle =>
            ScenarioContext!.ScenarioInfo.Title ?? throw new NullReferenceException(nameof(ScenarioContext));

        public static string GetStepText =>
            ScenarioContext!.StepContext.StepInfo.Text ?? throw new NullReferenceException(nameof(ScenarioContext));
    }
}