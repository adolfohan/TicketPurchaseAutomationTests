using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class TicketsSelectionPage(IWebDriver driver) : BasePage(driver)
{
    private readonly HomePage homePage = new(driver);
    private readonly Random random = new();
    private readonly SessionPage sessionPage = new(driver);
    private readonly AdvancedDateSelectorPage advancedDateSelectorPage = new(driver);
    private readonly Error500Page error500Page = new(driver);
    
    
    private By inputNumberOfTicketsElement =>
        By.XPath("//input[@type='number']");
    
    private readonly By confirmationButtonElement =
        By.XPath("//button[@class='btn sv-button--type-contained sv-button--color-secondary']");
    
    private readonly By comprarButton =
        By.CssSelector(
            "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    private readonly By error500Element = By.XPath("//div[@class='sv-page404__title' and text()='Error 500']");
    //private readonly By priceElement = By.ClassName("sv-cart__price");
    private readonly By panelWrapperElement = By.XPath("//a[@class='collapsed sv-panel__wrapper' and @aria-expanded='false']");//By.CssSelector("a.sv-panel__wrapper[aria-expanded='false']");
    private readonly By navBarElement = By.Id("funnelmenu");
    private readonly By sessionMessageElement = By.XPath("//div[@class='s-panel-sessions__heading']");

    private void ClickOnPanelWrapper()
    {
        IWebElement panel = fluentWait.Until(ExpectedConditions.ElementIsVisible(panelWrapperElement));

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
            while (true)
            {
                IList<IWebElement> inputFields =
                    fluentWait.Until(webDriver => webDriver.FindElements(inputNumberOfTicketsElement));
               
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
            
            while (error500Page.Error500Displayed())
            {
                driver.Navigate().Back();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                IWebElement comprarBtn1 = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
                comprarBtn1.Click();
            }

            //error500Page.Error500Displayed();
            
            /*Thread.Sleep(TimeSpan.FromSeconds(5));

            string pageSource = driver.PageSource;

            switch (true)
            {
                case var _ when pageSource.Contains("Error 500"):
                    error500Page.Error500Displayed();
                    break;
                
                case var _ when pageSource.Contains("Selecciona la sesión"):
                    if (sessionPage.VerifySessionMessage())
                    {
                        sessionPage.SelectSession();
                        sessionPage.ClickOnComprarButton();
                    }
                    break;
                
                case var _ when pageSource.Contains("Fecha elegida") && pageSource.Contains("Selecciona la sesión"):
                    if (advancedSelectorPage.VerifyAdvancedSelectorMessage())
                    {
                        advancedSelectorPage.SelectTitle();
                        advancedSelectorPage.SelectSessionHour();
                        advancedSelectorPage.ClickOnComprarButton();
                    }
                    break;
            }*/
            /*
            IWebElement error500Message = fluentWait.Until(ExpectedConditions.ElementIsVisible(error500Element));
            while (error500Message.Displayed)
            {
                driver.Navigate().Back();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                IWebElement comprarBtn1 = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButton));
                comprarBtn1.Click();
            }*/
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

    public void SelectRandomNavBar()
    {
        try
        {
            while (true)
            {
                IList<IWebElement> inputFields =
                    fluentWait.Until(webDriver => webDriver.FindElements(inputNumberOfTicketsElement));
                if (inputFields.Count > 0)
                {
                    IWebElement navBar = fluentWait.Until(ExpectedConditions.ElementToBeClickable(navBarElement));
                    IList<IWebElement> navBarItems = navBar.FindElements(By.CssSelector("li.nav-item"));
                    while (navBarItems.Count > 0 && inputFields.Count > 0)
                    {
                        var randomIndex = random.Next(0, navBarItems.Count);
                        var selectedNavBarItem = navBarItems[randomIndex];
                        selectedNavBarItem.Click();
                    }
                }
                driver.Navigate().Back();
                homePage.ClickOnRandomMeInteresaButton();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}