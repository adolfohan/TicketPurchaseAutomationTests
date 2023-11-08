using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class TicketsSelectionPage : BasePage
{
    private readonly HomePage homePage;
    private readonly Random random;
    
    private By inputNumberOfTicketsElement =>
        By.XPath("//input[@type='number']");
    
    private readonly By confirmationButtonElement =
        By.XPath("//button[@class='btn sv-button--type-contained sv-button--color-secondary']");
    
    private readonly By comprarButton =
        By.CssSelector(
            "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");

    //private readonly By priceElement = By.ClassName("sv-cart__price");
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");
    private readonly By step2Element = By.XPath("//span[text()='Configura tus actividades']");
    private readonly By panelWrapperElement = By.CssSelector("a.sv-panel__wrapper[aria-expanded='false']");
    private readonly By navBarElement = By.Id("funnelmenu");
    public TicketsSelectionPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
        homePage = new HomePage(driver);
    }
    
    public void SelectNumberOfTickets(string numberOfTickets)
    {
        
        try
        {
            while (true)
            {
                IList<IWebElement> inputFields =
                    fluentWait.Until(webDriver => webDriver.FindElements(inputNumberOfTicketsElement));
                
                IList<IWebElement> panelWrapper = fluentWait.Until(webDriver => webDriver.FindElements(panelWrapperElement));

                if (panelWrapper.Count > 0)
                {
                    foreach (IWebElement element in panelWrapper)
                    {
                        element.Click();
                    }
                }

                /*if (inputFields.Count > 0)

                    fluentWait.Until(webDriver =>
                        ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));*/

                if (inputFields.Count > 0)
                {
                    var randomIndex = random.Next(0, inputFields.Count);
                    var selectedInputField = inputFields[randomIndex];

                    while (!selectedInputField.Displayed)
                    {
                        randomIndex = random.Next(0, inputFields.Count);
                        selectedInputField = inputFields[randomIndex];
                    }

                    ScrollIntoView(selectedInputField);
                    ClearAndSetInputValue(selectedInputField, numberOfTickets);
                    break;
                }

                driver.Navigate().Back();
                homePage.ClickOnRandomMeInteresaButton();
                SelectNumberOfTickets(numberOfTickets);

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public void ConfirmDate()
    {
        IWebElement confirmationBox = fluentWait.Until(ExpectedConditions.ElementIsVisible(confirmationButtonElement));

        IWebElement confirmButton = confirmationBox.FindElement(confirmationButtonElement);
        confirmButton.Click();
    }
    
    public void ClickOnComprarButton()
    {
        try
        {
            IWebElement comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
            comprarBtn.Click();
            IWebElement error500Message = fluentWait.Until(ExpectedConditions.ElementIsVisible(error500Element));
            while (error500Message.Displayed)
            {
                driver.Navigate().Back();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                IWebElement comprarBtn1 = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
                comprarBtn1.Click();
            }
            if (!HaveSession())
            {
                Console.WriteLine("No session. Continue with the next step...");
            }
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

    private bool HaveSession()
    {
        IWebElement step2Title = fluentWait.Until(ExpectedConditions.ElementIsVisible(step2Element));
        IWebElement comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
        
        if (step2Title.Displayed)
        {
            Thread.Sleep(2000);
            comprarBtn.Click();
            return true;
        }
        return false;
    }

    public void SelectRandomNavBar()
    {
        IWebElement navBar = fluentWait.Until(ExpectedConditions.ElementToBeClickable(navBarElement));
        IWebElement input = fluentWait.Until(ExpectedConditions.ElementToBeClickable(inputNumberOfTicketsElement));
        IList<IWebElement> navBarItems = navBar.FindElements(By.CssSelector("li.nav-item"));    

        if (navBarItems.Count > 0)
        {
            do
            {
                var randomIndex = random.Next(0, navBarItems.Count);
                var selectedNavBarItem = navBarItems[randomIndex];
                selectedNavBarItem.Click();
            } while (!input.Displayed);
        }
        
        /*while (true)
        {
            //bool inputVisible = ;

            if (IsElementVisible(inputNumberOfTicketsElement))
            {
                IWebElement navBar = fluentWait.Until(ExpectedConditions.ElementToBeClickable(navBarElement));
                IList<IWebElement> navBarItems = navBar.FindElements(By.CssSelector("li.nav-item"));

                if (navBarItems.Count > 0)
                {
                    var randomIndex = random.Next(0, navBarItems.Count);
                    var selectedNavBarItem = navBarItems[randomIndex];
                    selectedNavBarItem.Click();
                }
                break;
            }
            {
                driver.Navigate().Back();
                homePage.ClickOnRandomMeInteresaButton();
            }
        }*/
    }
    
    private bool IsElementVisible(By elementSelector)
    {
        try
        {
            IWebElement element = fluentWait.Until(ExpectedConditions.ElementIsVisible(elementSelector));
            return element.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}