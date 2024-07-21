namespace SeleniumSharpTemplate.Tests.Config
{
    [Binding]
    [DebuggerStepThrough]
    public static class ConfigHooks
    {
        [BeforeTestRun]
        public static void RegisterConfig(IObjectContainer objectContainer)
        {
            Config? config = ConfigurationFactory.Create<Config>("Config.json");

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