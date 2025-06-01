namespace Automation.Framework.DateTime;

public static class DateTimeFormatter
{
    private const string FORMAT_YYYY_MM_DD = "yyyy-MM-dd";
    private const string FORMAT_HH_MM_SS = "HH:mm:ss";
    private const string FORMAT_UTC = "zzz";

    public static string NOW_YYYY_MM_DD_HH_MM_SS_UTC
    {
        get
        {
            return DateTimeOffset.Now.ToString($"{FORMAT_YYYY_MM_DD} {FORMAT_HH_MM_SS} {FORMAT_UTC}");
        }
    }

    public static string NOW_DD_MM_YYYY
    {
        get
        {
            return System.DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
}