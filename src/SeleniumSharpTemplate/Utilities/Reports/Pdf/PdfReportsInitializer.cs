namespace SeleniumSharpTemplate.Utilities.Reports.Pdf;

[Binding]
[DebuggerStepThrough]
internal static class PdfReportsInitializer
{
    [BeforeFeature]
    public static void CreatePdfFolderBeforeFeature(FeatureContext featureContext)
    {
        PathFinder.FeatureTitlePdf =
            Path.Combine(PathFinder.Pdf, featureContext.FeatureInfo.Title)
            .CreatePathIfNotExists();
    }

    [BeforeScenario]
    public static void CreatePdfFolderBeforeScenario(ScenarioContext scenarioContext)
    {
        PathFinder.ScenarioTitlePdf =
            Path.Combine(PathFinder.FeatureTitlePdf!, scenarioContext.ScenarioInfo.Title)
            .CreatePathIfNotExists();
    }
}