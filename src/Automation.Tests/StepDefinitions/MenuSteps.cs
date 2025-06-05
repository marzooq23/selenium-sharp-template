using Automation.Tests.Pages;

namespace Automation.Tests.StepDefinitions;

[Binding]
public sealed class MenuSteps(ParaBankHomePage paraBankHomePage)
{
    [Given("user launches para bank")]
    public void GivenUserLaunchesParaBank()
    {
        paraBankHomePage.GoToParaBank();
    }

    [When("user clicks on (.*) from menu")]
    public void WhenUserClicksOnOptionFromMenu(string menuOption)
    {
        paraBankHomePage.ClickOnMenu(menuOption);
        Logger.Information($"User is opening {menuOption} from menu");
    }

    [Then("user should be able to view (.*) page")]
    public void ThenUserShouldBeAbleToViewPage(string menuOption)
    {
        paraBankHomePage.GetPageTitle.Should().Contain(menuOption);
        Logger.Information($"{menuOption} displayed");
    }
}