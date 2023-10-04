using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;

namespace TestCases.Pages;

public class ReservationPage : BasePage
{
    private readonly Random random;
    private readonly By nameElement = By.Id("clientFullName-id");
    private readonly By surNameElement = By.Id("clientSurname-id");
    private readonly By idElement = By.Id("clientDocumentIdentifier-id");
    private readonly By emailElement = By.Id("clientEmail-id");
    private readonly By phoneElement = By.Id("clientPhoneNumber-id");
    private readonly By conditionsCheckboxElement = By.Id("form-conditions");
    private readonly By privacyCheckboxElement = By.Id("form-privacy");
    private readonly By comprarButtonElement = By.CssSelector(
            "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    public ReservationPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
    }
    
    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string phone)
    {
        try
        {
            IWebElement fullNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
            ClearAndSetInputValue(fullNameField, fullName);

            IWebElement surNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
            ClearAndSetInputValue(surNameField, surName);

            IWebElement idField = fluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));
            ClearAndSetInputValue(idField, id);

            IWebElement emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
            ClearAndSetInputValue(emailField, email);

            IWebElement phoneField = fluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
            ClearAndSetInputValue(phoneField, phone);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while entering data: {ex.Message}");
        }
    }
    
    public void CheckConditions()
    {
        try
        {
            IWebElement conditionsCheckbox =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(conditionsCheckboxElement));

            ScrollIntoView(conditionsCheckbox);
            
            //conditionsCheckbox.Click();
            conditionsCheckbox.SendKeys(Keys.Space);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking Conditions checkbox: {ex.Message}");
        }
    }
    
    public void CheckPrivacy()
    {
        try
        {
            IWebElement privacyCheckbox =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(privacyCheckboxElement));

            ScrollIntoView(privacyCheckbox);
            //privacyCheckbox.Click();
            privacyCheckbox.SendKeys(Keys.Space);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking Privacy checkbox: {ex.Message}");
        }
    }

    public CardPage ClickOnComprarButtonAgain()
    {
        try
        {
            IList<IWebElement> comprarButtons = fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(comprarButtonElement));
            
            if (comprarButtons.Count > 0)
            {
                var randomIndex = random.Next(0, comprarButtons.Count);
                var selectedComprarButton = comprarButtons[randomIndex];
                //IWebElement firstComprarButton = comprarButtons[0];
                ScrollIntoView(selectedComprarButton);
                Thread.Sleep(3000);
                selectedComprarButton.Click();
            }
            else
            {
                Console.WriteLine("No 'Comprar' buttons found.");
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking 'Comprar' button again: {ex.Message}");
        }

        return new CardPage(driver);
    }
}