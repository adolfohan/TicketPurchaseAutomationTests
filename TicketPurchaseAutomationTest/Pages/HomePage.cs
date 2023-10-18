using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;
using TicketPurchaseAutomationTest.Utilities;

namespace TicketPurchaseAutomationTest.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {

    }

    private By pageSize20Element = By.XPath("//a[contains(text(), '20')]");
    private By meInteresaButton =>
        By.XPath(
            "//a[contains(@class, 'sv-button sv-button--type-contained sv-button--size-sm sv-button--color-primary') and contains(text(), 'Me interesa')]");

    public void NavigateToUrl()
    {
        try
        {
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

    private void PressPageSize20()
    {
        IWebElement pageSize20 = fluentWait.Until(ExpectedConditions.ElementIsVisible(pageSize20Element));
        ScrollIntoView(pageSize20);
        pageSize20.Click();
    }
    
    public TicketsSelectionPage ClickOnRandomMeInteresaButton()
    {
        IList<IWebElement> meInteresaButtons = driver.FindElements(meInteresaButton);

        if (meInteresaButtons.Count > 0)
        {
            var randomIndex = new Random().Next(0, meInteresaButtons.Count);
            var buttonToClick = meInteresaButtons[randomIndex];

            ScrollIntoView(buttonToClick);

            fluentWait.Until(ExpectedConditions.ElementToBeClickable(buttonToClick));
            
            //TestUtil.DrawBorder(buttonToClick);

            buttonToClick.SendKeys(Keys.Enter);
            //buttonToClick.Click();

            return new TicketsSelectionPage(driver);
        }
        else
        {
            throw new NoSuchElementException("No 'Me interesa' buttons found on the page.");
        }
    }
}