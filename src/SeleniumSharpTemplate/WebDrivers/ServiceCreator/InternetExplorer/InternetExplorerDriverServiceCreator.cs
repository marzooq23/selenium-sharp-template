namespace SeleniumSharpTemplate.WebDrivers.ServiceCreator.InternetExplorer
{
    public static class InternetExplorerDriverServiceCreator
    {
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static InternetExplorerDriverService Service => CreateInternetExplorerDriverService();

        public static InternetExplorerDriverService CreateInternetExplorerDriverService()
        {
            DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, "Drivers")}");
            if (!driverPath.Exists) driverPath.Create();

            Environment.SetEnvironmentVariable("SE_CACHE_PATH", driverPath.ToString());

            InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
            service.Start();

            return service;
        }
    }
}
