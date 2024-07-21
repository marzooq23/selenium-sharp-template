namespace SeleniumSharpTemplate.Utilities.WebDrivers.CrossBrowserTestFixture
{
    [TestFixture]
    public class CrossBrowserTestFixture()
    {
        private IWebDriver? driver;
        private CalculatorPage? _calculatorPage;
        private bool _isCrossBrowserTestingEnabled;

        [SetUp]
        public void SetUp()
        {
            _isCrossBrowserTestingEnabled = BrowsersSettings.GetBrowsersSettings().CrossBrowserTesting;
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
            _calculatorPage = new CalculatorPage(driver!);
            _calculatorPage.GoToGoogle();
            _calculatorPage.GetPageTitle.Should().StartWith("calculator");
        }

        [TearDown]
        public void TearDown()
        {
            driver!.Close();
        }
    }
}