namespace SeleniumSharpTemplate.Utilities.Reports.Screenshot;

[Binding]
[DebuggerStepThrough]
internal class ScreenshotInitializer
{
    [BeforeScenario]
    public void CreateScreenshotsFolder(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        Path.Combine(
            PathFinder.Screenshots,
            System.DateTime.Now.ToString("dd-MM-yyyy"),
            featureContext.FeatureInfo.Title,
            scenarioContext.ScenarioInfo.Title)
            .CreateFolderIfNotExists();
    }
}