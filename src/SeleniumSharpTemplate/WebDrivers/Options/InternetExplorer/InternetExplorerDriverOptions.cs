namespace SeleniumSharpTemplate.WebDrivers.Options.InternetExplorer
{
    public static class InternetExplorerDriverOptions
    {
        private const string EDGE_BIN = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        public static InternetExplorerOptions Options => new()
        {
            AttachToEdgeChrome = true,
            EdgeExecutablePath = EDGE_BIN,
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
}