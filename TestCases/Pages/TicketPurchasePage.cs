using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCases.Pages;

public class TicketPurchasePage
{
    private readonly IWebDriver driver;
    private readonly Random random;
    private readonly WebDriverWait wait;
    
    public TicketPurchasePage(IWebDriver driver)
    {
        this.driver = driver;
        random = new Random();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    private By InputNumberOfTickets => By.CssSelector("input[type='number'][min='0'][product-limitofnumberofpeopletobegroup='']");
    
    public void SelectNumberOfTickets(string numberOfTickets)
    {
        IList<IWebElement> inputFields = driver.FindElements(InputNumberOfTickets);

        if (inputFields.Count > 0)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, inputFields.Count);

            IWebElement selectedInputField = inputFields[randomIndex];
            ClearAndSetInputValue(selectedInputField, numberOfTickets);
            selectedInputField.SendKeys(Keys.Enter);
        }
        else
        {
            throw new NoSuchElementException("No input fields found on the page.");
        }
    }
    
    public void ClickComprarButton()
    {
        try
        {
            driver.FindElement(By.CssSelector(".sv-button__label.j-button-buy-label"));
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
    
    public bool HaveSessions()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.TagName("select")));
            return true;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }

    public void SelectSession()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName("select")));
        
            SelectElement select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            if (options.Count <= 0) return;
            
            int randomIndex = random.Next(1, options.Count);

            select.SelectByIndex(randomIndex);
                    
            ClickComprarButton();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
    }
    
    public bool HaveAdvancedSelector()
{
    try
    {
        IList<IWebElement> datepickers = driver.FindElements(By.CssSelector("input[type='date']"));
        IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));

        int minDatepickers = 2;
        int minCheckboxes = 2;

        return datepickers.Count >= minDatepickers && checkboxes.Count >= minCheckboxes;
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

public void SelectAdvancedSelector()
{
    if (HaveAdvancedSelector())
    {
        try
        {
            ClickRandomCheckbox();
            SelectRandomOptionFromDropdown();
            ClickComprarButton();
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

private void ClickRandomCheckbox()
{
    try
    {
        IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='radio']"));

        if (checkboxes.Count > 0)
        {
            int randomCheckboxIndex = random.Next(0, checkboxes.Count);
            IWebElement randomCheckbox = checkboxes[randomCheckboxIndex];
            randomCheckbox.Click();
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

private void SelectRandomOptionFromDropdown()
{
    try
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement selectElement =
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select.form-select")));

        SelectElement select = new SelectElement(selectElement);

        IList<IWebElement> options = select.Options;

        if (options.Count > 1)
        {
            int randomIndex = random.Next(1, options.Count);
            select.SelectByIndex(randomIndex);
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

    
    /*public void SelectAdvancedSelector()
    {
        IList<IWebElement> datePickers = driver.FindElements(By.CssSelector("input[type='text']"));
        IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='radio']"));
        
        int minDatepickers = 2;
        int intminCheckboxes = 2;

        if (datePickers.Count >= minDatepickers && checkboxes.Count >= intminCheckboxes)
        {
            int randomCheckboxIndex = random.Next(0, checkboxes.Count);
            IWebElement randomCheckbox = checkboxes[randomCheckboxIndex];
            randomCheckbox.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement selectElement =
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select.form-select")));

            SelectElement select = new SelectElement(selectElement);

            IList<IWebElement> options = select.Options;

            if (options.Count > 1)
            {
                int randomIndex = random.Next(1, options.Count);

                select.SelectByIndex(randomIndex);

                ClickComprarButton();
            }
        }
    }*/

    
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

            ClearAndSetInputValue(fullNameField, fullName);
            ClearAndSetInputValue(surNameField, surName);
            ClearAndSetInputValue(idField, id);
            ClearAndSetInputValue(emailField, email);
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
            var comprarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//*[@id=\"shopping-cart\"]/div[2]/div[3]/div[2]/a")));
            comprarButton.Click();
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
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(field.Key)));
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var pagarButton = wait.Until(ExpectedConditions.ElementToBeClickable(
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
    
    private void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }
}