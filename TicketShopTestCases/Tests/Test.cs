using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestCases.Pages;
using TestCases.Steps;
using Serilog;

namespace TestCases.Tests;

[TestFixture]
public class Test
{
    private IWebDriver driver;
    private TestSteps testSteps;
    private TicketsSelectionPage ticketsSelectionPage;
    private HomePage homePage;
    private string currentStep;
    
    [SetUp]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Logs\\logfile.log",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();
        driver = new ChromeDriver();
        homePage = new HomePage(driver);
        ticketsSelectionPage = new TicketsSelectionPage(driver);
        testSteps = new TestSteps(driver);
        
    }

    [Test]
    public void TestTest()
    {
        try
        {
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            Log.Information("Navigated to the URL.");

            currentStep = "Step SelectMeInteresaButton";
            testSteps.SelectMeInteresaButton();
            Log.Information("Clicked on 'Me Interesa' button.");

            currentStep = "Step SelectDesiredTicket";
            testSteps.SelectDesiredTicket();
            Log.Information("Selected the desired ticket.");

            currentStep = "Step ConfirmDate";
            ticketsSelectionPage.ConfirmDate();
            Log.Information("Confirmed the date.");

            currentStep = "Step ClickComprarButton";
            testSteps.ClickComprarButton();
            Thread.Sleep(5000);
            Log.Information("Clicked on 'Comprar' button.");
            
            currentStep = "Step CompletePersonalInformation";
            testSteps.CompletePersonalInformation();
            Log.Information("Completed 'Complete Personal Information' step.");

            currentStep = "Step CheckTheConditionsCheckbox";
            testSteps.CheckTheConditionsCheckbox();
            Log.Information("Completed 'Check Conditions Checkbox' step.");

            currentStep = "Step CheckThePrivacyCheckbox";
            testSteps.CheckThePrivacyCheckbox();
            Log.Information("Completed 'Check Privacy Checkbox' step.");

            currentStep = "Step ClicksComprarButtonAgain";
            testSteps.ClicksComprarButtonAgain();
            Log.Information("Clicked 'Comprar' button again.");

            currentStep = "Step CompleteTheCardInformation";
            testSteps.CompleteTheCardInformation();
            Log.Information("Completed 'Complete Card Information' step.");

            currentStep = "Step ClickPagarButton";
            testSteps.ClickPagarButton();
            Log.Information("Clicked 'Pagar' button.");

            currentStep = "Step ClickThEnviarButton";
            testSteps.ClickThEnviarButton();
            Log.Information("Clicked 'Enviar' button.");

            currentStep = "Step ClickThContinuarButton";
            testSteps.ClickThContinuarButton();
            Log.Information("Clicked 'Continuar' button.");
            Log.Information("TestTicketPurchase completed successfully.\n------------------------------------------------------------------");
        }
        catch (Exception ex)
        {
            Log.Error($"The test failed at step: '{currentStep}' due to an error: {ex.Message}");
            
            throw;
        }
    }
    


    //[TearDown]
    //public void TearDown() => driver.Quit();
}