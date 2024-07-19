namespace SeleniumSharpTemplate.WebDrivers.ServiceCreator.Edge
{
    public static class EdgeDriverServiceCreator
    {
        private static string GetBinaryLocation => AppDomain.CurrentDomain.BaseDirectory;

        public static EdgeDriverService Service => CreateEdgeDriverService();

        public static EdgeDriverService CreateEdgeDriverService()
        {
            DirectoryInfo driverPath = new($"{Path.Combine(GetBinaryLocation, "Drivers")}");
            if (!driverPath.Exists) driverPath.Create();

            Environment.SetEnvironmentVariable("SE_CACHE_PATH", driverPath.ToString());

            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            service.Start();

            return service;
        }
    }
}