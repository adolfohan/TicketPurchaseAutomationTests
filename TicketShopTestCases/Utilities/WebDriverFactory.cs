using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestCases.Utilities;

public class WebDriverFactory
{
    public static IWebDriver CreateWebDriver()
    {
        return new ChromeDriver();
    }
}