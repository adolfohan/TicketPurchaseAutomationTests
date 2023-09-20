using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCases.Pages;

public class CancellationPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CancellationPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
    }


    public IWebElement MessageElement
    {
        get
        {
            try
            {
                return wait.Until(
                    ExpectedConditions.ElementIsVisible(
                        By.XPath("//*[@id=\"purchase-ended-father-node\"]/div[1]/div/h1")));
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for the element to be visible: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while waiting for the element: {ex.Message}");
                return null;
            }
        }
    }

    public void ClickCancelarButton()
    {
        try
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var cancellationButton =
                wait.Until(ExpectedConditions.ElementIsVisible(
                    By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[1]")));
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", cancellationButton);

            //cancellationButton.Click();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking Cancelar button: {ex.Message}");
        }
    }

    public void ClickContinuarButton()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var continueButton =
                wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("/html/body/div/form/div[2]/div[3]/div[2]/div[1]/input[2]")));

            continueButton.Click();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking Continuar button: {ex.Message}");
        }
    }
}