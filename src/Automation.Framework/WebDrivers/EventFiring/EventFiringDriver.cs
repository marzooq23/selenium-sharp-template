using Automation.Framework.Logging.Listeners;
using OpenQA.Selenium.Support.Events;

namespace Automation.Framework.WebDrivers.EventFiring;

[DebuggerStepThrough]
public static class EventFiringDriver
{
    public static IWebDriver ToEventFiringWebDriver(this IWebDriver driver)
    {
        EventFiringWebDriver eventFiringWebDriver = new(driver);
        eventFiringWebDriver.ExceptionThrown += DriverEventListeners.ExceptionThrown;
        eventFiringWebDriver.ElementClicking += DriverEventListeners.ElementClicking;
        eventFiringWebDriver.ElementClicked += DriverEventListeners.ElementClicked;
        eventFiringWebDriver.ElementValueChanged += DriverEventListeners.ElementValueChanged;
        eventFiringWebDriver.FindElementCompleted -= DriverEventListeners.FindElementCompleted;
        eventFiringWebDriver.Navigated += DriverEventListeners.Navigated;
        eventFiringWebDriver.NavigatedBack += DriverEventListeners.Navigated;
        eventFiringWebDriver.NavigatedForward += DriverEventListeners.Navigated;
        eventFiringWebDriver.ScriptExecuted += DriverEventListeners.ScriptExecuted;

        return eventFiringWebDriver;
    }
}