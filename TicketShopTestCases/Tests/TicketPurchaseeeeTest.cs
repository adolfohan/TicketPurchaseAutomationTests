using NUnit.Framework;
using OpenQA.Selenium;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Tests;

[TestFixture]
public class TicketPurchaseeeeTest
{
    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.CreateWebDriver();
        _ticketPurchaseeeeSteps = new TicketPurchaseeeeSteps(driver);
    }

    private IWebDriver driver;
    private TicketPurchaseeeeSteps _ticketPurchaseeeeSteps;

    [Test]
    public void TestTicketPurchase()
    {
        _ticketPurchaseeeeSteps.GoToURL();
        _ticketPurchaseeeeSteps.SelectMeInteresaButton();
        _ticketPurchaseeeeSteps.SelectDesiredDate();
        _ticketPurchaseeeeSteps.SelectDesiredTicket();
        _ticketPurchaseeeeSteps.ClickComprarButton();
        _ticketPurchaseeeeSteps.CompletePersonalInformation();
        _ticketPurchaseeeeSteps.SelectCreditCard();
        _ticketPurchaseeeeSteps.CheckTheConditionsCheckbox();
        _ticketPurchaseeeeSteps.CheckThePrivacyCheckbox();
        _ticketPurchaseeeeSteps.ClicksComprarButtonAgain();
        _ticketPurchaseeeeSteps.CompleteTheCardInformation();
        _ticketPurchaseeeeSteps.ClickPagarButton();
        //ticketPurchaseSteps.TicketPurchaseShouldBeSuccessful("Simulador de autenticación EMV3DS");
        _ticketPurchaseeeeSteps.ClickThEnviarButton();
        _ticketPurchaseeeeSteps.ClickThContinuarButton();
        _ticketPurchaseeeeSteps.DownloadTheTickets();
    }
}