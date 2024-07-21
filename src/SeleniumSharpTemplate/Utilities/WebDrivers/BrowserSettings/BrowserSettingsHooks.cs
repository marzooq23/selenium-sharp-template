namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserSettings
{
    [Binding]
    [DebuggerStepThrough]
    public static class BrowserSettingsHooks
    {
        [BeforeTestRun]
        public static void RegisterBrowserSettings(IObjectContainer objectContainer)
        {
            BrowsersSettings? browsersSettings = ConfigurationFactory.Create<BrowsersSettings>("BrowserSettings.json");

            if (browsersSettings != null)
            {
                objectContainer.RegisterInstanceAs(browsersSettings);
                BrowsersSettings.RegisterBrowsersSettingsInstance(browsersSettings);
            }
        }

        [BeforeScenario]
        public static void RegisterDriver(IObjectContainer objectContainer)
        {
            if (objectContainer.IsRegistered<IWebDriver>()) return;

            IWebDriver driver = WebDriverFactory.CreateWebDriver(BrowserType.Chrome);
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public static void DisposeDriver(IObjectContainer objectContainer)
        {
            if (objectContainer.IsRegistered<IWebDriver>()) objectContainer.Resolve<IWebDriver>().Dispose();
        }
    }
}