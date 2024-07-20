namespace SeleniumSharpTemplate.WebDrivers.Initializer.Edge
{
    internal class EdgeWebDriverInitializer : WebDriverInitializerBase
    {
        public override IWebDriver InitializeDriver() =>
            new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.Options);

        public override IWebDriver InitializeHeadlessDriver() =>
            new EdgeDriver(EdgeDriverServiceCreator.Service, EdgeDriverOptions.HeadlessOptions);
    }
}