using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class AdvancedSelectorPage : BasePage
{
    private readonly Random random;
    
    private readonly By sessionMessageElement = By.XPath("//span[text()=' Selecciona la sesión ']");
    private readonly By chosenDateElement = By.XPath("//label[text()='Fecha elegida']");
    private readonly By comprarButtonElement = By.CssSelector(
        "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    private readonly By radioButtonElement = By.XPath("//input[@type='radio']");
    private readonly By sessionDropdownElement = By.XPath("//select[@class='form-select form-select-sm' and not(@disabled)]");
    private string expectedSessionMessage = "Selecciona la sesión";
    private string expectedChosenDateMessage = "Fecha elegida";
    
    public AdvancedSelectorPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
    }
    
    public bool VerifyAdvancedSelectorMessage()
    {
        Thread.Sleep(2000);
        IWebElement sessionMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        IWebElement choseDateMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(chosenDateElement));
        string message = sessionMessage.Text;
        string dateMessage = choseDateMessage.Text;
        Assert.That(dateMessage == expectedChosenDateMessage && message == expectedSessionMessage, "The messages do not match the expected messages");
        return true;
    }

    public void SelectTitle()
    {
        try
        {
            Thread.Sleep(2000);
            IList<IWebElement> radioButtons = fluentWait.Until(webDriver => webDriver.FindElements(radioButtonElement));

            if (radioButtons.Count > 0)
            {
                var randomRadioIndex = random.Next(0, radioButtons.Count);
                var randomRadio = radioButtons[randomRadioIndex];
                randomRadio.SendKeys(Keys.Space);
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public void SelectSessionHour()
    {
        try
        {
            Thread.Sleep(2000);
            IWebElement dropdown = fluentWait.Until(ExpectedConditions.ElementToBeClickable(sessionDropdownElement));

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
    }
}