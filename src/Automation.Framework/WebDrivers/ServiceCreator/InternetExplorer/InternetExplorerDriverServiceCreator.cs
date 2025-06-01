using OpenQA.Selenium.IE;

namespace Automation.Framework.WebDrivers.ServiceCreator.InternetExplorer;

public static class InternetExplorerDriverServiceCreator
{
    public static InternetExplorerDriverService Service
    {
        get
        {
            InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();

            service.Start();

            return service;
        }
    }
}