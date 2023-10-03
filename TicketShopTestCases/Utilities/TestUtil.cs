using OpenQA.Selenium;
using TestCases.Base;

namespace TestCases.Utilities;

public class TestUtil
{
    private static IWebDriver driver;

    public static void DrawBorder(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("arguments[0].style.border='2px solid red'", element);
    }

    public void clickByJS(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("arguments[0].click();", element);
    }
    
    public static string? CaptureScreenshot(IWebDriver driver, string screenshotDirectory)
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
}