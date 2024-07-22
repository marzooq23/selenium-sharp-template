namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserSettings
{
    [Binding]
    [DebuggerStepThrough]
    public static class BrowserSettingsHooks
    {
        private const string KILL_WEBDRIVERS_BAT = "KillWebDrivers.bat";
        private const string BROWSERSETTINGS_SECTION = "BrowserSettings";
        private const string BROWSERSETTINGS_JSON_FILENAME = "BrowserSettings.json";

        [BeforeTestRun]
        public static void RegisterBrowserSettings(IObjectContainer objectContainer)
        {
            BrowserSettings? browsersSettings =
                ConfigurationFactory
                .GetBinding<BrowserSettings>(
                    Path.Combine(PathFinder.BrowserSettings, BROWSERSETTINGS_JSON_FILENAME),
                    BROWSERSETTINGS_SECTION);

            if (browsersSettings != null)
            {
                objectContainer.RegisterInstanceAs(browsersSettings);
                BrowserSettings.RegisterBrowsersSettingsInstance(browsersSettings);
            }
            else
            {
                throw new NullReferenceException("Please configure BrowserSettings");
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
            if (objectContainer.IsRegistered<IWebDriver>())
                objectContainer.Resolve<IWebDriver>().Dispose();
        }

        [AfterTestRun]
        public static void KillWebDrivers() => ProcessRunner.RunBatchFile(Path.Combine(PathFinder.KillWebDrivers, KILL_WEBDRIVERS_BAT), PathFinder.KillWebDrivers);
    }
}