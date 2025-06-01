using Automation.Framework.WebDrivers.Interface;

namespace Automation.Framework.WebDrivers.Abstract;

public abstract class WebDriverInitializerBase : IWebDriverInitializer
{
    public abstract IWebDriver InitializeDriver();

    public abstract IWebDriver InitializeHeadlessDriver();
}