namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserOptions
{
    public class BrowserSettings
    {
        private static BrowserSettings? instance;

        public string? EdgeBin { get; set; }

        public static void RegisterInstance(BrowserSettings browsersSettings) =>
            instance = browsersSettings ?? throw new NullReferenceException("Please configure BrowserSettings");

        public static BrowserSettings Instance() =>
            instance ?? throw new NullReferenceException("Please configure BrowserSettings");
    }
}