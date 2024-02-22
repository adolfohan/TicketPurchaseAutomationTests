using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public partial class ReservationPage(IWebDriver? driver) : BasePage(driver)
{
    private readonly Random random = new();
    private readonly By nameElement = By.Id("clientFullName-id");
    private readonly By surNameElement = By.Id("clientSurname-id");
    private readonly By idElement = By.Id("clientDocumentIdentifier-id");
    private readonly By emailElement = By.Id("clientEmail-id");
    private readonly By confirmEmailElement = By.Id("confirm-clientEmail-id");
    private readonly By phoneElement = By.Id("clientPhoneNumber-id");
    private readonly By conditionsCheckboxElement = By.Id("form-conditions");
    private readonly By privacyCheckboxElement = By.Id("form-privacy");
    private readonly By comprarButtonElement = By.XPath(
            "//button[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy j-button-buy']//span[@class='sv-button__label j-button-buy-label'][normalize-space()='Comprar']");
    private readonly By datosDeLaOperacionElement = By.XPath("//h1[@class='datosDeLaOperacion']");

    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string confirmEmail,string phone)
    {
        try
        {
            var fullNameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
            ClearAndSetInputValue(fullNameField, fullName);

            var surNameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
            ClearAndSetInputValue(surNameField, surName);

            var idField = FluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));
            ClearAndSetInputValue(idField, id);

            var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
            ClearAndSetInputValue(emailField, email);

            var confirmEmailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(confirmEmailElement));
            ClearAndSetInputValue(confirmEmailField, confirmEmail);
            
            var phoneField = FluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
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
            var conditionsCheckbox =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(conditionsCheckboxElement));

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
            var privacyCheckbox =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(privacyCheckboxElement));

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

    public void ClickOnComprarButtonAgain()
    {
        try
        {
            IList<IWebElement> comprarButtons = FluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(comprarButtonElement));
            
            if (comprarButtons.Count > 0)
            {
                var randomIndex = random.Next(0, comprarButtons.Count);
                var selectedComprarButton = comprarButtons[randomIndex];

                ScrollIntoView(selectedComprarButton);
                Thread.Sleep(7000);
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
            Console.WriteLine($"An error occurred while clicking on 'Comprar' button again in Reservation Page: {ex.Message}");
        }
    }
    
    public void BlankFields()
    {
        var nameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
        var surNameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
        var idField = FluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));
        var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        var phoneField = FluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
        
        var name = nameField.GetAttribute("value");
        var lastName = surNameField.GetAttribute("value");
        var id = idField.GetAttribute("value");
        var email = emailField.GetAttribute("value");
        var phone = phoneField.GetAttribute("value");

        Assert.Multiple(() =>
        {
            Assert.That(string.IsNullOrEmpty(name), "Name field is empty");
            Assert.That(string.IsNullOrEmpty(lastName), "Last name field is empty");
            Assert.That(string.IsNullOrEmpty(id), "ID field is empty");
            Assert.That(string.IsNullOrEmpty(email), "Email field is empty");
            Assert.That(string.IsNullOrEmpty(phone), "Phone field is empty");
        });
    }

    public void InvalidNameAndSurname()
    {
        var nameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(nameElement));
        var surNameField = FluentWait.Until(ExpectedConditions.ElementIsVisible(surNameElement));
    
        var name = nameField.GetAttribute("value");
        var lastName = surNameField.GetAttribute("value");
    
        Assert.That(() => MyRegex4().IsMatch(name), Is.False, "Invalid name");
        Assert.That(() => MyRegex3().IsMatch(lastName), Is.False, "Invalid last name");
    }

    public void InvalidId()
    {
        var idField = FluentWait.Until(ExpectedConditions.ElementIsVisible(idElement));

        var id = idField.GetAttribute("value");
        Assert.That(() => MyRegex2().IsMatch(id), Is.False, "Invalid ID");
    }
    
    public void InvalidEmail()
    {
        var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        
        var email = emailField.GetAttribute("value");
        Assert.That(() => MyRegex1().IsMatch(email), "Invalid email");
    }
    
    public void InvalidConfirmationEmail()
    {
        var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        var confirmEmailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(confirmEmailElement));
        
        var email = emailField.GetAttribute("value");
        var confirmEmail = confirmEmailField.GetAttribute("value");
        
        Assert.That(email, !Is.EqualTo(confirmEmail));
    }
    
    public void InvalidPhone()
    {
        var phoneField = FluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
        
        var phone = phoneField.GetAttribute("value");
        Assert.That(() => MyRegex().IsMatch(phone), "Invalid phone");
    }

    public void AreCheckboxesSelected()
    {
        var conditionsCheckbox =
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(conditionsCheckboxElement));
        var privacyCheckbox =
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(privacyCheckboxElement));
        
        var isConditionsCheckboxSelected = conditionsCheckbox.Selected;
        var isPrivacyCheckboxSelected = privacyCheckbox.Selected;
        
        Assert.That(isConditionsCheckboxSelected || isPrivacyCheckboxSelected, Is.False, "The Conditions and Privacy Checkbox is not selected and Card Page is not displayed");
        
    }

    public void IsCardPageDisplayed()
    {
        try
        {
            var datosElement = Driver!.FindElement(datosDeLaOperacionElement);
            DrawBorder(datosElement);

            if (datosElement.Displayed)
            {
                Assert.Fail("Card Page is displayed, which is unexpected");
            }
            else
            {
                Console.WriteLine("Card Page is not displayed, as expected");
            }
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Card Page is not present, as expected");
        }
    }

    [GeneratedRegex("^\\+?\\d*$")]
    private static partial Regex MyRegex();
    [GeneratedRegex("^[\\w-]+(\\.[\\w-]+)*@([\\w-]+\\.)+[a-zA-Z]{2,7}$")]
    private static partial Regex MyRegex1();
    [GeneratedRegex("^[a-zA-Z0-9]*$")]
    private static partial Regex MyRegex2();
    [GeneratedRegex("^[a-zA-Z\\s]*$")]
    private static partial Regex MyRegex3();
    [GeneratedRegex("^[a-zA-Z\\s]*$")]
    private static partial Regex MyRegex4();
}