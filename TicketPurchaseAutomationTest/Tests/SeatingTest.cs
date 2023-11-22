using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class SeatingTest : BaseTest
{
    [Test]
    public void SeatingPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Seating Purchase Ticket Test");

            LogStep(Status.Info, "Navigating to Seating URL");
            currentStep = "Step NavigateToAdvancedDateSelectorUrl";
            homePage.NavigateToAdvancedDateSelectorUrl();

            seatingPage.ClickOnCalendarDay();
            seatingPage.ClickOnComprarBtn();
            seatingPage.SelectRandomAvailableSector();
            seatingPage.SelectRandomAvailableSeat();
            seatingPage.SwitchToDefaultContent();
            seatingPage.ClickOnComprarButton();
            reservationPage.CompletePersonalInformation("Adolfo", "Test", "33511838a", "laparra@experticket.com", "laparra@experticket.com", "123456789");
            reservationPage.CheckConditions();
            reservationPage.CheckPrivacy();
            reservationPage.ClickOnComprarButtonAgain();
            cardPage.CompleteCardInformation("4548810000000003", "12", "49", "123");
            cardPage.ClickOnPagarButton();
            cardPage.ClickOnEnviarButton();
            cardPage.ClickOnContinuarButton();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
}