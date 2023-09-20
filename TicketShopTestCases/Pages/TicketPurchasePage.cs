using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCases.Pages;

public class TicketPurchasePage
{
    private readonly IWebDriver driver;
    private readonly Random random;
    private readonly DefaultWait<IWebDriver> fluentWait;
    private readonly WebDriverWait wait;

    public TicketPurchasePage(IWebDriver driver)
    {
        this.driver = driver;
        random = new Random();
        
        fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout = TimeSpan.FromSeconds(10);
        fluentWait.PollingInterval = TimeSpan.FromSeconds(1);
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    
    private By InputNumberOfTickets =>
        By.CssSelector("input[type='number'][min='0'][product-limitofnumberofpeopletobegroup='']");
    
    private readonly By ConfirmationButton =
        By.XPath("//*[@id=\"vue-app\"]/section/div/div/div[1]/div[2]/div[1]/div/div[3]/button[2]");

    private readonly By ComprarButton =
        By.CssSelector("a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");

    private readonly By SessionDropdown =
        By.TagName("select");

    private readonly By RandomOption =
        By.CssSelector("select.form-select");

    private readonly By CreditCardPayment =
        By.XPath("//*[@id='form-conditions']");

    private readonly By ConditionsCheckbox =
        By.XPath("//*[@id='form-conditions']");

    private readonly By PrivacyCheckbox =
        By.XPath("//*[@id='form-privacy']");
    
    private readonly By Datepickers =
        By.CssSelector("input[type='date']");

    private readonly By Checkboxes =
        By.CssSelector("input[type='checkbox']");

    private readonly By AdvancedSelectorButton =
        By.XPath("//*[@class='sv-button sv-button--date']");

    private readonly By CardNumberField =
        By.XPath("//*[@id=\"inputCard\"]");

    private readonly By ExpirationMonthField =
        By.XPath("//*[@id=\"cad1\"]");

    private readonly By ExpirationYearField =
        By.XPath("//*[@id=\"cad2\"]");

    private readonly By SecurityCodeField =
        By.XPath("//*[@id=\"codseg\"]");

    private readonly By PagarButton =
        By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[2]");

    private readonly By EnviarButton =
        By.Id("boton");

    private readonly By ContinuarButton =
        By.XPath("/html/body/div[1]/form/div[2]/div[3]/div[2]/div[1]/input[2]");

    private readonly By DescargarButton =
        By.Id("download-tickets-anchor");


    public void SelectNumberOfTickets(string numberOfTickets)
    {
        IList<IWebElement> inputFields = fluentWait.Until(driver => driver.FindElements(InputNumberOfTickets));

        //wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        //IList<IWebElement> inputFields = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(InputNumberOfTickets));

        /*if (inputFields.Count > 0)
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, inputFields.Count);

            var selectedInputField = inputFields[randomIndex];

            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});",
                selectedInputField);

            ClearAndSetInputValue(selectedInputField, numberOfTickets);
        }*/
        if (inputFields.Count > 0)
        {
            var randomIndex = random.Next(0, inputFields.Count);

            var selectedInputField = inputFields[randomIndex];

            ScrollIntoView(selectedInputField);
            ClearAndSetInputValue(selectedInputField, numberOfTickets);
        }
        else
        {
            throw new NoSuchElementException("No input fields found on the page.");
        }
    }


    /*private By InputNumberOfTickets =>
        By.CssSelector("input[type='number'][min='0'][product-limitofnumberofpeopletobegroup='']");
    
    public void SelectNumberOfTickets(string numberOfTickets)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        
        IList<IWebElement> inputFields = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(InputNumberOfTickets));

        if (inputFields.Count > 0)
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, inputFields.Count);

            var selectedInputField = inputFields[randomIndex];

            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});",
                selectedInputField);
            
            //selectedInputField.Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(selectedInputField));

            ClearAndSetInputValue(selectedInputField, numberOfTickets);
            //selectedInputField.SendKeys(Keys.Enter);
        }
        else
        {
            throw new NoSuchElementException("No input fields found on the page.");
        }
    }*/

    
    /*public void SelectNumberOfTickets(string numberOfTickets)
    {
        IList<IWebElement> inputFields = driver.FindElements(InputNumberOfTickets);

        if (inputFields.Count > 0)
        {
            var rand = new Random();
            var randomIndex = rand.Next(0, inputFields.Count);

            var selectedInputField = inputFields[randomIndex];
            
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", selectedInputField);
           
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});",
                selectedInputField);
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(selectedInputField));

            ClearAndSetInputValue(selectedInputField, numberOfTickets);
            selectedInputField.SendKeys(Keys.Enter);
        }
        else
        {
            throw new NoSuchElementException("No input fields found on the page.");
        }
    }*/

    public void ConfirmDate()
    {
        var confirmationBox = fluentWait.Until(ExpectedConditions.ElementIsVisible(ConfirmationButton));

        var confirmButton = confirmationBox.FindElement(ConfirmationButton);
        confirmButton.Click();
    }

    public void ClickComprarButton()
    {
        try
        {
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(ComprarButton)).Click();
            //driver.FindElement(By.XPath("//a[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy']"));
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
    
    public bool HaveSession()
    {
        try
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            fluentWait.Until(ExpectedConditions.ElementExists(SessionDropdown));
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
            var dropdown = fluentWait.Until(ExpectedConditions.ElementToBeClickable(SessionDropdown));

            var select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            if (options.Count <= 0) return;

            var randomIndex = random.Next(1, options.Count);

            select.SelectByIndex(randomIndex);

            ClickComprarButtonAgain();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
    }

    public bool HaveMoreSessions()
    {
        try
        {
            IList<IWebElement> datepickers = driver.FindElements(By.CssSelector("input[type='date']"));
            IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));

            var minDatepickers = 2;
            var minCheckboxes = 2;

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

    public void SelectMoreSessions()
    {
        if (HaveMoreSessions())
            try
            {
                ClickRandomCheckbox();
                SelectRandomOptionFromDropdown();
                ClickComprarButtonAgain();
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

    private void ClickRandomCheckbox()
    {
        try
        {
            IList<IWebElement> checkboxes = driver.FindElements(By.CssSelector("input[type='radio']"));

            if (checkboxes.Count > 0)
            {
                var randomCheckboxIndex = random.Next(0, checkboxes.Count);
                var randomCheckbox = checkboxes[randomCheckboxIndex];
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
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var selectElement = fluentWait.Until(ExpectedConditions.ElementToBeClickable(RandomOption));
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select.form-select")));

            var select = new SelectElement(selectElement);

            IList<IWebElement> options = select.Options;

            if (options.Count > 1)
            {
                var randomIndex = random.Next(1, options.Count);
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


    public void SelectAdvancedSelector()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement availableDate = fluentWait.Until(ExpectedConditions.ElementToBeClickable(AdvancedSelectorButton));
        availableDate.Click();
        
        IWebElement inputNumberOfTickets = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='number'][min='0'][product-limitofnumberofpeopletobegroup='']")));
        inputNumberOfTickets.SendKeys("1");
        
        IWebElement aceptarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"modalcal1ie8kwb8rpd846\"]/div/div/div[3]/button[2]")));
        aceptarButton.Click();
    }

    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string phone)
    {
        try
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            
            var fullNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientFullName-id")));
            ClearAndSetInputValue(fullNameField, fullName);
            
            var surNameField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientSurname-id")));
            ClearAndSetInputValue(surNameField, surName);
            
            var idField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientDocumentIdentifier-id")));
            ClearAndSetInputValue(idField, id);
            
            var emailField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientEmail-id")));
            ClearAndSetInputValue(emailField, email);
            
            var phoneField = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("clientPhoneNumber-id")));
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
    
    /*public void CompletePersonalInformation(string fullName, string surName, string id, string email, string phone)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

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
    }*/

    public void SelectCreditCardPayment()
    {
        try
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var creditCard =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));
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
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            var conditionsCheckbox = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));
            
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

    
    /*public void CheckConditions()
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
    }*/

    public void CheckPrivacy()
    {
        try
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var privacyCheckbox =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-privacy']")));
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
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var comprarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector(".j-button-buy")));
                //By.XPath("//*[@id=\"shopping-cart\"]/div[2]/div[3]/div[2]/a")));
            
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
                var element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(field.Key)));
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
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var pagarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(
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
            var element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Id("download-tickets-anchor")));
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
    
    private void ScrollIntoView(IWebElement element)
    {
        var jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});", element);
    }
    
}