using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TicketPurchaseAutomationTest.Pages;
using TicketPurchaseAutomationTest.Steps;
using TicketPurchaseAutomationTest.Utilities;

namespace TicketPurchaseAutomationTest.Base;

public class BaseTest
{  
    private IWebDriver driver;
    protected HomePage HomePage;
    protected HomePageSteps HomePageSteps;
    protected TicketsSelectionPage TicketsSelectionPage;
    protected TicketsSelectionSteps TicketsSelectionSteps;
    private SessionPage sessionPage;
    private AdvancedDateSelectorPage advancedDateSelectorPage;
    protected SeatingPage SeatingPage;
    protected ReservationPage ReservationPage;
    protected ReservationSteps ReservationSteps;
    protected CardPage CardPage;
    protected CardSteps CardSteps;
    private PurchaseOkSteps purchaseOkSteps;
    protected string? CurrentStep;
    private ExtentReports? extent;
    private ExtentTest? test;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        HomePage = new HomePage(driver);
        HomePageSteps = new HomePageSteps(driver);
        TicketsSelectionPage = new TicketsSelectionPage(driver);
        TicketsSelectionSteps = new TicketsSelectionSteps(driver);
        sessionPage = new SessionPage(driver);
        advancedDateSelectorPage = new AdvancedDateSelectorPage(driver);
        SeatingPage = new SeatingPage(driver);
        ReservationPage = new ReservationPage(driver);
        ReservationSteps = new ReservationSteps(driver);
        CardPage = new CardPage(driver);
        CardSteps = new CardSteps(driver);
        purchaseOkSteps = new PurchaseOkSteps(driver);
        var testName = TestContext.CurrentContext.Test.Name;
        
        extent = ExtentManager.GetExtent(testName);
        if (extent != null) test = extent.CreateTest(testName);
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
        var errorMessage = TestContext.CurrentContext.Result.Message;

        switch (status)
        {
            case TestStatus.Failed:
                test?.Log(Status.Fail, MarkupHelper.CreateLabel("Test Case Failed", ExtentColor.Red));
                test?.Log(Status.Fail, "Failure Message: " + errorMessage);
                test?.Log(Status.Fail, "Stack Trace: " + stackTrace);
                AttachScreenshotOnFailure();
                break;
            case TestStatus.Passed:
                test?.Log(Status.Pass, MarkupHelper.CreateLabel("Test Case Passed", ExtentColor.Green));
                break;
            case TestStatus.Skipped:
                test?.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Skipped", ExtentColor.Orange));
                break;
            case TestStatus.Inconclusive:
                test?.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Inconclusive", ExtentColor.Blue));
                break;
            case TestStatus.Warning:
                test?.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Warning", ExtentColor.Purple));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        driver.Quit();
        extent?.Flush();
    }

