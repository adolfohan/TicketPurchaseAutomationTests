using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TicketPurchaseAutomationTest.Base;

public class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly DefaultWait<IWebDriver> FluentWait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        FluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(30),
            PollingInterval = TimeSpan.FromSeconds(2)
        };
        FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        FluentWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
    }
    
    protected void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }

    protected void ScrollIntoView(IWebElement element)
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element); //{behavior: 'auto', block: 'center'}
    }

    protected void CheckValidity(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        bool isInvalid = (bool)js.ExecuteScript("return arguments[0].checkValidity();", element);
        
        Assert.That(isInvalid, Is.True, "The input text is invalid as expected.");
    }
    
    protected void DrawBorder(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
        js.ExecuteScript("arguments[0].style.border='2px solid red'", element);
    }

    protected void ClickByJs(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
        js.ExecuteScript("arguments[0].click();", element);
    }
}