namespace SeleniumSharpTemplate.WebDrivers.Options.Edge
{
    public static class EdgeDriverOptions
    {
        private static readonly string[] AdditionalArguments =
        [
            "--test-type",
            "--inprivate",
            "--start-maximized",
            "--ignore-certificate-errors"
        ];

        public static EdgeOptions Options
        {
            get
            {
                EdgeOptions edgeOptions = new()
                {
                    LeaveBrowserRunning = false,
                    AcceptInsecureCertificates = true
                };

                edgeOptions.AddArguments(AdditionalArguments);

                return edgeOptions;
            }
        }

        public static EdgeOptions HeadlessOptions
        {
            get
            {
                EdgeOptions edgeHeadlessOptions = Options;

                edgeHeadlessOptions.AddArgument("-headless");

                return edgeHeadlessOptions;
            }
        }
    }
}