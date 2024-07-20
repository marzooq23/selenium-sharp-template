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

        public static ChromeOptions Options
        {
            get
            {
                ChromeOptions chromeOptions = new()
                {
                    LeaveBrowserRunning = false,
                    AcceptInsecureCertificates = true
                };

                chromeOptions.AddArguments(AdditionalArguments);

                return chromeOptions;
            }
        }

        public static ChromeOptions HeadlessOptions
        {
            get
            {
                ChromeOptions chromeHeadlessOptions = Options;

                chromeHeadlessOptions.AddArguments("-headless");

                return chromeHeadlessOptions;
            }
        }
    }
}