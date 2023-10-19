using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TicketPurchaseAutomationTest.Base;

public class BasePage
{
    protected IWebDriver driver;
    protected readonly DefaultWait<IWebDriver> fluentWait;

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
        fluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(60),
            PollingInterval = TimeSpan.FromSeconds(2)
        };
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
    }
    
    protected void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }

    protected void ScrollIntoView(IWebElement element)
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element); //{behavior: 'auto', block: 'center'}
    }

    protected void CheckValidity(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        bool isInvalid = (bool)js.ExecuteScript("return arguments[0].checkValidity();", element);
        
        Assert.That(isInvalid, Is.False, "The input text is invalid");
    }
    
    protected void DrawBorder(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("arguments[0].style.border='2px solid red'", element);
    }

    protected void ClickByJS(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("arguments[0].click();", element);
    }
}