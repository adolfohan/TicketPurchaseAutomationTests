using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestCases.Utilities;

namespace TestCases.Pages;

public class HomePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
    }

    private By MeInteresaButton =>
        By.XPath(
            "//a[contains(@class, 'sv-button sv-button--type-contained sv-button--size-sm sv-button--color-primary') and contains(text(), 'Me interesa')]");

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

    public void ClickRandomMeInteresaButton()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var meInteresaButtons = driver.FindElements(MeInteresaButton);

        if (meInteresaButtons.Count > 0)
        {
            var randomIndex = new Random().Next(0, meInteresaButtons.Count);
            var buttonToClick = meInteresaButtons[randomIndex];

            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'auto', block: 'center'});",
                buttonToClick);

            wait.Until(ExpectedConditions.ElementToBeClickable(buttonToClick));

            buttonToClick.SendKeys(Keys.Enter);
        }
        else
        {
            throw new NoSuchElementException("No 'Me interesa' buttons found on the page.");
        }
    }
}