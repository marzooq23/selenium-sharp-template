namespace SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.Chrome
{
    public static class ChromeDriverServiceCreator
    {
        private const string DRIVER_FOLDER_NAME = "Drivers";
        private const string SE_CACHE_PATH = "SE_CACHE_PATH";
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static ChromeDriverService Service
        {
            get
            {
                DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, DRIVER_FOLDER_NAME)}");
                if (!driverPath.Exists) driverPath.Create();

                Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.Start();

                return service;
            }
        }
    }
}