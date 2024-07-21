namespace SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.InternetExplorer
{
    public static class InternetExplorerDriverServiceCreator
    {
        private const string DRIVER_FOLDER_NAME = "Drivers";
        private const string SE_CACHE_PATH = "SE_CACHE_PATH";

        public static InternetExplorerDriverService Service
        {
            get
            {
                DirectoryInfo driverPath = new($"{Path.Combine(Directories.GetBinLocation, DRIVER_FOLDER_NAME)}");
                if (!driverPath.Exists) driverPath.Create();

                Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
                service.Start();

                return service;
            }
        }
    }
}