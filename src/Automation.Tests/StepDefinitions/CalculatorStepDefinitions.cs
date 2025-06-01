using Automation.Framework.DateTime;
using Automation.Tests.Pages;

namespace Automation.Tests.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions(
    ExtentTest extentTest,
    FeatureContext featureContext,
    GoogleHomePage googleHomePage,
    ScenarioContext scenarioContext)
{
    [Given("I launch google calculator")]
    public void GivenILaunchGoogleCalculator()
    {
        const string searchText = "calculator";
        googleHomePage.GoToGoogle();
        googleHomePage.Search(searchText);

        try
        {
            googleHomePage.GetPageTitle.Should().StartWith(searchText);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            var title = $"Search result '{searchText}' verified";
            extentTest.LogScreenshot(
                title,
                googleHomePage.CaptureScreenshot(title, Path.Combine(PathFinder.Screenshots, DateTimeFormatter.NOW_DD_MM_YYYY, featureContext.FeatureInfo.Title, scenarioContext.ScenarioInfo.Title)).ConvertImageToBase64());
        }
    }
}