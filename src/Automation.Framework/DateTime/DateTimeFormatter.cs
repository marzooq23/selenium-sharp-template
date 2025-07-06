namespace Automation.Framework.DateTime;

public static class DateTimeFormatter
{
    public const string FORMAT_YYYY_MM_DD = "yyyy-MM-dd";
    public const string FORMAT_DD_MM_YYYY = "dd-MM-yyyy";
    public const string FORMAT_HH_MM_SS = "HH:mm:ss";
    public const string FORMAT_H_MM_SS_TT = "h:mm:ss tt";
    public const string FORMAT_UTC = "zzz";

    public static string NOW_YYYY_MM_DD_HH_MM_SS_UTC
    {
        get
        {
            return DateTimeOffset.Now.ToString($"{FORMAT_YYYY_MM_DD} {FORMAT_HH_MM_SS} {FORMAT_UTC}");
        }
    }

    public static string NOW_DD_MM_YYYY_HH_MM_SS_UTC
    {
        get
        {
            return DateTimeOffset.Now.ToString($"{FORMAT_DD_MM_YYYY} {FORMAT_HH_MM_SS} {FORMAT_UTC}");
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