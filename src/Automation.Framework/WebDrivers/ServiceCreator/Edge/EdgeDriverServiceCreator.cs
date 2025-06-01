using OpenQA.Selenium.Edge;

namespace Automation.Framework.WebDrivers.ServiceCreator.Edge;

public static class EdgeDriverServiceCreator
{
    public static EdgeDriverService Service
    {
        get
        {
            EdgeDriverService service = EdgeDriverService.CreateDefaultService();

            service.Start();

            return service;
        }
    }
}