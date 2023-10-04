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
    [Test, Order(1)]
    public void TicketPurchaseTest()
    {
        try
        {
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();
            Log.Information("Navigated to the URL.");
            
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();
            Log.Information("Clicked on 'Me Interesa' button.");
            
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();
            Log.Information("Selected the desired ticket.");
            
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();
            Log.Information("Confirmed the date.");
            
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();
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
            reservationSteps.ClicksOnComprarButtonAgain();
            Log.Information("Clicked 'Comprar' button again.");
            
            currentStep = "Step CompleteTheCardInformation";
            cardSteps.CompleteTheCardInformation();
            Log.Information("Completed 'Complete Card Information' step.");
            
            currentStep = "Step ClickPagarButton";
            cardSteps.ClickOnPagarButton();
            Log.Information("Clicked 'Pagar' button.");
            
            currentStep = "Step ClickOnEnviarButton";
            cardSteps.ClickOnEnviarButton();
            Log.Information("Clicked 'Enviar' button.");
            
            currentStep = "Step ClickOnContinuarButton";
            cardSteps.ClickOnContinuarButton();
            Log.Information("Clicked 'Continuar' button.");

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

    [Test, Order(2)]
    public void TicketPurchaseWrongCardTest()
    {
        try
        {
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();
            Log.Information("Navigated to the URL.");
            
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();
            Log.Information("Clicked on 'Me Interesa' button.");
            
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();
            Log.Information("Selected the desired ticket.");
            
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();
            Log.Information("Confirmed the date.");
            
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();
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
            reservationSteps.ClicksOnComprarButtonAgain();
            Log.Information("Clicked 'Comprar' button again.");
            
            currentStep = "Step CompleteTheCardWithWrongInformation";
            cardSteps.CompleteTheCardWithWrongInformation();
            Log.Information("Completed 'Complete Card With Wrong Information' step.");
            
            currentStep = "Step ClickPagarButton";
            cardSteps.ClickOnPagarButton();
            Log.Information("Clicked 'Pagar' button.");
            
            currentStep = "Step ThenTheTicketPurchaseShouldBeUnsuccessful";
            cardSteps.ThenTheTicketPurchaseShouldBeUnsuccessful();
            Log.Information("Displayed 'Debe Introducir un número de tarjeta válido (sin espacios ni guiones).' message");
            Log.Information("Ticket Purchase is unsuccessful.\n------------------------------------------------------------------");
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
    
}
