namespace SeleniumSharpTemplate.WebDrivers.Options.InternetExplorer
{
    public static class InternetExplorerDriverOptions
    {
        const string EDGE_BIN = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        public static InternetExplorerOptions Options => new()
        {
            AttachToEdgeChrome = true,
            EdgeExecutablePath = EDGE_BIN,
            BrowserCommandLineArguments = "-private",
        };

        public static InternetExplorerOptions HeadlessOptions => GetInternetExplorerHeadlessOptions();

        private static InternetExplorerOptions GetInternetExplorerHeadlessOptions()
        {
            InternetExplorerOptions ieHeadlessOptions = Options;

            ieHeadlessOptions.AddAdditionalOption("headless", true);

            return ieHeadlessOptions;
        }
    }
}
