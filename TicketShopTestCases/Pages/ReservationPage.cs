using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
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
    private readonly By datosDeLaOperacionElement = By.XPath("//h1[@class='datosDeLaOperacion']");
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
            
            Assert.That(conditionsCheckbox, Is.Not.Null, "The Condition Checkbox not found");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred while checking Conditions checkbox: {ex.Message}");
            Assert.Fail($"An error occurred while checking Conditions checkbox: {ex.Message}");
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

                ScrollIntoView(selectedComprarButton);
                Thread.Sleep(3000);
                selectedComprarButton.Click();
                Thread.Sleep(3000);
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
    
    public void BlankFields()
    {
        IWebElement nameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
        IWebElement surNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
        IWebElement idField = fluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));
        IWebElement emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        IWebElement phoneField = fluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
        CheckValidity(nameField); 
        CheckValidity(surNameField); 
        CheckValidity(idField); 
        CheckValidity(emailField);        
        CheckValidity(phoneField);
    }

    public void InvalidNameAndSurname()
    {
        IWebElement nameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
        IWebElement surNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
        
        try
        {
            CheckValidity(nameField);        
            CheckValidity(surNameField);

            Assert.Fail("The input text should be invalid, but it is valid.");
        }
        catch (Exception ex)
        {
            Assert.Pass("The input text is invalid as expected.");
        }
    }

    public void InvalidId()
    {
        IWebElement phoneField = fluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));
        try
        {
            CheckValidity(phoneField);

            Assert.Fail("The input text should be invalid, but it is valid.");
        }
        catch (Exception ex)
        {
            Assert.Pass("The input text is invalid as expected.");
        }
    }
    
    public void InvalidEmail()
    {
        IWebElement emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        try
        {
            CheckValidity(emailField);

            Assert.Fail("The input text should be invalid, but it is valid.");
        }
        catch (Exception)
        {
            Assert.Pass("The input text is invalid as expected.");
        }
    }
    
    public void InvalidPhone()
    {
        IWebElement phoneField = fluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
        try
        {
            CheckValidity(phoneField);

            Assert.Fail("The input text should be invalid, but it is valid.");
        }
        catch (Exception)
        {
            Assert.Pass("The input text is invalid as expected.");
        }
    }

    public void AreCheckboxesSelected()
    {
        IWebElement conditionsCheckbox =
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(conditionsCheckboxElement));
        IWebElement privacyCheckbox =
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(privacyCheckboxElement));
        
        bool isConditionsCheckboxSelected = conditionsCheckbox.Selected;
        bool isPrivacyCheckboxSelected = privacyCheckbox.Selected;
        
        Assert.That(isConditionsCheckboxSelected || isPrivacyCheckboxSelected, Is.False, "The Conditions and Privacy Checkbox is not selected and Card Page is not displayed");
        
    }

    public void IsCardPageDisplayed()
    {
        try
        {
            IWebElement datosElement = driver.FindElement(datosDeLaOperacionElement);

            if (datosElement.Displayed)
            {
                Assert.Fail("The element is displayed, which is unexpected");
            }
            else
            {
                Console.WriteLine("The element is not displayed, as expected");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("The element is not present, as expected");
        }
    }

}