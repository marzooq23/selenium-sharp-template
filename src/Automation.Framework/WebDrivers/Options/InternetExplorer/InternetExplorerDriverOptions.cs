using Automation.Framework.WebDrivers.BrowserOptions;
using OpenQA.Selenium.IE;

namespace Automation.Framework.WebDrivers.Options.InternetExplorer;

public static class InternetExplorerDriverOptions
{
    public static InternetExplorerOptions Options => new()
    {
        AttachToEdgeChrome = true,
        EdgeExecutablePath = BrowserSettings.Instance().EdgeBin,
        BrowserCommandLineArguments = "-private",
    };

    public static InternetExplorerOptions HeadlessOptions
    {
        get
        {
            InternetExplorerOptions ieHeadlessOptions = Options;

            ieHeadlessOptions.AddAdditionalOption("headless", true);

            return ieHeadlessOptions;
        }
    }
}