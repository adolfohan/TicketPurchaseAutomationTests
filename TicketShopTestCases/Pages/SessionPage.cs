using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;

namespace TestCases.Pages;

public class SessionPage : BasePage
{
    private readonly Random random;
    
    private readonly By sessionMessageElement = By.XPath("//span[text()='Selecciona la sesión]");
    private readonly By comprarButtonElement = By.CssSelector(
        "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    private readonly By SessionDropdownElement = By.TagName("select");
    private string expectedMessage = "Selecciona la sesión";
    
    public SessionPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
    }

    public void verifySessionMessage()
    {
        IWebElement sessionMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        string message = sessionMessage.Text;
        Assert.That(message, Is.EqualTo(expectedMessage), "The message does not match the expected message");
    }
    
    public void SelectSession()
    {
        try
        {
            IWebElement dropdown = fluentWait.Until(ExpectedConditions.ElementToBeClickable(SessionDropdownElement));

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
    
    public ReservationPage ClickComprarButton()
    {
        try
        {
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButtonElement)).Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking 'Comprar' button: {ex.Message}");
        }

        return new ReservationPage(driver);
    }
    
    
}