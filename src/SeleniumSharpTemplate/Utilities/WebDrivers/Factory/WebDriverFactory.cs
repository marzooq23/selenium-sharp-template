using Selenium.SelfHealing;
using SeleniumSharpTemplate.Utilities.WebDrivers.EventFiring;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Factory
{
    public static class WebDriverFactory
    {
        private const string BROWSER_MESSAGE = "Invalid browser type specified";
        private const string DRIVER_MESSAGE = "Invalid driver type specified";

        public static IWebDriver CreateWebDriver(BrowserType browserType, DriverType driverType)
        {
            IWebDriver driver = browserType switch
            {
                BrowserType.Chrome => new ChromeWebDriverInitializer().InitializeDriver(),
                BrowserType.ChromeHeadless => new ChromeWebDriverInitializer().InitializeHeadlessDriver(),
                BrowserType.Edge => new EdgeWebDriverInitializer().InitializeDriver(),
                BrowserType.EdgeHeadless => new EdgeWebDriverInitializer().InitializeHeadlessDriver(),
                BrowserType.Firefox => new FirefoxWebDriverInitializer().InitializeDriver(),
                BrowserType.FirefoxHeadless => new FirefoxWebDriverInitializer().InitializeHeadlessDriver(),
                BrowserType.InternetExplorer => new InternetExplorerWebDriverInitializer().InitializeDriver(),
                BrowserType.InternetExplorerHeadless => new InternetExplorerWebDriverInitializer().InitializeHeadlessDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"{BROWSER_MESSAGE}: {browserType}")
            };

            return driverType switch
            {
                DriverType.Standard => driver,
                DriverType.EventFiring => driver.ToEventFiringWebDriver(),
                DriverType.SelfHealing => driver.ToSelfHealingDriver(),
                DriverType.EventFiringAndSelfHealing => driver.ToSelfHealingDriver().ToEventFiringWebDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, $"{DRIVER_MESSAGE}: {driverType}")
            };
        }
    }
}