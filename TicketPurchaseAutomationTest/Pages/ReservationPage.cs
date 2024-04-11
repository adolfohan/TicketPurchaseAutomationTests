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
            "//button[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy j-button-buy']" +
            "//span[@class='sv-button__label j-button-buy-label'][normalize-space()='Comprar']");
    private readonly By datosDeLaOperacionElement = By.XPath("//h1[@class='datosDeLaOperacion']");

    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string confirmEmail, string phone)
{
    var elements = new List<By> { nameElement, surNameElement, idElement, emailElement, confirmEmailElement, phoneElement };
    var values = new List<string> { fullName, surName, id, email, confirmEmail, phone };

    for (var i = 0; i < elements.Count; i++)
    {
        try
        {
            var field = FluentWait.Until(ExpectedConditions.ElementIsVisible(elements[i]));
            ClearAndSetInputValue(field, values[i]);
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
    var elements = new List<By> { nameElement, surNameElement, idElement, emailElement, phoneElement };
    var fieldNames = new List<string> { "Name", "Last name", "ID", "Email", "Phone" };

    Assert.Multiple(() =>
    {
        for (var i = 0; i < elements.Count; i++)
        {
            var field = FluentWait.Until(ExpectedConditions.ElementIsVisible(elements[i]));
            var value = field.GetAttribute("value");
            Assert.That(string.IsNullOrEmpty(value), $"{fieldNames[i]} field is empty");
        }
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
        Assert.That(() => IdRegex().IsMatch(id), Is.False, "Invalid ID");
    }
    
    public void InvalidEmail()
    {
        var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        
        var email = emailField.GetAttribute("value");
        Assert.That(() => EmailRegex().IsMatch(email), Is.False, "Invalid email");
    }

    public void InvalidConfirmationEmail()
    {
        var emailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(emailElement));
        var confirmEmailField = FluentWait.Until(ExpectedConditions.ElementIsVisible(confirmEmailElement));

        var email = emailField.GetAttribute("value");
        var confirmEmail = confirmEmailField.GetAttribute("value");

        Assert.That(email, !Is.EqualTo(confirmEmail), "Emails do not match");
    }

    public void InvalidPhone()
    {
        var phoneField = FluentWait.Until(ExpectedConditions.ElementIsVisible(phoneElement));
        
        var phone = phoneField.GetAttribute("value");
        Assert.That(() => PhoneRegex().IsMatch(phone), Is.False, "Invalid phone");
    }

public void AreCheckboxesSelected()
{
    var checkboxes = new List<By> { conditionsCheckboxElement, privacyCheckboxElement };

    Assert.Multiple(() =>
    {
        foreach (var checkbox in checkboxes)
        {
            var element = FluentWait.Until(ExpectedConditions.ElementToBeClickable(checkbox));
            Assert.That(element.Selected, Is.False, $"{checkbox} is not selected and Card Page is not displayed");
        }
    });
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
    
    [GeneratedRegex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")]
    private static partial Regex EmailRegex();
    [GeneratedRegex(@"^\+?[0-9\s-]*$")]
    private static partial Regex PhoneRegex();
    [GeneratedRegex(@"^[a-zA-Z]{1,3}\d{1,10}[a-zA-Z]{0,2}$")]
    private static partial Regex IdRegex();
    [GeneratedRegex("^[a-zA-Z\\s]*$")]
    private static partial Regex MyRegex3();
    [GeneratedRegex("^[a-zA-Z\\s]*$")]
    private static partial Regex MyRegex4();
}