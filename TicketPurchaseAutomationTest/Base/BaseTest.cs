using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TicketPurchaseAutomationTest.Pages;
using TicketPurchaseAutomationTest.Utilities;
using ExtentReports = AventStack.ExtentReports.ExtentReports;

namespace TicketPurchaseAutomationTest.Base;

public class BaseTest
{
    private IWebDriver? driver;
    protected HomePage? HomePage;
    protected TicketsSelectionPage? TicketsSelectionPage;
    protected SessionPage? SessionPage;
    protected AdvancedDateSelectorPage? AdvancedDateSelectorPage;
    protected ReservationPage? ReservationPage;
    protected CardPage? CardPage;
    protected PurchaseOkPage? PurchaseOkPage;
    protected string? CurrentStep;
    private ExtentReports? extent;
    private ExtentTest? test;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();

        if (Environment.GetEnvironmentVariable("TF_BUILD") != null)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        HomePage = new HomePage(driver);
        TicketsSelectionPage = new TicketsSelectionPage(driver);
        SessionPage = new SessionPage(driver);
        AdvancedDateSelectorPage = new AdvancedDateSelectorPage(driver);
        ReservationPage = new ReservationPage(driver);
        CardPage = new CardPage(driver);
        PurchaseOkPage = new PurchaseOkPage(driver);
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

        driver!.Quit();
        driver?.Dispose();
        extent?.Flush();
    }

    private void AttachScreenshotOnFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
        var screenshotPath = CaptureScreenshot();
        if (screenshotPath == null) return;
        var screenshotBytes = File.ReadAllBytes(screenshotPath);
        var screenshotBase64 = Convert.ToBase64String(screenshotBytes);

        test?.AddScreenCaptureFromBase64String(screenshotBase64, "Screenshot on Failure");
    }

    private string? CaptureScreenshot()
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            var screenshotName = "screenshot_" + timestamp + ".png";
            var screenshot = ((ITakesScreenshot)driver!).GetScreenshot();
            var screenshotDirectory = Path.Combine(Environment.GetEnvironmentVariable("SourceDirectory") ??
                                                   @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Screenshots");
            Directory.CreateDirectory(screenshotDirectory);
            var screenshotPath = Path.Combine(screenshotDirectory, screenshotName);
            screenshot.SaveAsFile(screenshotPath);
            var screenshots = Directory.GetFiles(screenshotDirectory, "*.png");
            if (screenshots.Length <= 10) return screenshotPath;
            var oldestScreenshots = screenshots.OrderBy(File.GetCreationTime).Take(screenshots.Length - 10);
            foreach (var oldScreenshot in oldestScreenshots)
            {
                File.Delete(oldScreenshot);
            }

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
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
        
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToNormalUrl();

        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Date confirmed");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Completed personal information");
        CurrentStep = "Step CompletePersonalInformation";
        ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com", "ahan@test.com",
            "123456789");

        LogStep(Status.Info, "Checked conditions checkbox");
        CurrentStep = "Step CheckTheConditionsCheckbox";
        ReservationPage!.CheckConditions();

        LogStep(Status.Info, "Checked privacy checkbox");
        CurrentStep = "Step CheckThePrivacyCheckbox";
        ReservationPage!.CheckPrivacy();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClicksComprarButtonAgain";
        ReservationPage!.ClickOnComprarButtonAgain();

        LogStep(Status.Info, "Completed card information");
        CurrentStep = "Step CompleteTheCardInformation";
        CardPage!.CompleteCardInformation("4548810000000003", "12", "49", "123");

        LogStep(Status.Info, "Clicked on Pagar button");
        CurrentStep = "Step ClickPagarButton";
        CardPage!.ClickOnPagarButton();

        LogStep(Status.Info, "Clicked on Enviar button");
        CurrentStep = "Step ClickOnEnviarButton";
        CardPage!.ClickOnEnviarButton();

        LogStep(Status.Info, "Clicked on Continuar button");
        CurrentStep = "Step ClickOnContinuarButton";
        CardPage!.ClickOnContinuarButton();

        LogStep(Status.Info, "Purchase completed");
        CurrentStep = "PurchaseOKMessage";
        PurchaseOkPage!.PurchaseOkVerificationMessage();

        LogStep(Status.Info, "Ticket Purchase Successful");
    }

    protected void CommonSessionPurchaseSteps()
    {
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToSessionUrl();
        
        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Confirm date");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Session Message Displayed");
        CurrentStep = "Step SessionMessageDisplayed";
        SessionPage!.SessionMessageDisplayed();

        LogStep(Status.Info, "Selected Session Option");
        CurrentStep = "Step SelectSession";
        SessionPage!.SelectSession();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        SessionPage!.ClickOnComprarButton();
    }

    protected void CommonAdvancedDateSelectorPurchaseSteps()
    {
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToAdvancedDateSelectorUrl();
        
        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Date confirmed");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Advanced Date Selector Message Displayed");
        CurrentStep = "Step VerifyAdvancedSelectorMessage";
        AdvancedDateSelectorPage!.VerifyAdvancedSelectorMessage();

        LogStep(Status.Info, "Selected Oceanografic Session Option");
        CurrentStep = "Step SelectOceanograficSessionHour";
        AdvancedDateSelectorPage!.SelectOceanograficSessionHour();

        LogStep(Status.Info, "Selected Title Option");
        CurrentStep = "Step SelectHemisfericTitle";
        AdvancedDateSelectorPage!.SelectHemisfericTitle();

        LogStep(Status.Info, "Selected Session Option");
        CurrentStep = "Step SelectHemisfericSessionHour";
        AdvancedDateSelectorPage!.SelectHemisfericSessionHour();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        AdvancedDateSelectorPage!.ClickOnComprarButton();
    }
}