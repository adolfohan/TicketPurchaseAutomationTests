using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class TestSteps
{
    //private IWebDriver driver;
    private readonly TestPage testPage;
    private readonly TicketsSelectionPage ticketsSelectionPage;

    public TestSteps(IWebDriver driver)
    {
        //this.driver = driver;
        testPage = new TestPage(driver);
        ticketsSelectionPage = new TicketsSelectionPage(driver);
    }

    //[Given(@"the user is on the website")]
    public void GoToURL()
    {
        testPage.NavigateToUrl();
    }

    //[When(@"the user selects the ""Me interesa"" button")]
    public void SelectMeInteresaButton()
    {
        testPage.ClickMeInteresaButton();
    }

    [When(@"selects the desired date")]
    public void SelectDesiredDate()
    {
        testPage.SelectDate("01/09/2023");
    }

    //[When(@"selects the desired tickets")]
    public void SelectDesiredTicket()
    {
        testPage.SelectTickets("1");
    }

    //[When(@"clicks the ""Comprar"" button")]
    public void ClickComprarButton()
    {
        testPage.ClickComprarButton();
    }

    //[When(@"completes personal information")]
    public void CompletePersonalInformation()
    {
        testPage.CompletePersonalInformation("Adolfo", "Han", "33511838A", "ahan@experticket.com",
            "123456789");
    }

    [When(@"does not completes personal information")]
    public void PersonalInformationInBlank()
    {
        testPage.CompletePersonalInformation("", "", "", "ahan@.com", "");
    }

    [When(@"completes with incorrect personal information")]
    public void IncorrectPersonalInformation()
    {
        testPage.CompletePersonalInformation("49521244", "|@#@~|@!", "ASDASDASD", "?¿)@gmail.com",
            "AAAAAA");
    }

    [When(@"selects credit card as the payment method")]
    public void SelectCreditCard()
    {
        testPage.SelectCreditCardPayment();
    }

    [When(@"checks the Conditions checkbox")]
    public void CheckTheConditionsCheckbox()
    {
        testPage.CheckConditions();
    }

    [When(@"checks the Privacy checkbox")]
    public void CheckThePrivacyCheckbox()
    {
        testPage.CheckPrivacy();
    }

    [When(@"does not checks the Conditions and Privacy checkboxes")]
    public void NoCheckTheConditionsAndPrivacyCheckboxes()
    {
    }

    [When(@"clicks the ""Comprar"" button again")]
    public void ClicksComprarButtonAgain()
    {
        testPage.ClickComprarButtonAgain();
    }

    [When(@"completes the card information")]
    public void CompleteTheCardInformation()
    {
        testPage.CompleteCardInformation("4548810000000003", "12", "49", "123");
    }

    [When(@"completes with wrong ""<card number>""")]
    public void CompleteTheCardWithWrongInformation()
    {
        testPage.CompleteCardInformation("4548810000000002", "12", "49", "123");
    }

    [When(@"clicks the ""Pagar"" button")]
    public void ClickPagarButton()
    {
        testPage.ClickPagarButton();
    }

    [Then(@"the user cannot proceed to the payment with the fields in blank")]
    public void CannotProceedToThePaymentBlankFields()
    {
        testPage.CannotProceedToThePaymentBlankFields();
    }

    [Then(@"clicks the ""Comprar"" button again and the user cannot proceed to the payment")]
    public void ProceedToThePaymentIncorrectInformation()
    {
        testPage.CannotProceedToThePayment();
    }

    // [Then(@"the ticket purchase should be successful")]
    // public void TicketPurchaseShouldBeSuccessful(string expectedMessage)
    // {
    //     var messageElement = ticketPurchasePage.IsTicketPurchaseSuccessful;
    //     var actualMessage = messageElement.Text;
    //
    //     Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    // }

    //AssertionHelper.AssertTrue(isSuccess, "Ticket purchase was unsuccessful.");
    [Then(@"the ticket purchase should be unsuccessful")]
    public void TicketPurchaseShouldBeUnSuccessful()
    {
        testPage.TicketPurchaseUnsuccessful();
    }

    //AssertionHelper.AssertTrue(isSuccess, "Ticket purchase was unsuccessful.");
    [When(@"clicks the ""Enviar"" button")]
    public void ClickThEnviarButton()
    {
        testPage.ClickEnviarButton();
    }

    [When(@"clicks the ""Continuar"" button")]
    public void ClickThContinuarButton()
    {
        testPage.ClickContinuarButton();
    }

    [Then(@"should be able to download the tickets")]
    public void DownloadTheTickets()
    {
        testPage.ClickDescargarButton();
    }
}