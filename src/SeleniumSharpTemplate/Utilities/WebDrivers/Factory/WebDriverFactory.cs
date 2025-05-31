using Selenium.SelfHealing;
using SeleniumSharpTemplate.Utilities.Exceptions;
using SeleniumSharpTemplate.Utilities.WebDrivers.Enum;
using SeleniumSharpTemplate.Utilities.WebDrivers.EventFiring;
using SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Chrome;
using SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Edge;
using SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Firefox;
using SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.InternetExplorer;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Factory;

public static class WebDriverFactory
{
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
            _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"{Messages.BROWSER_EX_MESSAGE}: {browserType}")
        };

        return driverType switch
        {
            DriverType.Standard => driver,
            DriverType.EventFiring => driver.ToEventFiringWebDriver(),
            DriverType.SelfHealing => driver.ToSelfHealingDriver(),
            DriverType.EventFiringAndSelfHealing => driver.ToSelfHealingDriver().ToEventFiringWebDriver(),
            _ => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, $"{Messages.DRIVER_EX_MESSAGE}: {driverType}")
        };
    }
}