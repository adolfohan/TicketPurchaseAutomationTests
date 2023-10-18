using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class TicketsSelectionSteps
{
    private readonly TicketsSelectionPage ticketsSelectionPage;
    
    public TicketsSelectionSteps(IWebDriver driver)
    {
        ticketsSelectionPage = new TicketsSelectionPage(driver);
    }

    public void SelectDesiredTicket()
    {
        ticketsSelectionPage.SelectNumberOfTickets("1");
    }

    public void ConfirmDate()
    {
        ticketsSelectionPage.ConfirmDate();
    }

    public void ClickOnComprarButton()
    {
        ticketsSelectionPage.ClickOnComprarButton();
    }
}