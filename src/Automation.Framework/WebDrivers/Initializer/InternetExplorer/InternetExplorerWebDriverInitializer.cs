using Automation.Framework.WebDrivers.Abstract;
using Automation.Framework.WebDrivers.Options.InternetExplorer;
using Automation.Framework.WebDrivers.ServiceCreator.InternetExplorer;
using OpenQA.Selenium.IE;

namespace Automation.Framework.WebDrivers.Initializer.InternetExplorer;

public class InternetExplorerWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver()
    {
        return new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.Options);
    }

    public override IWebDriver InitializeHeadlessDriver()
    {
        return new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.HeadlessOptions);
    }
}