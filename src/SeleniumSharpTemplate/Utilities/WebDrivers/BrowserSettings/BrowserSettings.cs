namespace SeleniumSharpTemplate.Utilities.WebDrivers.BrowserSettings
{
    public class BrowserSettings
    {
        private static BrowserSettings? instance;

        public bool CrossBrowserTesting { get; set; }

        public string? EdgeBin { get; set; }

        public static void RegisterBrowsersSettingsInstance(BrowserSettings browsersSettings) =>
            instance = browsersSettings;

        public static BrowserSettings GetBrowsersSettings() => instance ?? throw new NullReferenceException("Please configure BrowsersSettings");
    }
}