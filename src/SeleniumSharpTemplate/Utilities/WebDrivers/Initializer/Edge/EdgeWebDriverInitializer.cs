using OpenQA.Selenium.Edge;
using SeleniumSharpTemplate.Utilities.WebDrivers.Abstract;
using SeleniumSharpTemplate.Utilities.WebDrivers.Options.Edge;
using SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.Edge;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.Edge
{
    internal class EdgeWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.Options);

        public override IWebDriver InitializeHeadlessDriver() =>
            new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.HeadlessOptions);
    }
}