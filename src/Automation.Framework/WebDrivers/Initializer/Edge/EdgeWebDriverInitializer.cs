using Automation.Framework.WebDrivers.Abstract;
using Automation.Framework.WebDrivers.Options.Edge;
using Automation.Framework.WebDrivers.ServiceCreator.Edge;
using OpenQA.Selenium.Edge;

namespace Automation.Framework.WebDrivers.Initializer.Edge;

internal class EdgeWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver()
    {
        return new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.Options);
    }

    public override IWebDriver InitializeHeadlessDriver()
    {
        return new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.HeadlessOptions);
    }
}