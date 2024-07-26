using OpenQA.Selenium.Firefox;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.Firefox
{
    public static class FirefoxDriverServiceCreator
    {
        private const string SE_CACHE_PATH = "SE_CACHE_PATH";

        public static FirefoxDriverService Service
        {
            get
            {
                DirectoryInfo driverPath =
                    new($"{Path.Combine(PathFinder.Bin, FileAndFolderName.DRIVER)}");
                if (!driverPath.Exists) driverPath.Create();

                Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.Start();

                return service;
            }
        }
    }
}