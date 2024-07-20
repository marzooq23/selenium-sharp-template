namespace SeleniumSharpTemplate.Tests.Pages
{
    public class CalculatorPage(IWebDriver driver) : BasePage(driver)
    {
        public void GoToGoogle() => GoToUrl("https://www.google.com/search?q=calculator");
    }
}