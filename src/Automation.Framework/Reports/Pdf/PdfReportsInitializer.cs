using Automation.Framework.DateTime;

namespace Automation.Framework.Reports.Pdf;

[Binding]
[DebuggerStepThrough]
internal class PdfReportsInitializer
{
    [BeforeScenario]
    public void CreatePdfFolder(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        Path.Combine(
            PathFinder.Pdf,
            DateTimeFormatter.NOW_DD_MM_YYYY)
            .CreateFolderIfNotExists();
    }
}