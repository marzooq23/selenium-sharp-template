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

        public static EdgeOptions Options => GetEdgeOptions();

        public static EdgeOptions HeadlessOptions => GetEdgeHeadlessOptions();

        private static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new()
            {
                LeaveBrowserRunning = false,
                AcceptInsecureCertificates = true
            };

            edgeOptions.AddArguments(AdditionalArguments);

            return edgeOptions;
        }

        private static EdgeOptions GetEdgeHeadlessOptions()
        {
            EdgeOptions edgeHeadlessOptions = GetEdgeOptions();

            edgeHeadlessOptions.AddArgument("-headless");

            return edgeHeadlessOptions;
        }
    }
}