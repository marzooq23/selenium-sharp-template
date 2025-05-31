using SeleniumSharpTemplate.Utilities.WebDrivers.Interface;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Abstract;

public abstract class WebDriverInitializerBase : IWebDriverInitializer
{
    public abstract IWebDriver InitializeDriver();

    public abstract IWebDriver InitializeHeadlessDriver();
}