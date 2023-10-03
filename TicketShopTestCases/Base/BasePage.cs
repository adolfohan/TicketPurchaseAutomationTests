using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestCases.Base;

public class BasePage
{
    protected IWebDriver driver;
    protected readonly DefaultWait<IWebDriver> fluentWait;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        fluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(30),
            PollingInterval = TimeSpan.FromSeconds(2)
        };
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
    }
    
    public void ClearAndSetInputValue(IWebElement inputField, string value)
    {
        inputField.Clear();
        inputField.SendKeys(value);
    }

    public void ScrollIntoView(IWebElement element)
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element); //{behavior: 'auto', block: 'center'}
    }
}