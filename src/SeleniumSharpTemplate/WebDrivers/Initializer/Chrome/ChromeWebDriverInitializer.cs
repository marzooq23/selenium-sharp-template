namespace SeleniumSharpTemplate.WebDrivers.Initializer.Chrome
{
    public class ChromeWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new ChromeDriver(ChromeDriverServiceCreator.Service, ChromeDriverOptions.Options);
    }
}