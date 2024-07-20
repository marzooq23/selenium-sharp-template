namespace SeleniumSharpTemplate.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions(CalculatorPage calculatorPage)
    {
        [Given("I launch google calculator")]
        public void GivenILaunchGoogleCalculator()
        {
            calculatorPage.GoToGoogle();
        }
    }
}