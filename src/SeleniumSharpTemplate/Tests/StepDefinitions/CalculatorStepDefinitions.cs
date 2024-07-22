namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions(GoogleHomePage googleHomePage)
    {
        [Given("I launch google calculator")]
        public void GivenILaunchGoogleCalculator()
        {
            const string searchText = "calculator";
            googleHomePage.GoToGoogle();
            googleHomePage.Search(searchText);
            googleHomePage.GetPageTitle.Should().StartWith(searchText);
            googleHomePage.driver.CaptureScreenshot($"Search result '{searchText}' verified");
        }
    }
}