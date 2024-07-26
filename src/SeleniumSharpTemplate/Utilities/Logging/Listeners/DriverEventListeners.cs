using OpenQA.Selenium.Support.Events;

namespace SeleniumSharpTemplate.Utilities.Logging.Events
{
    [DebuggerStepThrough]
    public static class DriverEventListeners
    {

        private const string PASSWORD_MASK = "********";

        private static readonly Dictionary<IWebElement, string> WebElementNames = [];

        private static readonly List<string> ListOfAttributes = ["value", "name", "id", "placeholder", "class"];

        public static void ExceptionThrown(object? sender, WebDriverExceptionEventArgs eventArgs) =>
            Logger.Log.Error($"Exception: {eventArgs.ThrownException.Message}");

        public static void ElementClicking(object? sender, WebElementEventArgs eventArgs) =>
            WebElementNames[eventArgs.Element] = ElementProperty(eventArgs.Element);

        public static void ElementClicked(object? sender, WebElementEventArgs eventArgs) =>
            Logger.Log.Debug($"Element '{WebElementNames[eventArgs.Element]}' is clicked");

        public static void ElementValueChanged(object? sender, WebElementValueEventArgs eventArgs)
        {
            WebElementNames[eventArgs.Element] = eventArgs.Element.GetAttribute("name");

            if (eventArgs.Value != null)
                Logger.Log.Debug($"Element '{eventArgs.Element.GetAttribute("name")}' value changed from '{WebElementNames[eventArgs.Element]}' to: '{ElementProperty(eventArgs.Element)}'");
        }

        public static void FindElementCompleted(object? sender, FindElementEventArgs eventArgs) =>
            Logger.Log.Debug($"Found element: '{eventArgs.FindMethod}'");

        public static void Navigated(object? sender, WebDriverNavigationEventArgs eventArgs) =>
            Logger.Log.Information($"Navigated to: '{eventArgs.Driver.Title}'");

        public static void ScriptExecuted(object? sender, WebDriverScriptEventArgs eventArgs) =>
            Logger.Log.Debug($"Script '{eventArgs.Script.Split('.')[1].Split('(')[0]}' executed: '{eventArgs.Script}'");

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