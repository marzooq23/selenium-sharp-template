namespace SeleniumSharpTemplate.Utilities.WebDrivers.Interface;

public interface IWebDriverInitializer
{
    IWebDriver InitializeDriver();

    IWebDriver InitializeHeadlessDriver();
}