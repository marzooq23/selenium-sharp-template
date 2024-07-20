namespace SeleniumSharpTemplate.WebDrivers.Abstract
{
    public abstract class WebDriverInitializerBase : IWebDriverInitializer
    {
        public abstract IWebDriver InitializeDriver();
        public abstract IWebDriver InitializeHeadlessDriver();
    }
}