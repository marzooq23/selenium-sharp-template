namespace SeleniumSharpTemplate.Utilities.Logging
{
    public interface ILogger
    {
        static Logger? Log { get; set; }

        void Debug(string message);

        void Error(string message);

        void Fatal(string message);

        void Information(string message);

        void Warning(string message);
    }
}