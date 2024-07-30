using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace SeleniumSharpTemplate.Utilities.Reports.Extent.HtmlReporter
{
    [Binding]
    [DebuggerStepThrough]
    public class ExtentHtmlReporterFive
    {
        private static Theme _theme = Theme.Standard;
        private static ScenarioContext? _scenarioContext;
        private static ExtentReports _extentReports = null!;
        private static ExtentSparkReporter _extentSparkReporter = null!;
        private static ExtentTest _extentTest = null!;

        [BeforeTestRun]
        private static void RegisterExtentReport()
        {
            string extentHtml = Path.Combine(PathFinder.ExtentReport, FileAndFolderName.EXTENT_REPORTS_HTML);
            _extentReports = new();
            _extentSparkReporter =
                new(extentHtml)
                {
                    Config = new ExtentSparkReporterConfig()
                    {
                        Theme = _theme
                    }
                };
            _extentReports.AttachReporter(_extentSparkReporter);
        }

        [BeforeFeature]
        public static void RegisterFeatureInfo(FeatureContext featureContext)
        {
            _extentTest = _extentReports
                .CreateTest<Feature>(
                featureContext.FeatureInfo.Title,
                featureContext.FeatureInfo.Description);
        }

        [BeforeScenario]
        public static void RegisterScenarioInfo(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _extentTest = _extentTest
                .CreateNode<Scenario>(
                scenarioContext.ScenarioInfo.Title,
                scenarioContext.ScenarioInfo.Description);
            objectContainer.RegisterInstanceAs(_extentTest);
            _scenarioContext = scenarioContext;
        }

        //TO_DO:Update node after step
        //[AfterStep]
        public void RegisterStepInfo(ScenarioContext ScenarioContext)
        {
            switch (ScenarioContext.CurrentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;
                default:
                    CreateNode<And>();
                    break;
            }
        }

        [AfterTestRun]
        public static void EndTest() => _extentReports.Flush();

        public void CreateNode<T>() where T : IGherkinFormatterModel
        {
            var stepInfo = _scenarioContext!.StepContext.StepInfo.Text;
            var testErrorMessage = _scenarioContext.TestError.Message + "\n"
                + _scenarioContext.TestError.StackTrace;
            if (_scenarioContext!.TestError != null)
                _extentTest.CreateNode<T>(stepInfo).Fail(testErrorMessage);
            else
                _extentTest.CreateNode<T>(stepInfo).Pass(string.Empty);
        }
    }
}