namespace SeleniumSharpTemplate.WebDrivers.Initializer.Firefox
{
    public class FirefoxWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.Options);

        public override IWebDriver InitializeHeadlessDriver() =>
            new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.HeadlessOptions);
    }
}