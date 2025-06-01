using Automation.Framework.WebDrivers.Abstract;
using Automation.Framework.WebDrivers.Options.Firefox;
using Automation.Framework.WebDrivers.ServiceCreator.Firefox;
using OpenQA.Selenium.Firefox;

namespace Automation.Framework.WebDrivers.Initializer.Firefox;

public class FirefoxWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver()
    {
        return new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.Options);
    }

    public override IWebDriver InitializeHeadlessDriver()
    {
        return new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.HeadlessOptions);
    }
}