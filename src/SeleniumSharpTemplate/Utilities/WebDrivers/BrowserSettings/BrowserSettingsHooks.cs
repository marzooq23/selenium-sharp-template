﻿namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserSettings
{
    [Binding]
    [DebuggerStepThrough]
    public static class BrowserSettingsHooks
    {
        private const string BROWSERSETTINGS_SECTION = "BrowserSettings";
        private const string BROWSERSETTINGS_JSON_FILENAME = "BrowserSettings.json";
        private static string GetBrowserSettingsLocation => Directories.GetBinLocation + "Utilities\\WebDrivers\\BrowserSettings\\";

        [BeforeTestRun]
        public static void RegisterBrowserSettings(IObjectContainer objectContainer)
        {
            BrowserSettings? browsersSettings =
                ConfigurationFactory
                .GetBinding<BrowserSettings>(
                    GetBrowserSettingsLocation + BROWSERSETTINGS_JSON_FILENAME,
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
    }
}