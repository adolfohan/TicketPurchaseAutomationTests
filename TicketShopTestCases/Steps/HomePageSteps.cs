using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class HomePageSteps
{
    private readonly HomePage homePage;

    public HomePageSteps(IWebDriver driver)
    {
        homePage = new HomePage(driver);
    }
    
    [Given(@"the user is on the website")]
    public void GoToURL()
    {
        homePage.NavigateToUrl();
    }
    
    [When(@"the user selects a random ""Me interesa"" button")]
    public void ClickRandomMeInteresaButton()
    {
        homePage.ClickRandomMeInteresaButton();
    }
}