namespace SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.Firefox
{
    public static class FirefoxDriverServiceCreator
    {
        private const string DRIVER_FOLDER_NAME = "Drivers";
        private const string SE_CACHE_PATH = "SE_CACHE_PATH";
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static FirefoxDriverService Service
        {
            get
            {
                DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, DRIVER_FOLDER_NAME)}");
                if (!driverPath.Exists) driverPath.Create();

                Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.Start();

                return service;
            }
        }
    }
}