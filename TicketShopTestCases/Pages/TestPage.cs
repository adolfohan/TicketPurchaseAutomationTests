using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCases.Utilities;

namespace TestCases.Pages;

public class TestPage
{
    private readonly IWebDriver driver;
    private readonly DefaultWait<IWebDriver> wait;
    private ConfigReader configReader;

    public TestPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new DefaultWait<IWebDriver>(driver);
        wait.Timeout = TimeSpan.FromSeconds(30);
        wait.PollingInterval = TimeSpan.FromSeconds(2);
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement numberOfTicket =>
        driver.FindElement(By.XPath("//*[@id=\"pcwfrp7nuupbfzw\"]/div[5]/div/div[1]/input"));

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

    public void NavigateToUrl()
    {
        try
        {
            string? baseUrl = ConfigReader.GetBaseUrl();
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
            IWebElement meInteresaButton =
                driver.FindElement(By.XPath("//*[@id=\"funnel-list\"]/div[1]/div/div[2]/div[2]/div/div[2]/a"));
            meInteresaButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking 'Me interesa' button: {ex.Message}");
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
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/section/div/div/div[2]/div/div[2]/div[2]/div[3]/div[2]/a/span[1]"))).Click();
            Thread.Sleep(1000);
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
            var fullNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientFullName-id")));
            ClearAndSetInputValue(fullNameField, fullName);

            var surNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientSurname-id")));
            ClearAndSetInputValue(surNameField, surName);

            var idField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientDocumentIdentifier-id")));
            ClearAndSetInputValue(idField, id);

            var emailField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientEmail-id")));
            ClearAndSetInputValue(emailField, email);

            var phoneField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientPhoneNumber-id")));
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

    public void SelectCreditCardPayment()
    {
        try
        {
            IWebElement creditCard =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));
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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            IWebElement conditionsCheckbox =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", conditionsCheckbox);

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
        Thread.Sleep(1000);
    }

    public void ClickComprarButtonAgain()
    {
        try
        {
            IWebElement ComprarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/section/div/div/div[2]/div/div[2]/div[2]/div[3]/div[2]/a")));
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
            var cardInfo = new Dictionary<string, string>
            {
                { "//*[@id=\"inputCard\"]", cardNumber },
                { "//*[@id=\"cad1\"]", expirationMonth },
                { "//*[@id=\"cad2\"]", expirationYear },
                { "//*[@id=\"codseg\"]", securityCode }
            };

            foreach (var field in cardInfo)
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(field.Key)));
                ClearAndSetInputValue(element, field.Value);
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
            IWebElement pagarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[2]")));
            pagarButton.Click();
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
            IWebElement firstName = driver.FindElement(By.Id("clientFullName-id"));
            IWebElement surName = driver.FindElement(By.Id("clientSurname-id"));
            IWebElement id = driver.FindElement(By.Id("clientDocumentIdentifier-id"));
            IWebElement email = driver.FindElement(By.Id("clientEmail-id"));
            IWebElement phone = driver.FindElement(By.Id("clientPhoneNumber-id"));

            var firstNameNotEmpty = !string.IsNullOrWhiteSpace(firstName.GetAttribute("value"));
            var surNameNotEmpty = !string.IsNullOrWhiteSpace(surName.GetAttribute("value"));
            var idNotEmpty = !string.IsNullOrWhiteSpace(id.GetAttribute("value"));
            var emailNotEmpty = !string.IsNullOrWhiteSpace(email.GetAttribute("value"));
            var phoneNotEmpty = !string.IsNullOrWhiteSpace(phone.GetAttribute("value"));

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
    
    private void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }
}