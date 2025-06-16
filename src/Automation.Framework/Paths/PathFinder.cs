using Automation.Framework.DateTime;

namespace Automation.Framework.Paths;

public static class PathFinder
{
    public const string TXT = ".txt";
    public const string DRIVER = "Drivers";
    public const string LOG_TXT = "log.txt";
    public const string PDF_FOLDER_NAME = "Pdf";
    public const string CONFIG_SECTION = "Config";
    public const string LOGS_FOLDER_NAME = "Logs";
    public const string CONFIG_JSON = "Config.json";
    public const string REPORTS_FOLDER_NAME = "Reports";
    public const string EXECUTORS_DIRECTORY = "Executors";
    public const string CONFIG_DIRECTORY = "Configuration";
    public const string GIT_IGNORE_FILE_NAME = ".gitignore";
    public const string ARTEFACTS_FOLDER_NAME = "Artefacts";
    public const string EXTENT_REPORTS_FOLDER_NAME = "Extent";
    public const string SCREENSHOTS_FOLDER_NAME = "Screenshots";
    public const string EXTENT_REPORTS_HTML = "ExtentReport.html";
    public const string KILL_WEBDRIVERS_BAT = "KillWebDrivers.bat";
    public const string BROWSERSETTINGS_SECTION = "BrowserSettings";
    public const string BROWSERSETTINGS_JSON = "BrowserSettings.json";

    public static string Bin
    {
        get
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

    public static string BrowserSettings
    {
        get
        {
            return Path.Combine(Bin, CONFIG_DIRECTORY);
        }
    }

    public static string Config
    {
        get
        {
            return Path.Combine(Bin, CONFIG_DIRECTORY);
        }
    }

    public static string KillWebDrivers
    {
        get
        {
            return Path.Combine(Bin, EXECUTORS_DIRECTORY);
        }
    }

    public static string Logs
    {
        get
        {
            return Path.Combine(Artefacts, LOGS_FOLDER_NAME);
        }
    }

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

    public static string Artefacts
    {
        get
        {
            return Path.Combine(Root, ARTEFACTS_FOLDER_NAME).CreateFolderIfNotExists();
        }
    }

    public static string Reports
    {
        get
        {
            return Path.Combine(Artefacts, REPORTS_FOLDER_NAME).CreateFolderIfNotExists();
        }
    }

    public static string Screenshots
    {
        get
        {
            return Path.Combine(Reports, SCREENSHOTS_FOLDER_NAME).CreateFolderIfNotExists();
        }
    }

    public static string Pdf
    {
        get
        {
            return Path.Combine(Reports, PDF_FOLDER_NAME).CreateFolderIfNotExists();
        }
    }

    public static string PdfToday
    {
        get
        {
            return Path.Combine(Pdf, DateTimeFormatter.NOW_DD_MM_YYYY);
        }
    }

    public static string ExtentReport
    {
        get
        {
            return Path.Combine(Reports, EXTENT_REPORTS_FOLDER_NAME).CreateFolderIfNotExists();
        }
    }
}