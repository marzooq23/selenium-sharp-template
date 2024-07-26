﻿namespace SeleniumSharpTemplate.Tests.Config
{
    [Binding]
    [DebuggerStepThrough]
    public static class ConfigHooks
    {
        [BeforeScenario]
        public static void RegisterConfig(IObjectContainer objectContainer)
        {
            Config? config = ConfigurationFactory
                .GetBinding<Config>(
                Path
                .Combine(PathFinder.Config, FileAndFolderName.CONFIG_JSON),
                FileAndFolderName.CONFIG_SECTION);

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
}