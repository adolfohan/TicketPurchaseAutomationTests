using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class TicketsSelectionPage : BasePage
{
    private readonly HomePage homePage;
    private readonly Random random;
    
    public TicketsSelectionPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
        homePage = new HomePage(driver);
    }
    
    private By inputNumberOfTicketsElement =>
        By.XPath("//input[@type='number']");
    
    private readonly By confirmationButtonElement =
        By.XPath("//button[@class='btn sv-button--type-contained sv-button--color-secondary']");
    
    private readonly By comprarButton =
        By.CssSelector(
            "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");

    private readonly By priceElement = By.ClassName("sv-cart__price");
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");
    private readonly By step2Element = By.XPath("//span[text()='Configura tus actividades']");
    
    public void SelectNumberOfTickets(string numberOfTickets)
    {
        
        try
        {
            while (true)
            {
                IList<IWebElement> inputFields =
                    fluentWait.Until(webDriver => webDriver.FindElements(inputNumberOfTicketsElement));

                /*if (inputFields.Count > 0)

                    fluentWait.Until(webDriver =>
                        ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));*/

                if (inputFields.Count > 0)
                {
                    var randomIndex = random.Next(0, inputFields.Count);
                    var selectedInputField = inputFields[randomIndex];

                    while (!selectedInputField.Displayed)
                    {
                        randomIndex = random.Next(0, inputFields.Count);
                        selectedInputField = inputFields[randomIndex];
                    }

                    ScrollIntoView(selectedInputField);
                    ClearAndSetInputValue(selectedInputField, numberOfTickets);
                    break;
                }

                driver.Navigate().Back();
                homePage.ClickOnRandomMeInteresaButton();
                SelectNumberOfTickets(numberOfTickets);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public void ConfirmDate()
    {
        IWebElement confirmationBox = fluentWait.Until(ExpectedConditions.ElementIsVisible(confirmationButtonElement));

        IWebElement confirmButton = confirmationBox.FindElement(confirmationButtonElement);
        confirmButton.Click();
    }
    
    public ReservationPage ClickOnComprarButton()
    {
        try
        {
            IWebElement comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
            comprarBtn.Click();
            if (!haveSession() || !error500())
            {
                Console.WriteLine("No session or error 500 occurred. Continue with the next step...");
            }
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

    private bool error500()
    {
        IWebElement comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
        IWebElement error500Message = fluentWait.Until(ExpectedConditions.ElementIsVisible(error500Element));

        if (!error500Message.Displayed) return false;
        driver.Navigate().Back();
        comprarBtn.Click();
        return true;
    }
    private bool haveSession()
    {
        IWebElement step2Title = fluentWait.Until(ExpectedConditions.ElementIsVisible(step2Element));
        IWebElement comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
        
        if (step2Title.Displayed)
        {
            comprarBtn.Click();
            return true;
        }
        return false;
    }
}