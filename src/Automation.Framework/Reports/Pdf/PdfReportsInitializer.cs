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
            System.DateTime.Now.ToString("dd-MM-yyyy"))
            .CreateFolderIfNotExists();
    }
}