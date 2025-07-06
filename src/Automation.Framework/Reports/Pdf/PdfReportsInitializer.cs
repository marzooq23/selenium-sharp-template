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

    [AfterTestRun(Order = 1)]
    public static void GeneratePdfReport()
    {
        PdfReportGenerator.GenerateReport(PathFinder.PdfToday);
    }
}
