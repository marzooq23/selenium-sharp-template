using Automation.Tests.Configuration;

namespace Automation.Tests.Pages;

public class ParaBankHomePage(IWebDriver driver, Config config) : BasePage(driver)
{
    public void GoToParaBank()
    {
        driver.Navigate().GoToUrl(config.UrlParaBank);
    }

    public void GoToParaBankRegistration()
    {
        driver.Navigate().GoToUrl(config.UrlParaBankRegister);
    }

    public string GetPageTitle
    {
        get
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver.Title;
        }
    }

    public void ClickOnMenu(string menuOption)
    {
        driver.FindElement(Locators.MenuOptions(menuOption)).Click();
    }

    private static class Locators
    {
        public static By MenuOptions(string menuOption) => By.XPath($"//ul[@class='leftmenu']/li/a[text()='{menuOption}']");
    }
}