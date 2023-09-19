using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCases.Utilities;

namespace TestCases.Pages;

public class TicketPurchasePageeee
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public TicketPurchasePageeee(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement numberOfTicket =>
        driver.FindElement(By.XPath("//*[@id=\"pcwfrp7nuupbfzw\"]/div[5]/div/div[1]/input")); 

    public void NavigateToUrl()
    {
        try
        {
            var baseUrl = ConfigReader.GetBaseUrl();
            driver.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/");
            driver.Manage().Window.Maximize();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    public void ClickMeInteresaButton()
    {
        try
        {
            var meInteresaButton =
                driver.FindElement(By.XPath("//*[@id=\"funnel-list\"]/div[1]/div/div[2]/div[2]/div/div[2]/a"));
            meInteresaButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            // Handle the exception for missing elements (e.g., if the button cannot be found)
            Console.WriteLine($"Element not found: {ex.Message}");
            // You might want to throw or log this exception depending on your error-handling strategy.
        }
        catch (Exception ex)
        {
            // Handle other exceptions that might occur during the operation
            Console.WriteLine($"An error occurred while clicking 'Me interesa' button: {ex.Message}");
            // You might want to throw or log this exception depending on your error-handling strategy.
        }
    }

    public void SelectDate(string date)
    {
        try
        {
            var calendar = driver.FindElement(By.Id("datepicker"));
            calendar.Clear();
            calendar.SendKeys(date);
            calendar.SendKeys(Keys.Enter);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while selecting date: {ex.Message}");
        }
    }

    public void SelectTickets(string numberOfTickets)
    {
        try
        {
            numberOfTicket.Clear();
            numberOfTicket.SendKeys(numberOfTickets);
            //driver.FindElement(By.XPath("/html/body/div[1]/section/div/div/div[1]/section[2]/div[2]/div[2]/div/div[2]/div[5]/div/div[1]/span[2]")).Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while selecting tickets: {ex.Message}");
        }
    }

    public void ClickComprarButton()
    {
        try
        {
            driver.FindElement(By.XPath("/html/body/div[1]/section/div/div/div[2]/div/div[2]/div[2]/div[3]/div[2]/a/span[1]")).Click();
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


    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string phone)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            var fullNameField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientFullName-id")));
            var surNameField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientSurname-id")));
            var idField =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientDocumentIdentifier-id")));
            var emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientEmail-id")));
            var phoneField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientPhoneNumber-id")));
            
            fullNameField.Clear();
            surNameField.Clear();
            idField.Clear();
            emailField.Clear();
            phoneField.Clear();
            
            fullNameField.SendKeys(fullName);
            surNameField.SendKeys(surName);
            idField.SendKeys(id);
            emailField.SendKeys(email);
            phoneField.SendKeys(phone);
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

    public void SelectCreditCardPayment()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var creditCard = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));
            creditCard.SendKeys(Keys.Space);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while selecting credit card: {ex.Message}");
        }
    }

    public void CheckConditions()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var conditionsCheckbox =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));
            conditionsCheckbox.Click();
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var privacyCheckbox =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-privacy']")));
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

    public void ClickComprarButtonAgain()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ComprarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//*[@id=\"shopping-cart\"]/div[2]/div[3]/div[2]/a")));
            ComprarButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking 'Comprar' button again: {ex.Message}");
        }
    }

    public void CompleteCardInformation(string cardNumber, string expirationMonth, string expirationYear,
        string securityCode)
    {
        try
        {
            // Create a dictionary to map field names to values
            var cardInfo = new Dictionary<string, string>
            {
                { "//*[@id=\"inputCard\"]", cardNumber },
                { "//*[@id=\"cad1\"]", expirationMonth },
                { "//*[@id=\"cad2\"]", expirationYear },
                { "//*[@id=\"codseg\"]", securityCode }
            };
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            foreach (var field in cardInfo)
            {
                // Find the element by XPath and enter the corresponding value
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(field.Key)));
                element.Clear();
                element.SendKeys(field.Value);
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while entering card information: {ex.Message}");
        }
    }

    public void ClickPagarButton()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var PagarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[2]")));
            PagarButton.Click();
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

    public bool CannotProceedToThePaymentBlankFields()
    {
        try
        {
            var firstName = driver.FindElement(By.Id("clientFullName-id"));
            var surName = driver.FindElement(By.Id("clientSurname-id"));
            var id = driver.FindElement(By.Id("clientDocumentIdentifier-id"));
            var email = driver.FindElement(By.Id("clientEmail-id"));
            var phone = driver.FindElement(By.Id("clientPhoneNumber-id"));

            bool firstNameNotEmpty = !string.IsNullOrWhiteSpace(firstName.GetAttribute("value"));
            bool surNameNotEmpty = !string.IsNullOrWhiteSpace(surName.GetAttribute("value"));
            bool idNotEmpty = !string.IsNullOrWhiteSpace(id.GetAttribute("value"));
            bool emailNotEmpty = !string.IsNullOrWhiteSpace(email.GetAttribute("value"));
            bool phoneNotEmpty = !string.IsNullOrWhiteSpace(phone.GetAttribute("value"));
            
            return firstNameNotEmpty && surNameNotEmpty && idNotEmpty && emailNotEmpty && phoneNotEmpty;
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }

    public bool CannotProceedToThePayment()
    {
        try
        {
            var currentUrlBeforeClick = driver.Url;

            ClickComprarButtonAgain();

            var currentUrlAfterClick = driver.Url;

            return !currentUrlBeforeClick.Equals(currentUrlAfterClick);
        }
        catch (WebDriverException ex)
        {
            Console.WriteLine($"WebDriverException: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }

    public void ClickEnviarButton()
    {
        try
        {
            driver.FindElement(By.Id("boton")).Click();
            
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

    public void ClickContinuarButton()
    {
        try
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div[2]/div[3]/div[2]/div[1]/input[2]")).Click();
            
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

    public void ClickDescargarButton()
    {
        try
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("download-tickets-anchor")));
            element.Click();
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
    
    public IWebElement IsTicketPurchaseSuccessful
    {
        get
        {
            try
            {
                return wait.Until(
                    ExpectedConditions.ElementIsVisible(
                        By.XPath("/html/body/center/font[1]/div")));
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout waiting for the element to be visible: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while waiting for the element: {ex.Message}");
                return null;
            }
        }
    }

    public void TicketPurchaseUnsuccessful()
    {
        try
        {
            var alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
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
}