namespace SeleniumSharpTemplate.WebDrivers.Factory
{
    public static class WebDriverFactory
    {
        private const string MESSAGE = "Invalid browser type specified";

        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            IWebDriverInitializer initializer = browserType switch
            {
                BrowserType.Chrome => new ChromeWebDriverInitializer(),
                BrowserType.Edge => new EdgeWebDriverInitializer(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"{MESSAGE}: {browserType}")
            };

            return initializer.InitializeDriver();
        }
    }
}