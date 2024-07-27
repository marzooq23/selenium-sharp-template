using OpenQA.Selenium.Support.Events;
using SeleniumSharpTemplate.Utilities.DateTime;

namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    [DebuggerStepThrough]
    public static class DriverEventListeners
    {
        private const string PASSWORD_MASK = "********";

        private static string EVENT => DateTimeFormatter.NOW_YYYY_MM_DD_HH_MM_SS_UTC + " [EVENT]";

        private static readonly Dictionary<IWebElement, string> WebElementNames = [];

        private static readonly List<string> ListOfAttributes = ["value", "name", "id", "placeholder", "class"];

        public static void ExceptionThrown(object? sender, WebDriverExceptionEventArgs eventArgs) =>
            Console.WriteLine($"{EVENT} Exception: {eventArgs.ThrownException.Message}");

        public static void ElementClicking(object? sender, WebElementEventArgs eventArgs) =>
            WebElementNames[eventArgs.Element] = ElementProperty(eventArgs.Element);

        public static void ElementClicked(object? sender, WebElementEventArgs eventArgs) =>
            Console.WriteLine($"{EVENT} Element '{WebElementNames[eventArgs.Element]}' is clicked");

        public static void ElementValueChanged(object? sender, WebElementValueEventArgs eventArgs)
        {
            WebElementNames[eventArgs.Element] = eventArgs.Element.GetAttribute("name");

            if (eventArgs.Value != null)
                Console.WriteLine($"{EVENT} Element '{eventArgs.Element.GetAttribute("name")}' value changed from '{WebElementNames[eventArgs.Element]}' to: '{ElementProperty(eventArgs.Element)}'");
        }

        public static void FindElementCompleted(object? sender, FindElementEventArgs eventArgs) =>
            Console.WriteLine($"{EVENT} Found element: '{eventArgs.FindMethod}'");

        public static void Navigated(object? sender, WebDriverNavigationEventArgs eventArgs) =>
            Console.WriteLine($"{EVENT} Navigated to: '{eventArgs.Driver.Title}'");

        public static void ScriptExecuted(object? sender, WebDriverScriptEventArgs eventArgs) =>
            Console.WriteLine($"{EVENT} Script '{eventArgs.Script.Split('.')[1].Split('(')[0]}' executed: '{eventArgs.Script}'");

        private static string ElementProperty(IWebElement element)
        {
            if (!string.IsNullOrEmpty(element.Text)) return element.Text;

            if (element.GetAttribute("type") == "password") return PASSWORD_MASK;

            var attributeValue = ListOfAttributes
                .Where(attribute => !string.IsNullOrEmpty(element.GetAttribute(attribute)))
                .Select(attribute => element.GetAttribute(attribute))
                .FirstOrDefault();

            return attributeValue ?? string.Empty;
        }
    }
}