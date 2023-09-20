using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class ReservationSteps
{
    private readonly ReservationPage reservationPage;
    private TicketPurchasePageeee _ticketPurchasePageeee;
    private IWebDriver driver;

    public ReservationSteps(IWebDriver driver)
    {
        this.driver = driver;
        reservationPage = new ReservationPage(driver);
    }

    [When(@"selects ""Reserva online"" as the payment method")]
    public void SelectReservation()
    {
        reservationPage.ClickReservationButton();
    }

    [Then(@"a reservation email should be send successfully")]
    public void ReservationShouldBeSuccessful(string expectedMessage)
    {
        var messageElement = reservationPage.MessageElement;
        var actualMessage = messageElement.Text;

        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }

    [Then(@"a reservation email should not be send")]
    public void ReservationShouldNotBeSuccessful()
    {
        _ticketPurchasePageeee.TicketPurchaseUnsuccessful();
    }
}