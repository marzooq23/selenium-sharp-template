using OpenQA.Selenium.Chrome;

namespace Automation.Framework.WebDrivers.ServiceCreator.Chrome;

public static class ChromeDriverServiceCreator
{
    public static ChromeDriverService Service
    {
        get
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

            service.Start();

            return service;
        }
    }
}