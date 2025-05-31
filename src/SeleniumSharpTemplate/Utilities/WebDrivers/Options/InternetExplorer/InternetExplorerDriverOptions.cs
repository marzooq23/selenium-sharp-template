using OpenQA.Selenium.IE;
using SeleniumSharpTemplate.Utilities.WebDrivers.BrowserOptions;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.Options.InternetExplorer;

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