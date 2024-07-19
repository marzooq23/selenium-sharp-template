namespace SeleniumSharpTemplate.WebDrivers.Options.Edge
{
    public static class EdgeDriverOptions
    {
        public static EdgeOptions Options => GetEdgeOptions();

        private static readonly string[] Arguments =
        [
            "--test-type",
            "--incognito",
            "--start-maximized",
            "--ignore-certificate-errors"
        ];

        private static EdgeOptions GetEdgeOptions()

        {
            EdgeOptions edgeOptions = new()
            {
                LeaveBrowserRunning = false,
                AcceptInsecureCertificates = true
            };

            edgeOptions.AddArguments(Arguments);

            return edgeOptions;
        }
    }
}