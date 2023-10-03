using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class TicketPurchaseSteps
{
    private readonly HomePage homePage;
    private readonly TicketPurchasePage ticketPurchasePage;
    private readonly TicketsSelectionPage ticketsSelectionPage;

    public TicketPurchaseSteps(IWebDriver driver)
    {
        ticketPurchasePage = new TicketPurchasePage(driver);
        homePage = new HomePage(driver);
        ticketsSelectionPage = new TicketsSelectionPage(driver);
    }

    [Given(@"the user is on the website")]
    public void GoToURL()
    {
        homePage.NavigateToUrl();
    }

    [When(@"the user selects a random ""Me interesa"" button")]
    public void SelectMeInteresaButton()
    {
        homePage.ClickRandomMeInteresaButton();
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

    [When(@"checks if it has sessions or advanced date picker")]
    public void HaveSessions()
    {
        if (ticketPurchasePage.HaveSession())
            ticketPurchasePage.SelectSession();
        else if (ticketPurchasePage.HaveMoreSessions()) ticketPurchasePage.SelectMoreSessions();

        // else
        // {
        //    ticketPurchasePage.CompletePersonalInformation("Adolfo", "Han", "33511838A", "ahan@experticket.com", "123456789");
        // }
    }

    [When(@"completes personal information")]
    public void CompletePersonalInformation()
    {
        ticketPurchasePage.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com",
            "123456789");
    }

    [When(@"checks the Conditions checkbox")]
    public void CheckTheConditionsCheckbox()
    {
        ticketPurchasePage.CheckConditions();
    }

    [When(@"checks the Privacy checkbox")]
    public void CheckThePrivacyCheckbox()
    {
        ticketPurchasePage.CheckPrivacy();
    }

    [When(@"does not checks the Conditions and Privacy checkboxes")]
    public void NoCheckTheConditionsAndPrivacyCheckboxes()
    {
    }

    [When(@"clicks the ""Comprar"" button again")]
    public void ClicksComprarButtonAgain()
    {
        ticketPurchasePage.ClickComprarButtonAgain();
    }

    [When(@"completes the card information")]
    public void CompleteTheCardInformation()
    {
        ticketPurchasePage.CompleteCardInformation("4548810000000003", "12", "49", "123");
    }

    [When(@"clicks the ""Pagar"" button")]
    public void ClickPagarButton()
    {
        ticketPurchasePage.ClickPagarButton();
    }

    [When(@"clicks the ""Enviar"" button")]
    public void ClickThEnviarButton()
    {
        ticketPurchasePage.ClickEnviarButton();
    }

    [When(@"clicks the ""Continuar"" button")]
    public void ClickThContinuarButton()
    {
        ticketPurchasePage.ClickContinuarButton();
    }

    [Then(@"should be able to download the tickets")]
    public void DownloadTheTickets()
    {
        ticketPurchasePage.ClickDescargarButton();
    }
}