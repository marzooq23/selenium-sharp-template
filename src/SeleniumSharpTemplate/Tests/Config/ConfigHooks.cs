namespace SeleniumSharpTemplate.Tests.Config
{
    [Binding]
    [DebuggerStepThrough]
    public static class ConfigHooks
    {
        private const string CONFIG_SECTION = "Config";
        private const string CONFIG_JSON_FILENAME = "Config.json";
        private static string GetConfigLocation => Directories.GetBinLocation + "Tests\\Config\\";

        [BeforeTestRun]
        public static void RegisterConfig(IObjectContainer objectContainer)
        {
            Config? config = ConfigurationFactory
                .GetBinding<Config>(
                GetConfigLocation + CONFIG_JSON_FILENAME,
                CONFIG_SECTION);

            if (config != null)
            {
                objectContainer.RegisterInstanceAs(config);
                Config.RegisterConfigInstance(config);
            }
            else
            {
                throw new NullReferenceException("Please configure Config");
            }
        }
    }
}