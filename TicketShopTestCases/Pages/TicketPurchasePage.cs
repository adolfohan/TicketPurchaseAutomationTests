using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCases.Pages;

public class TicketPurchasePage
{
    private readonly By AdvancedSelectorButton =
        By.XPath("//*[@class='sv-button sv-button--date']");

    private readonly By ComprarButton =
        By.CssSelector(
            "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    //By.XPath("type-contained sv-button--color-primary sv-button--size-lg sv-button--buy']/span[@class='sv-button__label']");


    private readonly By ConfirmationButton =
        By.XPath("//button[@class='btn sv-button--type-contained sv-button--color-secondary']");

    private readonly IWebDriver driver;
    private readonly DefaultWait<IWebDriver> fluentWait;
    private readonly HomePage homePage;
    private readonly Random random;

    private readonly By RandomOption =
        By.CssSelector("select.form-select");

    private readonly By SessionDropdown =
        By.TagName("select");
    //private readonly WebDriverWait wait;

    public TicketPurchasePage(IWebDriver driver)
    {
        this.driver = driver;
        random = new Random();
        homePage = new HomePage(driver);

        fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout = TimeSpan.FromSeconds(30);
        fluentWait.PollingInterval = TimeSpan.FromSeconds(2);
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private By InputNumberOfTickets =>
        By.XPath("//input[@input='number']");
        
    private By SelectPlusButton =>
        By.CssSelector("span.sv-form__plus");

    public void SelectNumberOfTickets(string numberOfTickets)
    {
        var inputElementFound = false;
        try
        {
            while (!inputElementFound)
            {
                DefaultWait<IWebDriver> wait = new(driver)
                {
                    Timeout = TimeSpan.FromSeconds(30),
                    PollingInterval = TimeSpan.FromSeconds(2)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                IList<IWebElement> inputFields = wait.Until(driver => driver.FindElements(InputNumberOfTickets));

                //wait.Until(driver =>
                //    ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                
                List<IWebElement> filteredNumberInputs = new List<IWebElement>();
                
                foreach (var input in inputFields)
                {
                    // Verifica si el elemento no está dentro del div modal fade
                    if (!IsElementInsideModal(input, driver))
                    {
                        filteredNumberInputs.Add(input);
                    }
                }
                
                if (filteredNumberInputs.Count > 0)
                {
                    var randomIndex = random.Next(0, filteredNumberInputs.Count);

                    var selectedInputField = filteredNumberInputs[randomIndex];

                    ScrollIntoView(selectedInputField);
                    ClearAndSetInputValue(selectedInputField, numberOfTickets);
                    //selectedInputField.Click();
                    //selectedInputField.Clear();
                    selectedInputField.SendKeys(numberOfTickets);

                    inputElementFound = true;
                }
                else
                {
                    driver.Navigate().Back();
                    homePage.ClickRandomMeInteresaButton();
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static bool IsElementInsideModal(IWebElement element, IWebDriver driver)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (bool)js.ExecuteScript(
                "var modal = document.querySelector('.modal.fade');" +
                "if (modal.contains(arguments[0])) { return true; } else { return false; }",
                element);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void ConfirmDate()
    {
        IWebElement confirmationBox = fluentWait.Until(ExpectedConditions.ElementIsVisible(ConfirmationButton));

        IWebElement confirmButton = confirmationBox.FindElement(ConfirmationButton);
        confirmButton.Click();
    }

    public void ClickComprarButton()
    {
        try
        {
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(ComprarButton)).Click();
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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            wait.Until(ExpectedConditions.ElementExists(SessionDropdown));
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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            IWebElement dropdown = wait.Until(ExpectedConditions.ElementToBeClickable(SessionDropdown));

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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

            var selectElement = wait.Until(ExpectedConditions.ElementToBeClickable(RandomOption));
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
        DefaultWait<IWebDriver> wait = new(driver)
        {
            Timeout = TimeSpan.FromSeconds(30),
            PollingInterval = TimeSpan.FromSeconds(2)
        };
        var availableDate = wait.Until(ExpectedConditions.ElementToBeClickable(AdvancedSelectorButton));
        availableDate.Click();

        var inputNumberOfTickets = wait.Until(ExpectedConditions.ElementToBeClickable(
            By.CssSelector("input[type='number'][min='0'][product-limitofnumberofpeopletobegroup='']")));
        inputNumberOfTickets.SendKeys("1");

        var aceptarButton =
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//*[@id=\"modalcal1ie8kwb8rpd846\"]/div/div/div[3]/button[2]")));
        aceptarButton.Click();
    }

    public void CompletePersonalInformation(string fullName, string surName, string id, string email, string phone)
    {
        try
        {
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };
            var creditCard =
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
            IWebElement conditionsCheckbox =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-conditions']")));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", conditionsCheckbox);
            
            conditionsCheckbox.Click();
            //conditionsCheckbox.SendKeys(Keys.Space);
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
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='form-privacy']")));
            privacyCheckbox.Click();
            //privacyCheckbox.SendKeys(Keys.Space);
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
            IWebElement comprarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector("a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy")));

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

            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };
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
            DefaultWait<IWebDriver> wait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(2)
            };

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

    private void ScrollIntoView(IWebElement element)
    {
        var jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});", element);
    }
}