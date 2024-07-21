namespace SeleniumSharpTemplate.Tests.Pages
{
    public class GoogleHomePage(IWebDriver driver) : BasePage(driver)
    {
        public void GoToGoogle() => driver.Navigate().GoToUrl(Config.Config.GetConfig().UrlGoogle!);

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
}