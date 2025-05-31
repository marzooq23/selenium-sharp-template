using OpenQA.Selenium.Firefox;
using SeleniumSharpTemplate.Utilities.WebDrivers.Abstract;
using SeleniumSharpTemplate.Utilities.WebDrivers.Options.Firefox;
using SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.Firefox;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Firefox;

public class FirefoxWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver() =>
        new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.Options);

    public override IWebDriver InitializeHeadlessDriver() =>
        new FirefoxDriver(FirefoxDriverServiceCreator.Service, FirefoxDriverOptions.HeadlessOptions);
}