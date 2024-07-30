using SeleniumSharpTemplate.Tests.Pages;

namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions(GoogleHomePage googleHomePage, ExtentTest extentTest)
    {
        [Given("I launch google calculator")]
        public void GivenILaunchGoogleCalculator()
        {
            const string searchText = "calculator";
            googleHomePage.GoToGoogle();
            googleHomePage.Search(searchText);
            googleHomePage.GetPageTitle.Should().StartWith(searchText);
            var title = $"Search result '{searchText}' verified";
            extentTest.LogScreenshot(title, googleHomePage.driver.CaptureScreenshot(title));
        }
    }
}