    private void AttachScreenshotOnFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
        var screenshotPath = CaptureScreenshot();
        if (screenshotPath != null)
        {
            test?.AddScreenCaptureFromPath(screenshotPath);
        }
    }

    private string? CaptureScreenshot()
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            var screenshotName = "screenshot_" + timestamp + ".png";
            //const string screenshotDirectory = @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Screenshots";
            var screenshotDirectory = Path.Combine(Environment.GetEnvironmentVariable("SourceDirectory") ?? @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\", "Screenshots");
            Directory.CreateDirectory(screenshotDirectory);
            var screenshotPath = Path.Combine(screenshotDirectory, screenshotName);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            //CleanUpOldScreenshots();

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
        }
    }
    
    private static void CleanUpOldScreenshots()
    {
        const string screenshotDirectory = @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Screenshots";
        var screenshotFiles = Directory.GetFiles(screenshotDirectory, "screenshot_*.png");

        const int maxScreenshotsToKeep = 10;

        if (screenshotFiles.Length <= maxScreenshotsToKeep) return;
        Array.Sort(screenshotFiles);
        for (var i = 0; i < screenshotFiles.Length - maxScreenshotsToKeep; i++)
        {
            File.Delete(screenshotFiles[i]);
        }
    }
    
    protected void LogStep(Status status, string message)
    {
        test?.Log(status, message);
    }
    
    protected void HandleTestFailure(Exception ex)
    {
        LogStep(Status.Fail, $"Test failed at step: '{CurrentStep}' due to an error: {ex.Message}");
    }

    protected void CommonNormalPurchaseSteps()
    {
            /*LogStep(Status.Info, "Clicked Me Interesa button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePage.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected desired ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed personal information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed card information");
            CurrentStep = "Step CompleteTheCardInformation";
            CardSteps.CompleteTheCardInformation();

            LogStep(Status.Info, "Clicked on Pagar button");
            CurrentStep = "Step ClickPagarButton";
            CardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Clicked on Enviar button");
            CurrentStep = "Step ClickOnEnviarButton";
            CardSteps.ClickOnEnviarButton();

            LogStep(Status.Info, "Clicked on Continuar button");
            CurrentStep = "Step ClickOnContinuarButton";
            CardSteps.ClickOnContinuarButton();

            LogStep(Status.Info, "Purchase completed");
            CurrentStep = "PurchaseOKMessage";
            purchaseOkSteps.PurchaseOkMessage();

            LogStep(Status.Info, "Ticket Purchase Successful");
    }
    
    protected void CommonSessionPurchaseSteps()
    {
            LogStep(Status.Info, "Selected desired ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();
            
            LogStep(Status.Info, "Session Message Displayed");
            CurrentStep = "Step SessionMessageDisplayed";
            sessionPage.SessionMessageDisplayed();
            
            LogStep(Status.Info, "Selected Session Option");
            CurrentStep = "Step SelectSession";
            sessionPage.SelectSession();
            
            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            sessionPage.ClickOnComprarButton();

            LogStep(Status.Info, "Completed personal information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed card information");
            CurrentStep = "Step CompleteTheCardInformation";
            CardSteps.CompleteTheCardInformation();

            LogStep(Status.Info, "Clicked on Pagar button");
            CurrentStep = "Step ClickPagarButton";
            CardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Clicked on Enviar button");
            CurrentStep = "Step ClickOnEnviarButton";
            CardSteps.ClickOnEnviarButton();

            LogStep(Status.Info, "Clicked on Continuar button");
            CurrentStep = "Step ClickOnContinuarButton";
            CardSteps.ClickOnContinuarButton();

            LogStep(Status.Info, "Purchase completed");
            CurrentStep = "PurchaseOKMessage";
            purchaseOkSteps.PurchaseOkMessage();

            LogStep(Status.Info, "Ticket Purchase Successful");
    }
    
    protected void CommonAdvancedDateSelectorPurchaseSteps()
    {
            LogStep(Status.Info, "Selected desired ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();
            
            LogStep(Status.Info, "Advanced Date Selector Message Displayed");
            CurrentStep = "Step VerifyAdvancedSelectorMessage";
            advancedDateSelectorPage.VerifyAdvancedSelectorMessage();
            
            LogStep(Status.Info, "Selected Title Option");
            CurrentStep = "Step SelectTitle";
            advancedDateSelectorPage.SelectTitle();
            
            LogStep(Status.Info, "Selected Session Option");
            CurrentStep = "Step SelectSessionHour";
            advancedDateSelectorPage.SelectSessionHour();
            
            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            advancedDateSelectorPage.ClickOnComprarButton();

            LogStep(Status.Info, "Completed personal information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed card information");
            CurrentStep = "Step CompleteTheCardInformation";
            CardSteps.CompleteTheCardInformation();

            LogStep(Status.Info, "Clicked on Pagar button");
            CurrentStep = "Step ClickPagarButton";
            CardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Clicked on Enviar button");
            CurrentStep = "Step ClickOnEnviarButton";
            CardSteps.ClickOnEnviarButton();

            LogStep(Status.Info, "Clicked on Continuar button");
            CurrentStep = "Step ClickOnContinuarButton";
            CardSteps.ClickOnContinuarButton();

            LogStep(Status.Info, "Purchase completed");
            CurrentStep = "PurchaseOKMessage";
            purchaseOkSteps.PurchaseOkMessage();

            LogStep(Status.Info, "Ticket Purchase Successful");
    }
}

