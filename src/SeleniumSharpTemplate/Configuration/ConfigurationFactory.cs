namespace SeleniumSharpTemplate.Configuration
{
    public static class ConfigurationFactory
    {
        public static T? Create<T>(string jsonFilePath) => 
            JsonSerializer.Deserialize<T>(File.ReadAllText(jsonFilePath));
    }
}
