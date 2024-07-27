namespace SeleniumSharpTemplate.Utilities.Reports.Screenshot
{
    [Binding]
    [DebuggerStepThrough]
    internal static class ScreenshotInitializer
    {
        [BeforeFeature]
        public static void CreateScreenshotsFolderBeforeFeature(FeatureContext featureContext)
        {
            PathFinder.FeatureTitleScreenshots =
                Path.Combine(
                    PathFinder.Screenshots,
                    featureContext.FeatureInfo.Title)
                .CreatePathIfNotExists();
        }

        [BeforeScenario]
        public static void CreateScreenshotsFolderBeforeScenario(ScenarioContext scenarioContext)
        {
            PathFinder.ScenarioTitleScreenshots =
                Path.Combine(
                    PathFinder.FeatureTitleScreenshots!,
                    scenarioContext.ScenarioInfo.Title)
                .CreatePathIfNotExists();
        }
    }
}