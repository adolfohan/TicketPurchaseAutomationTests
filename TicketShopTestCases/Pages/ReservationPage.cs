using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCases.Pages;

public class ReservationPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public ReservationPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement MessageElement =>
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/section/div/div[2]/div/div[1]")));

    public void ClickReservationButton()
    {
        driver.FindElement(By.Id("pm4")).Click();
    }
}