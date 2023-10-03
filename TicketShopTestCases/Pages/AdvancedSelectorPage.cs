using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;

namespace TestCases.Pages;

public class AdvancedSelectorPage : BasePage
{
    private readonly Random random;
    
    private readonly By sessionMessageElement = By.XPath("//span[text()='Selecciona la sesión]");
    private readonly By chosenDateElement = By.XPath("//label[text()='Fecha elegida']");
    private readonly By comprarButtonElement = By.CssSelector(
        "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    private readonly By radioButtonElement = By.XPath("//input[@type='radio']");
    private readonly By SessionDropdownElement = By.CssSelector("select.form-select:not([disabled])");
    private string expectedSessionMessage = "Selecciona la sesión";
    private string expectedChosenDateMessage = "Fecha elegida";
    
    public AdvancedSelectorPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
    }
    
    public void verifyAdvancedSelectorMessage()
    {
        IWebElement sessionMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        IWebElement choseDateMessage = fluentWait.Until(ExpectedConditions.ElementIsVisible(chosenDateElement));
        string message = sessionMessage.Text;
        string dateMessage = choseDateMessage.Text;
        Assert.That(dateMessage == expectedChosenDateMessage && message == expectedSessionMessage, "The messages do not match the expected messages");
    }

    public void SelectTitle()
    {
        try
        {
            IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='radio']"));
            IList<IWebElement> radioButtons = fluentWait.Until(webDriver => webDriver.FindElements(radioButtonElement));

            if (radioButtons.Count > 0)
            {
                var randomRadioIndex = random.Next(0, checkboxes.Count);
                var randomRadio = checkboxes[randomRadioIndex];
                randomRadio.Click();
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