﻿using OpenQA.Selenium.IE;

namespace SeleniumSharpTemplate.Utilities.WebDrivers.ServiceCreator.InternetExplorer
{
    public static class InternetExplorerDriverServiceCreator
    {
        private const string SE_CACHE_PATH = "SE_CACHE_PATH";

        public static InternetExplorerDriverService Service
        {
            get
            {
                DirectoryInfo driverPath =
                    new($"{Path.Combine(PathFinder.Bin, FileAndFolderName.DRIVER)}");
                if (!driverPath.Exists) driverPath.Create();

                Environment.SetEnvironmentVariable(SE_CACHE_PATH, driverPath.ToString());

                InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService();
                service.Start();

                return service;
            }
        }
    }
}