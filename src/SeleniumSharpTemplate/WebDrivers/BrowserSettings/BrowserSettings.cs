namespace SeleniumSharpTemplate.WebDrivers.BrowserSettings
{
    public class BrowsersSettings
    {
        private static BrowsersSettings? instance;

        public bool CrossBrowserTesting { get; set; }

        public static void RegisterBrowsersSettingsInstance(BrowsersSettings browsersSettings) =>
            instance = browsersSettings;

        public static BrowsersSettings GetBrowsersSettings() => instance!;
    }
}