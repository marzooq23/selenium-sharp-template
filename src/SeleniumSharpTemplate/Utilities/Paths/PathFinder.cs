﻿namespace SeleniumSharpTemplate.Utilities.Paths
{
    public static class PathFinder
    {
        private const string LOGS_FOLDER_NAME = "Logs";
        private const string REPORTS_FOLDER_NAME = "Reports";
        private const string GIT_IGNORE_FILE_NAME = ".gitignore";
        private const string ARTEFACTS_FOLDER_NAME = "Artefacts";
        private const string SCREENSHOTS_FOLDER_NAME = "Screenshots";
        private const string PDF_FOLDER_NAME = "Pdf";
        private const string CONFIG_DIRECTORY = "Tests\\Configuration";
        private const string EXECUTORS_DIRECTORY = "Utilities\\Executors";
        private const string BROWSER_SETTINGS_DIRECTORY = "Utilities\\WebDrivers\\BrowserOptions";

        public static string Bin => AppDomain.CurrentDomain.BaseDirectory;

        public static string BrowserSettings =>
            Path.Combine(Bin, BROWSER_SETTINGS_DIRECTORY);

        public static string Config => Path.Combine(Bin, CONFIG_DIRECTORY);

        public static string KillWebDrivers =>
            Path.Combine(Bin, EXECUTORS_DIRECTORY);

        public static string Logs => Path.Combine(Bin, LOGS_FOLDER_NAME);

        public static string Root
        {
            get
            {
                string root = Directory.GetCurrentDirectory();
                while (!File.Exists(Path.Combine(root, GIT_IGNORE_FILE_NAME)))
                    root = Path.GetFullPath(Path.Combine(root, "../"));

                return root;
            }
        }

        public static string Artefacts =>
            Path.Combine(Root, ARTEFACTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Reports =>
            Path.Combine(Artefacts, REPORTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Screenshots =>
            Path.Combine(Reports, SCREENSHOTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Pdf =>
            Path.Combine(Reports, PDF_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string FeatureTitleScreenshots { get; set; } = string.Empty;
        public static string FeatureTitlePdf { get; set; } = string.Empty;
        public static string ScenarioTitleScreenshots { get; set; } = string.Empty;
        public static string ScenarioTitlePdf { get; set; } = string.Empty;
    }
}