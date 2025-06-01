using Automation.Framework.DateTime;

namespace Automation.Framework.Reports.Screenshot;

[Binding]
[DebuggerStepThrough]
internal class ScreenshotInitializer
{
    [BeforeScenario]
    public void CreateScreenshotsFolder(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        Path.Combine(
            PathFinder.Screenshots,
            DateTimeFormatter.NOW_DD_MM_YYYY,
            featureContext.FeatureInfo.Title,
            scenarioContext.ScenarioInfo.Title,
            Guid.NewGuid().ToString())
            .CreateFolderIfNotExists();
    }
}