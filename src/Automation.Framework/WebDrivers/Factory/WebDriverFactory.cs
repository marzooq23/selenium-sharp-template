using Automation.Framework.Exceptions;
using Automation.Framework.WebDrivers.Enum;
using Automation.Framework.WebDrivers.EventFiring;
using Selenium.SelfHealing;
using Automation.Framework.WebDrivers.Initializer.Chrome;
using Automation.Framework.WebDrivers.Initializer.Edge;
using Automation.Framework.WebDrivers.Initializer.Firefox;
using Automation.Framework.WebDrivers.Initializer.InternetExplorer;

namespace Automation.Framework.WebDrivers.Factory;

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