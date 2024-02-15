using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class Error500Page : BasePage
{
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");

    public Error500Page(IWebDriver driver) : base(driver) {}

    public bool Error500Displayed()
    {
        try
        {
            IWebElement error500Message = FluentWait.Until(ExpectedConditions.ElementIsVisible(error500Element));
            Console.WriteLine($"Error 500 was displayed: {error500Message.Displayed}");
            return error500Message.Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}