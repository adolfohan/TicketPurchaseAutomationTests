using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class PurchaseOkPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By purchaseOkMessageElement = By.CssSelector("h1.mt-2");
    private const string ExpectedMessage = "Gracias por tu compra";

    public void PurchaseOkVerificationMessage()
    {
        try
        {
            IWebElement purchaseOkMessage = FluentWait.Until(ExpectedConditions.ElementIsVisible(purchaseOkMessageElement));
            string message = purchaseOkMessage.Text;
            Assert.That(message, Is.EqualTo(ExpectedMessage), "The message does not match the expected message");
        }
        catch (NoSuchElementException ex)
        {
            Assert.Fail("Element not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail("An error occurred: " + ex.Message);
        }
    }
}