using NUnit.Framework;
using OpenQA.Selenium;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Tests;

[TestFixture]
public class CancellationTest
{
    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.CreateWebDriver();
        _ticketPurchaseeeeSteps = new TicketPurchaseeeeSteps(driver);
        cancellationSteps = new CancellationSteps(driver);
    }

    private IWebDriver driver;
    private TicketPurchaseeeeSteps _ticketPurchaseeeeSteps;
    private CancellationSteps cancellationSteps;

    [Test]
    public void TestCancellation()
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
        cancellationSteps.ClickCancelarButton();
        cancellationSteps.ClickContinuarButton();
        cancellationSteps.CancellationSuccessful("Venta cancelada");
    }

    //[TearDown]
    //public void TearDown() => driver.Quit();
}