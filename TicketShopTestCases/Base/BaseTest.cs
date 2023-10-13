using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Base;

public class BaseTest
{
    private IWebDriver driver;
    protected HomePageSteps homePageSteps;
    protected TicketsSelectionSteps ticketsSelectionSteps;
    protected ReservationSteps reservationSteps;
    protected CardSteps cardSteps;
    protected PurchaseOkSteps purchaseOkSteps;
    protected string currentStep;
    private ExtentReports extent;
    private ExtentTest test;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        homePageSteps = new HomePageSteps(driver);
        ticketsSelectionSteps = new TicketsSelectionSteps(driver);
        reservationSteps = new ReservationSteps(driver);
        cardSteps = new CardSteps(driver);
        purchaseOkSteps = new PurchaseOkSteps(driver);
        //extent = ExtentManager.GetExtent();
        //test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        string testName = TestContext.CurrentContext.Test.Name;
        
        extent = ExtentManager.GetExtent(testName);
        test = extent.CreateTest(testName);
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
                test.Log(Status.Fail, MarkupHelper.CreateLabel("Test Case Failed", ExtentColor.Red));
                test.Log(Status.Fail, "Failure Message: " + errorMessage);
                test.Log(Status.Fail, "Stack Trace: " + stackTrace);
                AttachScreenshotOnFailure();
                break;
            case TestStatus.Passed:
                test.Log(Status.Pass, MarkupHelper.CreateLabel("Test Case Passed", ExtentColor.Green));
                break;
            case TestStatus.Skipped:
                test.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Skipped", ExtentColor.Orange));
                break;
            case TestStatus.Inconclusive:
                test.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Inconclusive", ExtentColor.Blue));
                break;
            case TestStatus.Warning:
                test.Log(Status.Skip, MarkupHelper.CreateLabel("Test Case Warning", ExtentColor.Purple));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        driver.Quit();
        extent.Flush();
    }

    private void AttachScreenshotOnFailure()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
        var screenshotPath = CaptureScreenshot();
        if (screenshotPath != null)
        {
            test.AddScreenCaptureFromPath(screenshotPath);
        }
    }

    private string? CaptureScreenshot()
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var screenshotName = "screenshot_" + timestamp + ".png";
            var screenshotPath = Path.Combine(@"C:\Projects\Repositories\Git\TestCases\TicketShopTestCases\Screenshots",
                screenshotName);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            CleanUpOldScreenshots();

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
        }
    }

    private void CleanUpOldScreenshots()
    {
        var screenshotDirectory = "C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Screenshots";
        var screenshotFiles = Directory.GetFiles(screenshotDirectory, "screenshot_*.png");

        var maxScreenshotsToKeep = 10;

        if (screenshotFiles.Length <= maxScreenshotsToKeep) return;
        Array.Sort(screenshotFiles);
        for (var i = 0; i < screenshotFiles.Length - maxScreenshotsToKeep; i++)
        {
            File.Delete(screenshotFiles[i]);
        }
    }
    
    protected void LogStep(Status status, string message)
    {
        test.Log(status, message);
    }
    
    protected void HandleTestFailure(Exception ex)
    {
        LogStep(Status.Fail, $"Test failed at step: '{currentStep}' due to an error: {ex.Message}");
    }
}
