using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TestCases.Base;

public class TestBase
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        try
        {
            string configFilePath = "C:\\Projects\\Repositories\\Git\\TestCases\\TicketShopTestCases\\Configuration\\config.xml"; 

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("The file configuration was not found in the specific path.");
            }

            XDocument xmlDoc = XDocument.Load(configFilePath);
            XElement? appSettings = xmlDoc.Descendants("appSettings").FirstOrDefault();

            string? browserName = appSettings?.Element("add[@key='browser']")?.Attribute("value")?.Value;
            //string? url = appSettings?.Element("add[@key='url']")?.Attribute("value")?.Value;
            
            if (browserName != null && browserName.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
                
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

