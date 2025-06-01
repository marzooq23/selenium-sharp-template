using Automation.Framework.Executors;
using Automation.Framework.WebDrivers.Enum;
using Automation.Framework.WebDrivers.Factory;

namespace Automation.Framework.WebDrivers.BrowserOptions;

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
                    PathFinder.BROWSERSETTINGS_JSON),
                PathFinder.BROWSERSETTINGS_SECTION);

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
        if (objectContainer.IsRegistered<IWebDriver>())
        {
            return;
        }

        IWebDriver driver = WebDriverFactory.CreateWebDriver(BrowserType.Edge, DriverType.EventFiring);
        objectContainer.RegisterInstanceAs(driver);
    }

    [AfterScenario]
    public static void DisposeDriver(IObjectContainer objectContainer)
    {
        if (objectContainer.IsRegistered<IWebDriver>())
        {
            objectContainer.Resolve<IWebDriver>().Dispose();
        }
    }

    [AfterTestRun]
    public static void KillWebDrivers()
    {
        ProcessRunner.RunBatchFile(
            Path.Combine(
                PathFinder.KillWebDrivers,
                PathFinder.KILL_WEBDRIVERS_BAT),
            PathFinder.KillWebDrivers);
    }
}