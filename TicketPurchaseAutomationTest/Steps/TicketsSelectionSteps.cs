using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class TicketsSelectionSteps(IWebDriver? driver)
{
    private readonly TicketsSelectionPage ticketsSelectionPage = new(driver);

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