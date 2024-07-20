namespace SeleniumSharpTemplate.WebDrivers.Options.Firefox
{
    public static class FirefoxDriverOptions
    {
        private static readonly string[] AdditionalArguments =
        [
            "--test-type",
            "--incognito",
            "--start-maximized",
            "--ignore-certificate-errors"
        ];

        public static FirefoxOptions Options => GetFirefoxOptions();

        public static FirefoxOptions HeadlessOptions => GetFirefoxHeadlessOptions();

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new()
            {
                AcceptInsecureCertificates = true
            };

            firefoxOptions.AddArguments(AdditionalArguments);

            return firefoxOptions;
        }

        private static FirefoxOptions GetFirefoxHeadlessOptions()
        {
            FirefoxOptions firefoxHeadlessOptions = GetFirefoxOptions();

            firefoxHeadlessOptions.AddArgument("-headless");

            return firefoxHeadlessOptions;
        }
    }
}
