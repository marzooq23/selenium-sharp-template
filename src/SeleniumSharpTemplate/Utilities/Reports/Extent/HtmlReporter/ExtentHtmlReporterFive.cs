using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace SeleniumSharpTemplate.Utilities.Reports.Extent.HtmlReporter;

[Binding]
[DebuggerStepThrough]
public class ExtentHtmlReporterFive
{
    private static Theme _theme = Theme.Standard;
    private static ExtentReports _extentReports = null!;
    private static ExtentSparkReporter _extentSparkReporter = null!;

    [BeforeTestRun]
    public static void RegisterExtentReport()
    {
        string extentHtml = Path.Combine(PathFinder.ExtentReport, PathFinder.EXTENT_REPORTS_HTML);
        _extentReports = new ExtentReports();
        _extentSparkReporter = new ExtentSparkReporter(extentHtml)
        {
            Config = new ExtentSparkReporterConfig
            {
                Theme = _theme
            }
        };
        _extentReports.AttachReporter(_extentSparkReporter);
    }

    [BeforeFeature]
    public static void RegisterFeatureInfo(FeatureContext featureContext)
    {
        var featureNode = _extentReports.CreateTest<Feature>(
            featureContext.FeatureInfo.Title,
            featureContext.FeatureInfo.Description);

        featureContext["FeatureNode"] = featureNode;
    }

    [BeforeScenario]
    public static void RegisterScenarioInfo(
        IObjectContainer objectContainer,
        FeatureContext featureContext,
        ScenarioContext scenarioContext)
    {
        if (!featureContext.TryGetValue("FeatureNode", out var featureNodeObj) || featureNodeObj is not ExtentTest featureNode)
            throw new NullReferenceException("FeatureNode is not initialized.");

        var scenarioNode = featureNode.CreateNode<Scenario>(
            scenarioContext.ScenarioInfo.Title,
            scenarioContext.ScenarioInfo.Description);

        scenarioContext["ScenarioNode"] = scenarioNode;
        objectContainer.RegisterInstanceAs(scenarioNode);
    }

    [AfterStep]
    public void RegisterStepInfo(IWebDriver driver, FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var stepText = scenarioContext.StepContext.StepInfo.Text;

        switch (scenarioContext.CurrentScenarioBlock)
        {
            case ScenarioBlock.Given:
                CreateNode<Given>(driver, featureContext, scenarioContext, stepText);
                break;
            case ScenarioBlock.When:
                CreateNode<When>(driver, featureContext, scenarioContext, stepText);
                break;
            case ScenarioBlock.Then:
                CreateNode<Then>(driver, featureContext, scenarioContext, stepText);
                break;
            default:
                CreateNode<And>(driver, featureContext, scenarioContext, stepText);
                break;
        }
    }

    private void CreateNode<T>(IWebDriver driver, FeatureContext featureContext, ScenarioContext scenarioContext, string stepText) where T : IGherkinFormatterModel
    {
        if (!scenarioContext.TryGetValue("ScenarioNode", out var scenarioNodeObj) || scenarioNodeObj is not ExtentTest scenarioNode)
            throw new NullReferenceException("ScenarioNode is not initialized.");

        ExtentTest stepNode;

        if (scenarioContext.TestError != null)
        {
            string error = scenarioContext.TestError.Message + "\n" + scenarioContext.TestError.StackTrace;
            stepNode = scenarioNode.CreateNode<T>(stepText).Fail(error);
        }
        else
        {
            stepNode = scenarioNode.CreateNode<T>(stepText).Pass(string.Empty);
        }

        string screenshotPath = Path.Combine(
            PathFinder.Screenshots,
            System.DateTime.Now.ToString("dd-MM-yyyy"),
            featureContext.FeatureInfo.Title,
            scenarioContext.ScenarioInfo.Title);

        stepNode.LogScreenshot(
            "Step executed",
            driver.CaptureScreenshot(scenarioContext.StepContext.StepInfo.Text, screenshotPath).ConvertImageToBase64());
    }

    [AfterTestRun]
    public static void EndTest() => _extentReports.Flush();
}
