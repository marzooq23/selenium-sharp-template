using OpenQA.Selenium.Firefox;

namespace Automation.Framework.WebDrivers.Options.Firefox;

public static class FirefoxDriverOptions
{
    private static readonly string[] AdditionalArguments =
    [
        "--test-type",
        "--incognito",
        "--start-maximized",
        "--ignore-certificate-errors"
    ];

    public static FirefoxOptions Options
    {
        get
        {
            FirefoxOptions firefoxOptions = new()
            {
                AcceptInsecureCertificates = true
            };

            firefoxOptions.AddArguments(AdditionalArguments);

            return firefoxOptions;
        }
    }

    public static FirefoxOptions HeadlessOptions
    {
        get
        {
            FirefoxOptions firefoxHeadlessOptions = Options;

            firefoxHeadlessOptions.AddArgument("-headless");

            return firefoxHeadlessOptions;
        }
    }
}