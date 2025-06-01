using Automation.Tests.Pages;

namespace Automation.Tests.StepDefinitions;

[Binding]
public sealed class RegisterSteps(ParaBankHomePage paraBankHomePage)
{
    [When("user register as (.*) customer")]
    public void WhenUserRegisterAsCustomer(string customerType)
    {
        paraBankHomePage.GoToParaBankRegistration();
        Logger.Information($"User is registering as {customerType} customer.");
    }

    [Then("user should be able to register as (.*) customer")]
    public void ThenUserShouldBeAbleToRegisterAsCustomer(string customerType)
    {
        paraBankHomePage.GetPageTitle.Should().Contain("Register");
        Logger.Information($"User registered as {customerType} customer.");
    }
}