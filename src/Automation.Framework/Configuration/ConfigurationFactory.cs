using Microsoft.Extensions.Configuration;

namespace Automation.Framework.Configuration;

public static class ConfigurationFactory
{
    public static T? GetBinding<T>(string jsonFileName, string section)
    {
        return new ConfigurationBuilder()
        .AddJsonFile(jsonFileName)
        .Build()
        .GetSection(section)
        .Get<T>();
    }
}