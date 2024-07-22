namespace SeleniumSharpTemplate.Utilities.Reports.Screenshot
{
    [Binding]
    [DebuggerStepThrough]
    public static class ScreenshotHooks
    {
        [BeforeFeature]
        public static void CreateScreenshotsFolderBeforeFeature(FeatureContext featureContext)
        {
            PathFinder.FeatureTitleScreenshots = Path.Combine(PathFinder.Screenshots, featureContext.FeatureInfo.Title).CreatePathIfNotExists();
            Contexts.RegisterFeatureContext(featureContext);
        }

        [BeforeScenario]
        public static void CreateScreenshotsFolderBeforeScenario(ScenarioContext scenarioContext)
        {
            PathFinder.ScenarioTitleScreenshots = Path.Combine(PathFinder.FeatureTitleScreenshots!, scenarioContext.ScenarioInfo.Title).CreatePathIfNotExists();
            Contexts.RegisterScenarioContext(scenarioContext);
        }
    }
}