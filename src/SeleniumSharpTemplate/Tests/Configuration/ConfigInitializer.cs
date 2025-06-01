namespace SeleniumSharpTemplate.Tests.Configuration;

[Binding]
[DebuggerStepThrough]
internal static class ConfigInitializer
{
    [BeforeScenario]
    public static void RegisterConfig(IObjectContainer objectContainer)
    {
        Config? config = ConfigurationFactory
            .GetBinding<Config>(
            Path
            .Combine(PathFinder.Config, PathFinder.CONFIG_JSON),
            PathFinder.CONFIG_SECTION);

        if (config != null)
        {
            objectContainer.RegisterInstanceAs(config);
        }
        else
        {
            throw new NullReferenceException("Please configure Config");
        }
    }
}