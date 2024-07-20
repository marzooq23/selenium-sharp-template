namespace SeleniumSharpTemplate.WebDrivers.Initializer.InternetExplorer
{
    public class InternetExplorerWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.Options);

        public override IWebDriver InitializeHeadlessDriver() => 
            new InternetExplorerDriver(InternetExplorerDriverServiceCreator.Service, InternetExplorerDriverOptions.HeadlessOptions);
    }
}
