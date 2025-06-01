namespace Automation.Framework.WebDrivers.Interface;

public interface IWebDriverInitializer
{
    IWebDriver InitializeDriver();

    IWebDriver InitializeHeadlessDriver();
}