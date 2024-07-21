namespace SeleniumSharpTemplate.Utilities.WebDrivers.CrossBrowserTestFixture
{
    [TestFixture]
    [Parallelizable]
    public class CrossBrowserTestFixture()
    {
        private IWebDriver? driver;
        private GoogleHomePage? _googleHomePage;
        private bool _isCrossBrowserTestingEnabled;

        [SetUp]
        public void SetUp()
        {
            _isCrossBrowserTestingEnabled = BrowserSettings.BrowserSettings.GetBrowsersSettings().CrossBrowserTesting;
        }

        [Test]
        [TestCase(BrowserType.ChromeHeadless)]
        [TestCase(BrowserType.EdgeHeadless)]
        [TestCase(BrowserType.FirefoxHeadless)]
        public void RunTestsLaunchGoogleCalculatorOnCrossBrowsers(BrowserType browserType)
        {
            if (!_isCrossBrowserTestingEnabled) return;
            driver = WebDriverFactory.CreateWebDriver(browserType);

            TestGoogleCalculator();
        }

        public void TestGoogleCalculator()
        {
            _googleHomePage = new GoogleHomePage(driver!);
            const string searchText = "calculator";
            _googleHomePage.GoToGoogle();
            _googleHomePage.Search(searchText);
            _googleHomePage.GetPageTitle.Should().StartWith(searchText);
        }

        [TearDown]
        public void TearDown() => driver!.Close();
    }
}