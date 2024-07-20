namespace SeleniumSharpTemplate.WebDrivers.BrowserSettings
{
    [Binding]
    [DebuggerStepThrough]
    public static class BrowserSettingsHooks
    {
        [BeforeScenario]
        public static void RegisterDriver(IObjectContainer objectContainer)
        {
            if (objectContainer.IsRegistered<IWebDriver>()) return;

            var driver = WebDriverFactory.CreateWebDriver(BrowserType.Chrome);
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public static void DisposeDriver(IObjectContainer objectContainer)
        {
            if (objectContainer.IsRegistered<IWebDriver>()) objectContainer.Resolve<IWebDriver>().Dispose();
        }
    }
}
