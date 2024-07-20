namespace SeleniumSharpTemplate.WebDrivers.Options.Chrome
{
    public static class ChromeDriverOptions
    {
        private static readonly string[] AdditionalArguments =
        [
            "--test-type",
            "--incognito",
            "--start-maximized",
            "--ignore-certificate-errors"
        ];

        public static ChromeOptions Options => GetChromeOptions();

        public static ChromeOptions HeadlessOptions => GetHeadlessChromeOptions();

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new()
            {
                LeaveBrowserRunning = false,
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArguments(AdditionalArguments);

            return chromeOptions;
        }

        private static ChromeOptions GetHeadlessChromeOptions()
        {
            ChromeOptions chromeHeadlessOptions = GetChromeOptions();

            chromeHeadlessOptions.AddArguments("-headless");

            return chromeHeadlessOptions;
        }
    }
}