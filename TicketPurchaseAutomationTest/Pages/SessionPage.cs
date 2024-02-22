using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class SessionPage(IWebDriver? driver) : BasePage(driver)
{
    private readonly Random random = new();
    
    private readonly By sessionMessageElement = By.XPath("//span[text()=' Selecciona la sesión ']");
    private readonly By comprarButtonElement = By.XPath(
        "//button[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy j-button-buy']");
    private readonly By sessionDropdownElement = By.XPath("//select[@class='form-select form-select-sm']");
    private const string ExpectedMessage = "Selecciona la sesión";

    public bool VerifySessionMessage()
    {
        var sessionMessage = FluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        var message = sessionMessage.Text;
        Assert.That(message, Is.EqualTo(ExpectedMessage), "The message does not match the expected message");

        return true;
    }

    public bool SessionMessageDisplayed()
    {
        var sessionMessage = FluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        return sessionMessage.Displayed;
    }
    
    public void SelectSession()
    {
        try
        {
            var dropdown = FluentWait.Until(ExpectedConditions.ElementIsVisible(sessionDropdownElement));

            var select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            if (options.Count <= 0) return;

            var randomIndex = random.Next(1, options.Count);
            select.SelectByIndex(randomIndex);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
    }
    
    public void ClickOnComprarButton()
    {
        try
        {
            var comprarButton = FluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButtonElement));
            comprarButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking on 'Comprar' button in Session Page: {ex.Message}");
        }
    }
}