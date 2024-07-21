namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions(Config.Config config, GoogleHomePage googleHomePage)
    {
        [Given("I launch google calculator")]
        public void GivenILaunchGoogleCalculator()
        {
            const string searchText = "calculator";
            googleHomePage.GoToUrl(config.UrlGoogle!);
            googleHomePage.Search(searchText);
            googleHomePage.GetPageTitle.Should().StartWith(searchText);
        }
    }
}