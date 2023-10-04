using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using TestCases.Pages;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Base;

public class BaseTest
{
    protected IWebDriver driver;
    protected HomePageSteps homePageSteps;
    protected TicketsSelectionSteps ticketsSelectionSteps;
    protected ReservationSteps reservationSteps;
    protected CardSteps cardSteps;
    protected PurchaseOkSteps purchaseOkSteps;
    
    [SetUp]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Logs\\logfile.log",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();
        driver = new ChromeDriver();
        homePageSteps = new HomePageSteps(driver);
        ticketsSelectionSteps = new TicketsSelectionSteps(driver);
        reservationSteps = new ReservationSteps(driver);
        cardSteps = new CardSteps(driver);
        purchaseOkSteps = new PurchaseOkSteps(driver);
    }
    
    protected static string? CaptureScreenshot(IWebDriver driver, string screenshotDirectory)
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var screenshotName = "screenshot_" + timestamp + ".png";
            var screenshotPath = Path.Combine(screenshotDirectory, screenshotName);

            var directoryPath = Path.GetDirectoryName(screenshotPath);
            if (!Directory.Exists(directoryPath))
                if (directoryPath != null)
                    Directory.CreateDirectory(directoryPath);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
        }
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
