using Automation.Tests.Configuration;

namespace Automation.Tests.Pages;

public class GoogleHomePage(IWebDriver driver, Config config) : BasePage(driver)
{
    public void GoToGoogle()
    {
        driver.Navigate().GoToUrl(config.UrlGoogle);
    }

    public void Search(string value)
    {
        IWebElement searchTextBox = driver.FindElement(Locators.SearchTextBox);
        searchTextBox.SendKeys(value);
        searchTextBox.Submit();
        WaitUntilTitleContains(value);
    }

    public string GetPageTitle
    {
        get
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver.Title;
        }
    }

    private static class Locators
    {
        public static By SearchTextBox => By.CssSelector("[name='q']");
    }
}