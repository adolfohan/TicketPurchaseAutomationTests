using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using TestCases.Steps;
using TestCases.Utilities;


namespace TestCases.Tests;

[TestFixture]
public class TicketPurchaseTest
{
    [SetUp]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\logfile.log",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();
        driver = WebDriverFactory.CreateWebDriver();
        ticketPurchaseSteps = new TicketPurchaseSteps(driver);
        captureScreenShot = new WebDriverFactory();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
    
    private IWebDriver driver;
    private TicketPurchaseSteps ticketPurchaseSteps;
    private string currentStep;
    private WebDriverFactory captureScreenShot;

    [Test]
    public void TestTicketPurchase()
    {
        try
        {
            currentStep = "Step GoToURL";
            ticketPurchaseSteps.GoToURL();
            Log.Information("Navigated to the URL.");

            currentStep = "Step SelectMeInteresaButton";
            ticketPurchaseSteps.SelectMeInteresaButton();
            Log.Information("Clicked on 'Me Interesa' button.");

            currentStep = "Step SelectDesiredTicket";
            ticketPurchaseSteps.SelectDesiredTicket();
            Log.Information("Selected the desired ticket.");

            currentStep = "Step ConfirmDate";
            ticketPurchaseSteps.ConfirmDate();
            Log.Information("Confirmed the date.");

            currentStep = "Step ClickComprarButton";
            ticketPurchaseSteps.ClickComprarButton();
            Log.Information("Clicked on 'Comprar' button.");

            currentStep = "Step HaveSessions";
            ticketPurchaseSteps.HaveSessions();
            Log.Information("Completed 'Have Sessions' step.");

            currentStep = "Step CompletePersonalInformation";
            ticketPurchaseSteps.CompletePersonalInformation();
            Log.Information("Completed 'Complete Personal Information' step.");

            currentStep = "Step CheckTheConditionsCheckbox";
            ticketPurchaseSteps.CheckTheConditionsCheckbox();
            Log.Information("Completed 'Check Conditions Checkbox' step.");

            currentStep = "Step CheckThePrivacyCheckbox";
            ticketPurchaseSteps.CheckThePrivacyCheckbox();
            Log.Information("Completed 'Check Privacy Checkbox' step.");

            currentStep = "Step ClicksComprarButtonAgain";
            ticketPurchaseSteps.ClicksComprarButtonAgain();
            Log.Information("Clicked 'Comprar' button again.");

            currentStep = "Step CompleteTheCardInformation";
            ticketPurchaseSteps.CompleteTheCardInformation();
            Log.Information("Completed 'Complete Card Information' step.");

            currentStep = "Step ClickPagarButton";
            ticketPurchaseSteps.ClickPagarButton();
            Log.Information("Clicked 'Pagar' button.");

            currentStep = "Step ClickThEnviarButton";
            ticketPurchaseSteps.ClickThEnviarButton();
            Log.Information("Clicked 'Enviar' button.");

            currentStep = "Step ClickThContinuarButton";
            ticketPurchaseSteps.ClickThContinuarButton();
            Log.Information("Clicked 'Continuar' button.");
            Log.Information("TestTicketPurchase completed successfully.\n---------------------------------");
        }
        catch (Exception ex)
        {
            Log.Error($"The test failed at step: '{currentStep}' due to an error: {ex.Message}");

            var screenshotName = $"{currentStep} + Error";
            var screenshotPath = WebDriverFactory.CaptureScreenshot(driver,
                "C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Screenshots");
            throw;
        }
    }
}