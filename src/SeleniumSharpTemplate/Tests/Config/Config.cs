namespace SeleniumSharpTemplate.Tests.Config
{
    public class Config
    {
        private static Config? instance;

        public string? UrlGoogle { get; set; }

        public static void RegisterConfigInstance(Config config) =>
            instance = config;

        public static Config GetConfig() => instance ?? throw new NullReferenceException("Please configure Configs");
    }
}
