namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        [Given("I launch google calculator")]
        public void GivenILaunchGoogleCalculator()
        {
            var driver = WebDriverFactory.CreateWebDriver(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.google.com/search?q=calculator");
            driver.Quit();
        }
    }
}