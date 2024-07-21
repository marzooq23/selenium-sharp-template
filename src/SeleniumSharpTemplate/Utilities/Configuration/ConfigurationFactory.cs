﻿namespace SeleniumSharpTemplate.Utilities.Configuration
{
    public static class ConfigurationFactory
    {
        public static T? Create<T>(string jsonFilePath) =>
            JsonSerializer.Deserialize<T>(File.ReadAllText(jsonFilePath));

        public static T? GetBinding<T>(string jsonFileName, string section) =>
            new ConfigurationBuilder()
            .AddJsonFile(jsonFileName)
            .Build()
            .GetSection(section)
            .Get<T>();
    }
}