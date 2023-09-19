using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class TicketPurchaseeeeSteps
{
    //private IWebDriver driver;
    private readonly TicketPurchasePageeee _ticketPurchasePageeee;

    public TicketPurchaseeeeSteps(IWebDriver driver)
    {
        //this.driver = driver;
        _ticketPurchasePageeee = new TicketPurchasePageeee(driver);
    }

    //[Given(@"the user is on the website")]
    public void GoToURL()
    {
        _ticketPurchasePageeee.NavigateToUrl();
    }

    //[When(@"the user selects the ""Me interesa"" button")]
    public void SelectMeInteresaButton()
    {
        _ticketPurchasePageeee.ClickMeInteresaButton();
    }

    [When(@"selects the desired date")]
    public void SelectDesiredDate()
    {
        _ticketPurchasePageeee.SelectDate("01/09/2023");
    }

    //[When(@"selects the desired tickets")]
    public void SelectDesiredTicket()
    {
        _ticketPurchasePageeee.SelectTickets("1");
    }

    //[When(@"clicks the ""Comprar"" button")]
    public void ClickComprarButton()
    {
        _ticketPurchasePageeee.ClickComprarButton();
    }

    //[When(@"completes personal information")]
    public void CompletePersonalInformation()
    {
        _ticketPurchasePageeee.CompletePersonalInformation("Adolfo", "Han", "33511838A", "ahan@experticket.com",
            "123456789");
    }

    [When(@"does not completes personal information")]
    public void PersonalInformationInBlank()
    {
        _ticketPurchasePageeee.CompletePersonalInformation("", "", "", "ahan@.com", "");
    }

    [When(@"completes with incorrect personal information")]
    public void IncorrectPersonalInformation()
    {
        _ticketPurchasePageeee.CompletePersonalInformation("49521244", "|@#@~|@!", "ASDASDASD", "?¿)@gmail.com", "AAAAAA");
    }

    [When(@"selects credit card as the payment method")]
    public void SelectCreditCard()
    {
        _ticketPurchasePageeee.SelectCreditCardPayment();
    }

    [When(@"checks the Conditions checkbox")]
    public void CheckTheConditionsCheckbox()
    {
        _ticketPurchasePageeee.CheckConditions();
    }

    [When(@"checks the Privacy checkbox")]
    public void CheckThePrivacyCheckbox()
    {
        _ticketPurchasePageeee.CheckPrivacy();
    }

    [When(@"does not checks the Conditions and Privacy checkboxes")]
    public void NoCheckTheConditionsAndPrivacyCheckboxes()
    {
    }

    [When(@"clicks the ""Comprar"" button again")]
    public void ClicksComprarButtonAgain()
    {
        _ticketPurchasePageeee.ClickComprarButtonAgain();
    }

    [When(@"completes the card information")]
    public void CompleteTheCardInformation()
    {
        _ticketPurchasePageeee.CompleteCardInformation("4548810000000003", "12", "49", "123");
    }

    [When(@"completes with wrong card information")]
    public void CompleteTheCardWithWrongInformation()
    {
        _ticketPurchasePageeee.CompleteCardInformation("4548810000000002", "12", "49", "123");
    }

    [When(@"clicks the ""Pagar"" button")]
    public void ClickPagarButton()
    {
        _ticketPurchasePageeee.ClickPagarButton();
    }

    [Then(@"the user cannot proceed to the payment with the fields in blank")]
    public void CannotProceedToThePaymentBlankFields()
    {
        _ticketPurchasePageeee.CannotProceedToThePaymentBlankFields();
    }

    [Then(@"clicks the ""Comprar"" button again and the user cannot proceed to the payment")]
    public void ProceedToThePaymentIncorrectInformation()
    {
        _ticketPurchasePageeee.CannotProceedToThePayment();
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
        _ticketPurchasePageeee.TicketPurchaseUnsuccessful();
    }

    //AssertionHelper.AssertTrue(isSuccess, "Ticket purchase was unsuccessful.");
    [When(@"clicks the ""Enviar"" button")]
    public void ClickThEnviarButton()
    {
        _ticketPurchasePageeee.ClickEnviarButton();
    }

    [When(@"clicks the ""Continuar"" button")]
    public void ClickThContinuarButton()
    {
        _ticketPurchasePageeee.ClickContinuarButton();
    }

    [Then(@"should be able to download the tickets")]
    public void DownloadTheTickets()
    {
        _ticketPurchasePageeee.ClickDescargarButton();
    }
}