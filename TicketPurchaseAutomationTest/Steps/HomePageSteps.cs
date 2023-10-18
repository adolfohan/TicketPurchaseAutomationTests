using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class HomePageSteps
{
    private readonly HomePage homePage;

    public HomePageSteps(IWebDriver driver)
    {
        homePage = new HomePage(driver);
    }
    
    public void GoToURL()
    {
        homePage.NavigateToUrl();
    }
    
    public void ClickOnRandomMeInteresaButton()
    {
        homePage.ClickOnRandomMeInteresaButton();
    }
}