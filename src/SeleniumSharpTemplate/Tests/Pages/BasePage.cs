namespace SeleniumSharpTemplate.Tests.Pages
{
    public class BasePage(IWebDriver driver)
    {
        public readonly IWebDriver driver = driver ?? throw new ArgumentNullException(nameof(driver));

        public void GoToUrl(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GoToUrl(Uri url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetPageTitle => driver.Title;
    }
}
