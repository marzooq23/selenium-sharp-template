using OpenQA.Selenium.IE;
using SeleniumSharpTemplate.Utilities.WebDrivers.Abstract;
using SeleniumSharpTemplate.Utilities.WebDrivers.Options.InternetExplorer;
using SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.InternetExplorer;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Initializer.InternetExplorer;

public class InternetExplorerWebDriverInitializer : WebDriverInitializerBase
{
    public override IWebDriver InitializeDriver() =>
        new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.Options);

    public override IWebDriver InitializeHeadlessDriver() =>
        new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.HeadlessOptions);
}