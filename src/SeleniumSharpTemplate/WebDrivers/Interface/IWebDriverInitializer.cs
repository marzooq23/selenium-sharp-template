namespace SeleniumSharpTemplate.WebDrivers.Interface
{
    public interface IWebDriverInitializer
    {
        IWebDriver InitializeDriver();
        IWebDriver InitializeHeadlessDriver();
    }
}