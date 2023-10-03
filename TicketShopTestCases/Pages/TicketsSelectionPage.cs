using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;
using TestCases.Utilities;

namespace TestCases.Pages;

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
    
    public void SelectNumberOfTickets(string numberOfTickets)
    {
        try
        {
            IList<IWebElement> inputFields = fluentWait.Until(webDriver => webDriver.FindElements(inputNumberOfTicketsElement));

            fluentWait.Until(webDriver =>
                ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));

            if (inputFields.Count > 0)
            {
                var randomIndex = random.Next(0, inputFields.Count);

                var selectedInputField = inputFields[randomIndex];
                //IWebElement firstInput = inputFields[0];
                ScrollIntoView(selectedInputField);
                ClearAndSetInputValue(selectedInputField, numberOfTickets);
            }
            else
            {
                driver.Navigate().Back();
                homePage.ClickRandomMeInteresaButton();
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
    
    public ReservationPage ClickComprarButton()
    {
        try
        {
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton)).Click();
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