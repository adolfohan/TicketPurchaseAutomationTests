using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class Error500Page : BasePage
{
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");

    protected Error500Page(IWebDriver driver) : base(driver) {}
    
    public bool Error500Displayed()
    {
        IWebElement error500Message = fluentWait.Until(ExpectedConditions.ElementIsVisible(error500Element));

        if (error500Message.Displayed)
        {
            driver.Navigate().Back();
            return true;
        }
        return false;
    }

}