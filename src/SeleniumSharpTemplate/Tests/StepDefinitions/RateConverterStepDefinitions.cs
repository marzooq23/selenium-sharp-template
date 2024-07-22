namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class RateConverterStepDefinitions(GoogleHomePage googleHomePage)
    {
        [Given("I launch google rate converter")]
        public void GivenILaunchGoogleRateConverter()
        {
            const string searchText = "usd to inr converter";
            googleHomePage.GoToGoogle();
            googleHomePage.Search(searchText);
            googleHomePage.GetPageTitle.Should().StartWith(searchText);
            googleHomePage.driver.CaptureScreenshot($"Search result '{searchText}' verified");
        }
    }
}