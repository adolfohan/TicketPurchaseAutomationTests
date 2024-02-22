using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class TicketsSelectionPage(IWebDriver? driver) : BasePage(driver)
{
    private readonly HomePage homePage = new(driver);
    private readonly SessionPage sessionPage = new(driver);
    private readonly AdvancedDateSelectorPage advancedDateSelectorPage = new(driver);
    private readonly Error500Page error500Page = new(driver);
    
    private static By inputNumberOfTicketsElement => By.XPath("//input[@type='number']");
    
    private readonly By confirmationButtonElement =
        By.XPath("//button[@class='btn sv-button--type-contained sv-button--color-secondary']");
    
    private readonly By comprarButton =
        By.XPath(
            "//button[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy']");
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");
    //private readonly By priceElement = By.ClassName("sv-cart__price");
    private readonly By panelWrapperElement = By.XPath("//a[@class='collapsed sv-panel__wrapper' and @aria-expanded='false']");
    private readonly By navBarElement = By.Id("funnelmenu");
    private readonly By sessionMessageElement = By.XPath("//div[@class='s-panel-sessions__heading']");

    private void ClickOnPanelWrapper()
    {
        var panel = FluentWait.Until(ExpectedConditions.ElementIsVisible(panelWrapperElement));

        if (!panel.Displayed) return;
        ScrollIntoView(panel);
        panel.SendKeys(Keys.Enter);

        /*IList<IWebElement> panelWrapper = fluentWait.Until(webDriver => webDriver.FindElements(panelWrapperElement));

        if (panelWrapper.Count > 0)
        {
            foreach (IWebElement element in panelWrapper)
            {
                ScrollIntoView(element);
                element.Click();
            }
        }*/
    }

    public void SelectNumberOfTickets(string numberOfTickets)
    {
        try
        {
            IList<IWebElement> inputFields =
                FluentWait.Until(webDriver => webDriver!.FindElements(inputNumberOfTicketsElement));
            var randomIndex = Random.Next(0, inputFields.Count);
            var selectedInputField = inputFields[randomIndex];
            
            ClearAndSetInputValue(selectedInputField, numberOfTickets);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while selecting number of tickets: " + e.Message);
            throw;
        }
    }
    
    /*public void SelectNumberOfTickets(string numberOfTickets, int maxAttempts = 10)
    {
        var attempts = 0;

        while (attempts < maxAttempts)
        {
            try
            {
                IList<IWebElement> inputFields =
                    FluentWait.Until(webDriver => webDriver!.FindElements(inputNumberOfTicketsElement));

                if (inputFields.Count > 0)
                {
                    var randomIndex = Random.Next(0, inputFields.Count);
                    var selectedInputField = inputFields[randomIndex];

                    while (!selectedInputField.Displayed)
                    {
                        randomIndex = Random.Next(0, inputFields.Count);
                        selectedInputField = inputFields[randomIndex];
                    }

                    ScrollIntoView(selectedInputField);
                    ClearAndSetInputValue(selectedInputField, numberOfTickets);
                    break;
                }

                homePage.NavigateToNormalUrl();
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Timeout error: {ex.Message}");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            attempts++;
        }

        if (attempts == maxAttempts)
        {
            Console.WriteLine("Max attempts reached, could not select number of tickets");
        }
    }*/
    
    public void ConfirmDate()
    {
        var confirmationBox = FluentWait.Until(ExpectedConditions.ElementIsVisible(confirmationButtonElement));

        var confirmButton = confirmationBox.FindElement(confirmationButtonElement);
        confirmButton.Click();
    }
    
    public void ClickOnComprarButton()
    {
        try
        {
            var comprarBtn = FluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
            comprarBtn.Click();
        
            /*while (true)
            {
                try
                {
                    if (!error500Page.Error500Displayed())
                    {
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    break;
                }

                Driver!.Navigate().Back();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                comprarBtn.Click();
            }*/
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
    }

    public void SelectRandomNavBar()
    {
        try
        {
            while (true)
            {
                IList<IWebElement> inputFields =
                    FluentWait.Until(webDriver => webDriver!.FindElements(inputNumberOfTicketsElement));
                if (inputFields.Count > 0)
                {
                    var navBar = FluentWait.Until(ExpectedConditions.ElementToBeClickable(navBarElement));
                    IList<IWebElement> navBarItems = navBar.FindElements(By.CssSelector("li.nav-item"));
                    while (navBarItems.Count > 0 && inputFields.Count > 0)
                    {
                        var randomIndex = Random.Next(0, navBarItems.Count);
                        var selectedNavBarItem = navBarItems[randomIndex];
                        selectedNavBarItem.Click();
                    }
                }
                Driver!.Navigate().Back();
                homePage.ClickOnRandomMeInteresaButton();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}