namespace Automation.Framework.Paths;

public class PathFinder
{
    public const string TXT = ".txt";

    public const string CONFIG_SECTION = "Config";
    public const string BROWSERSETTINGS_SECTION = "BrowserSettings";

    public const string CONFIG_JSON = "Config.json";
    public const string BROWSERSETTINGS_JSON = "BrowserSettings.json";

    public const string LOG_TXT = "log.txt";

    public const string EXTENT_REPORTS_HTML = "ExtentReport.html";

    public const string KILL_WEBDRIVERS_BAT = "KillWebDrivers.bat";

    public const string DRIVER = "Drivers";
    public const string LOGS_FOLDER_NAME = "Logs";
    public const string REPORTS_FOLDER_NAME = "Reports";
    public const string GIT_IGNORE_FILE_NAME = ".gitignore";
    public const string ARTEFACTS_FOLDER_NAME = "Artefacts";
    public const string EXTENT_REPORTS_FOLDER_NAME = "Extent";
    public const string SCREENSHOTS_FOLDER_NAME = "Screenshots";
    public const string PDF_FOLDER_NAME = "Pdf";
    public const string CONFIG_DIRECTORY = "Configuration";
    public const string EXECUTORS_DIRECTORY = "Executors";

    public static string Bin => AppDomain.CurrentDomain.BaseDirectory;

    public static string BrowserSettings =>
        Path.Combine(Bin, CONFIG_DIRECTORY);

    public static string Config => Path.Combine(Bin, CONFIG_DIRECTORY);

    public static string KillWebDrivers =>
        Path.Combine(Bin, EXECUTORS_DIRECTORY);

    public static string Logs => Path.Combine(Artefacts, LOGS_FOLDER_NAME);

    public static string Root
    {
        get
        {
            string root = Directory.GetCurrentDirectory();
            while (!File.Exists(Path.Combine(root, GIT_IGNORE_FILE_NAME)))
            {
                root = Path.GetFullPath(Path.Combine(root, "../"));
            }

            return root;
        }
    }

    public static string Artefacts =>
        Path.Combine(Root, ARTEFACTS_FOLDER_NAME)
        .CreateFolderIfNotExists();

    public static string Reports =>
        Path.Combine(Artefacts, REPORTS_FOLDER_NAME)
        .CreateFolderIfNotExists();

    public static string Screenshots =>
        Path.Combine(Reports, SCREENSHOTS_FOLDER_NAME)
        .CreateFolderIfNotExists();

    public static string Pdf =>
        Path.Combine(Reports, PDF_FOLDER_NAME)
        .CreateFolderIfNotExists();

    public static string ExtentReport =>
        Path.Combine(Reports, EXTENT_REPORTS_FOLDER_NAME)
        .CreateFolderIfNotExists();

    public string FeatureTitleScreenshots { get; set; } = string.Empty;
    public string FeatureTitlePdf { get; set; } = string.Empty;
    public string ScenarioTitleScreenshots { get; set; } = string.Empty;
    public string ScenarioTitlePdf { get; set; } = string.Empty;
}