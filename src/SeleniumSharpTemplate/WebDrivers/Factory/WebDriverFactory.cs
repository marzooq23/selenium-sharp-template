using SeleniumSharpTemplate.WebDrivers.Initializer.InternetExplorer;

namespace SeleniumSharpTemplate.WebDrivers.Factory
{
    public static class WebDriverFactory
    {
        private const string MESSAGE = "Invalid browser type specified";

        public static IWebDriver CreateWebDriver(BrowserType browserType) => browserType switch
        {
            BrowserType.Chrome => new ChromeWebDriverInitializer().InitializeDriver(),
            BrowserType.ChromeHeadless => new ChromeWebDriverInitializer().InitializeHeadlessDriver(),
            BrowserType.Edge => new EdgeWebDriverInitializer().InitializeDriver(),
            BrowserType.EdgeHeadless => new EdgeWebDriverInitializer().InitializeHeadlessDriver(),
            BrowserType.Firefox => new FirefoxWebDriverInitializer().InitializeDriver(),
            BrowserType.FirefoxHeadless => new FirefoxWebDriverInitializer().InitializeHeadlessDriver(),
            BrowserType.InternetExplorer => new InternetExplorerWebDriverInitializer().InitializeDriver(),
            BrowserType.InternetExplorerHeadless => new InternetExplorerWebDriverInitializer().InitializeHeadlessDriver(),
            _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"{MESSAGE}: {browserType}")
        };
    }
}