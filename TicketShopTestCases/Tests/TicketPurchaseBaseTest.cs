using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using TestCases.Base;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Tests;

[TestFixture]

public class TicketPurchaseBaseTest : BaseTest
{ 
    private string currentStep;


    [Test, Order(1)]
    public void TicketPurchaseTest()
    {
        try
        {
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();
            Log.Information("Navigated to the URL.");
            
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickRandomMeInteresaButton();
            Log.Information("Clicked on 'Me Interesa' button.");
            
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();
            Log.Information("Selected the desired ticket.");
            
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();
            Log.Information("Confirmed the date.");
            
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickComprarButton();
            Log.Information("Clicked on 'Comprar' button.");
            
            currentStep = "Step CompletePersonalInformation";
            reservationSteps.CompletePersonalInformation();
            Log.Information("Completed 'Complete Personal Information' step.");

            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();
            Log.Information("Completed 'Check Conditions Checkbox' step.");

            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();
            Log.Information("Completed 'Check Privacy Checkbox' step.");

            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksComprarButtonAgain();
            Log.Information("Clicked 'Comprar' button again.");
            
            currentStep = "Step CompleteTheCardInformation";
            cardSteps.CompleteTheCardInformation();
            Log.Information("Completed 'Complete Card Information' step.");
            
            currentStep = "Step ClickPagarButton";
            cardSteps.ClickPagarButton();
            Log.Information("Clicked 'Pagar' button.");

            currentStep = "PurchaseOKMessage";
            purchaseOkSteps.PurchaseOkMessage();
            Log.Information("Displayed 'Gracias por tu compra' message");
            Log.Information("Ticket Purchase completed successfully.\n------------------------------------------------------------------");
        }
        catch (Exception ex)
        {
            Log.Error($"The test failed at step: '{currentStep}' due to an error: {ex.Message}");

            var screenshotName = $"{currentStep} + Error";
            string? screenshotPath = CaptureScreenshot(driver,
                "C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Screenshots");
            throw;
        }
    }

    
    /*
    [Test]
    public void TestTicketPurchase()
    {
        try
        {
            currentStep = "Step HaveSessions";
            ticketPurchaseSteps.HaveSessions();
            Log.Information("Completed 'Have Sessions' step.");

        

            currentStep = "Step ClickThEnviarButton";
            ticketPurchaseSteps.ClickThEnviarButton();
            Log.Information("Clicked 'Enviar' button.");

            currentStep = "Step ClickThContinuarButton";
            ticketPurchaseSteps.ClickThContinuarButton();
            Log.Information("Clicked 'Continuar' button.");
            Log.Information("TestTicketPurchase completed successfully.\n------------------------------------------------------------------");
        }
        catch (Exception ex)
        {
            Log.Error($"The test failed at step: '{currentStep}' due to an error: {ex.Message}");

            var screenshotName = $"{currentStep} + Error";
            string? screenshotPath = TestUtil.CaptureScreenshot(driver,
                "C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Screenshots");
            throw;
        }
        */
}
