namespace SeleniumSharpTemplate.Utilities.Paths
{
    public static class PathFinder
    {
        public static string Bin => AppDomain.CurrentDomain.BaseDirectory;

        public static string BrowserSettings =>
            Path.Combine(Bin, FileAndFolderName.BROWSER_SETTINGS_DIRECTORY);

        public static string Config => Path.Combine(Bin, FileAndFolderName.CONFIG_DIRECTORY);

        public static string KillWebDrivers =>
            Path.Combine(Bin, FileAndFolderName.EXECUTORS_DIRECTORY);

        public static string Logs => Path.Combine(Bin, FileAndFolderName.LOGS_FOLDER_NAME);

        public static string Root
        {
            get
            {
                string root = Directory.GetCurrentDirectory();
                while (!File.Exists(Path.Combine(root, FileAndFolderName.GIT_IGNORE_FILE_NAME)))
                    root = Path.GetFullPath(Path.Combine(root, "../"));

                return root;
            }
        }

        public static string Artefacts =>
            Path.Combine(Root, FileAndFolderName.ARTEFACTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Reports =>
            Path.Combine(Artefacts, FileAndFolderName.REPORTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Screenshots =>
            Path.Combine(Reports, FileAndFolderName.SCREENSHOTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string Pdf =>
            Path.Combine(Reports, FileAndFolderName.PDF_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string ExtentReport =>
            Path.Combine(Reports, FileAndFolderName.EXTENT_REPORTS_FOLDER_NAME)
            .CreatePathIfNotExists();

        public static string FeatureTitleScreenshots { get; set; } = string.Empty;
        public static string FeatureTitlePdf { get; set; } = string.Empty;
        public static string ScenarioTitleScreenshots { get; set; } = string.Empty;
        public static string ScenarioTitlePdf { get; set; } = string.Empty;
    }
}