namespace SeleniumSharpTemplate.WebDrivers.Options.Chrome
{
    public static class ChromeDriverOptions
    {
        public static ChromeOptions Options => GetChromeOptions();

        private static readonly string[] Arguments =
        [
            "--test-type",
            "--incognito",
            "--start-maximized",
            "--ignore-certificate-errors"
        ];

        private static ChromeOptions GetChromeOptions()

        {
            ChromeOptions chromeOptions = new()
            {
                LeaveBrowserRunning = false,
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArguments(Arguments);

            return chromeOptions;
        }
    }
}