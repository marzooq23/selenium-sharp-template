using SeleniumSharpTemplate.Utilities.Executors;
using SeleniumSharpTemplate.Utilities.WebDrivers.Enum;
using SeleniumSharpTemplate.Utilities.WebDrivers.Factory;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserOptions
{
    [Binding]
    [DebuggerStepThrough]
    internal static class BrowserSettingsInitializer
    {
        [BeforeTestRun]
        public static void RegisterBrowserSettings(IObjectContainer objectContainer)
        {
            BrowserSettings? browsersSettings =
                ConfigurationFactory
                .GetBinding<BrowserSettings>(
                    Path.Combine(
                        PathFinder.BrowserSettings,
                        FileAndFolderName.BROWSERSETTINGS_JSON),
                    FileAndFolderName.BROWSERSETTINGS_SECTION);

            if (browsersSettings != null)
            {
                objectContainer.RegisterInstanceAs(browsersSettings);
                BrowserSettings.RegisterInstance(browsersSettings);
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

            IWebDriver driver = WebDriverFactory.CreateWebDriver(BrowserType.ChromeHeadless, DriverType.EventFiring);
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public static void DisposeDriver(IObjectContainer objectContainer)
        {
            if (objectContainer.IsRegistered<IWebDriver>())
                objectContainer.Resolve<IWebDriver>().Dispose();
        }

        [AfterTestRun]
        public static void KillWebDrivers() =>
            ProcessRunner.RunBatchFile(
                Path.Combine(
                    PathFinder.KillWebDrivers, FileAndFolderName.KILL_WEBDRIVERS_BAT),
                PathFinder.KillWebDrivers);
    }
}