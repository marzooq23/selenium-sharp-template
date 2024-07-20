namespace SeleniumSharpTemplate.WebDrivers.ServiceCreator.Firefox
{
    public static class FirefoxDriverServiceCreator
    {
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static FirefoxDriverService Service => CreateFirefoxDriverService();

        public static FirefoxDriverService CreateFirefoxDriverService()
        {
            DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, "Drivers")}");
            if (!driverPath.Exists) driverPath.Create();

            Environment.SetEnvironmentVariable("SE_CACHE_PATH", driverPath.ToString());

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.Start();

            return service;
        }
    }
}