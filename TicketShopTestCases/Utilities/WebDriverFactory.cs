using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestCases.Utilities;

public class WebDriverFactory
{
    public static IWebDriver CreateWebDriver()
    {
        return new ChromeDriver();
    }

    public static string CaptureScreenshot(IWebDriver driver, string screenshotDirectory)
    {
        try
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var screenshotName = "screenshot_" + timestamp + ".png";
            var screenshotPath = Path.Combine(screenshotDirectory, screenshotName);

            var directoryPath = Path.GetDirectoryName(screenshotPath);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            return screenshotPath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error capturing screenshot: " + ex.Message);
            return null;
        }
    }
}