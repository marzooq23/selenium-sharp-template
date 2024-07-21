namespace SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Chrome
{
    public class ChromeWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new ChromeDriver(ChromeDriverServiceCreator.Service, ChromeDriverOptions.Options);

        public override IWebDriver InitializeHeadlessDriver() =>
            new ChromeDriver(ChromeDriverServiceCreator.Service, ChromeDriverOptions.HeadlessOptions);
    }
}