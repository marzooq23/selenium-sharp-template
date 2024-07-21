namespace SeleniumSharpTemplate.Tests.Pages
{
    public class GoogleHomePage(IWebDriver driver) : BasePage(driver)
    {
        public void GoToGoogle() => GoToUrl(Config.Config.GetConfig().UrlGoogle!);

        public void Search(string value)
        {
            SendKeys(Locators.SearchTextBox, value);
            SendKeys(Locators.SearchTextBox, Keys.Enter);
        }

        private static class Locators
        {
            public static By SearchTextBox => By.CssSelector("[name='q']");
        }
    }
}