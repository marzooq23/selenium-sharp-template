using OpenQA.Selenium.Firefox;

namespace Automation.Framework.WebDrivers.ServiceCreator.Firefox;

public static class FirefoxDriverServiceCreator
{
    public static FirefoxDriverService Service
    {
        get
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

            service.Start();

            return service;
        }
    }
}