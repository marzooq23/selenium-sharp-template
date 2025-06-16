namespace Automation.Framework.Reports.Pdf;

[Binding]
[DebuggerStepThrough]
internal class PdfReportsInitializer
{
    [BeforeScenario]
    public void CreatePdfFolder()
    {
        PathFinder.PdfToday.CreateFolderIfNotExists();
    }

    [AfterScenario]
    public void GeneratePdfReport(ScenarioContext scenarioContext)
    {
        var pdfReportGenerator = new PdfReportGenerator();
        pdfReportGenerator.GenerateReport(
            PathFinder.PdfToday,
            scenarioContext.ScenarioInfo.Title);
    }
}