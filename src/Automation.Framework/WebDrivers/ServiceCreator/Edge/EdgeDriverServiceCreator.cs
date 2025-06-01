using OpenQA.Selenium.Edge;

namespace Automation.Framework.WebDrivers.ServiceCreator.Edge;

public static class EdgeDriverServiceCreator
{
    private const string SE_CACHE_PATH = "SE_CACHE_PATH";

    public static EdgeDriverService Service
    {
        get
        {
            DirectoryInfo driverPath =
                new($"{Path.Combine(PathFinder.Bin, PathFinder.DRIVER)}");
            if (!driverPath.Exists)
            {
                driverPath.Create();
            }

            Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            service.Start();

            return service;
        }
    }
}