using NUnit.Framework;
using OpenQA.Selenium;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Tests;

[TestFixture]
public class TicketPurchaseTest
{
    private IWebDriver driver;
    private TicketPurchaseSteps ticketPurchaseSteps;
    
    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.CreateWebDriver();
        ticketPurchaseSteps = new TicketPurchaseSteps(driver);
    }


    [Test]
    public void TestTicketPurchase()
    {
        ticketPurchaseSteps.GoToURL();
        ticketPurchaseSteps.SelectMeInteresaButton();
        ticketPurchaseSteps.SelectDesiredTicket();
        ticketPurchaseSteps.ClickComprarButton();
        ticketPurchaseSteps.CompletePersonalInformation();
        ticketPurchaseSteps.CheckTheConditionsCheckbox();
        ticketPurchaseSteps.CheckThePrivacyCheckbox();
        ticketPurchaseSteps.ClicksComprarButtonAgain();
        ticketPurchaseSteps.CompleteTheCardInformation();
        ticketPurchaseSteps.ClickPagarButton();
        ticketPurchaseSteps.ClickThEnviarButton();
        ticketPurchaseSteps.ClickThContinuarButton();
        ticketPurchaseSteps.DownloadTheTickets();
    }
}