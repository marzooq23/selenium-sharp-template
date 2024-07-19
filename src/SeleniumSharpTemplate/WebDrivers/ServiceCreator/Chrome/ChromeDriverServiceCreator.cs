namespace SeleniumSharpTemplate.WebDrivers.ServiceCreator.Chrome
{
    public static class ChromeDriverServiceCreator
    {
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static ChromeDriverService Service => CreateChromeDriverService();

        public static ChromeDriverService CreateChromeDriverService()
        {
            DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, "Drivers")}");
            if (!driverPath.Exists) driverPath.Create();

            Environment.SetEnvironmentVariable("SE_CACHE_PATH", driverPath.ToString());

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.Start();

            return service;
        }
    }
}