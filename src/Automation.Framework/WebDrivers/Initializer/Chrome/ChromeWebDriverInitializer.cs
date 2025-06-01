using Automation.Framework.WebDrivers.Abstract;
using Automation.Framework.WebDrivers.Options.Chrome;
using Automation.Framework.WebDrivers.ServiceCreator.Chrome;
using OpenQA.Selenium.Chrome;

namespace Automation.Framework.WebDrivers.Initializer.Chrome;

public class ChromeWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver()
    {
        return new ChromeDriver(ChromeDriverServiceCreator.Service, ChromeDriverOptions.Options);
    }

    public override IWebDriver InitializeHeadlessDriver()
    {
        return new ChromeDriver(ChromeDriverServiceCreator.Service, ChromeDriverOptions.HeadlessOptions);
    }
}