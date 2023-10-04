using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;
using TestCases.Utilities;

namespace TestCases.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {

    }

    private By MeInteresaButton =>
        By.XPath(
            "//a[contains(@class, 'sv-button sv-button--type-contained sv-button--size-sm sv-button--color-primary') and contains(text(), 'Me interesa')]");

    public void NavigateToUrl()
    {
        try
        {
            string? baseUrl = ConfigReader.GetBaseUrl();
            driver.Navigate().GoToUrl(baseUrl);
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

    public TicketsSelectionPage ClickOnRandomMeInteresaButton()
    {
        IList<IWebElement> meInteresaButtons = driver.FindElements(MeInteresaButton);

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