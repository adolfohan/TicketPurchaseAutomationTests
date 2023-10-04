using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

public class TicketsSelectionSteps
{
    private readonly TicketsSelectionPage ticketsSelectionPage;
    
    public TicketsSelectionSteps(IWebDriver driver)
    {
        ticketsSelectionPage = new TicketsSelectionPage(driver);
    }

    [When(@"selects the desired tickets")]
    public void SelectDesiredTicket()
    {
        ticketsSelectionPage.SelectNumberOfTickets("1");
    }
    
    [When(@"confirms the date")]
    public void ConfirmDate()
    {
        ticketsSelectionPage.ConfirmDate();
    }
    
    [When(@"clicks the ""Comprar"" button")]
    public void ClickComprarButton()
    {
        ticketsSelectionPage.ClickComprarButton();
    }
}