﻿using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestCases.Base;
using TestCases.Utilities;

namespace TestCases.Pages;

public class CardPage : BasePage
{
    private readonly By pagarBtnElement = By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[2]");
    private readonly By enviarBtnElement = By.Id("boton");
    private readonly By continuarBtnElement = By.XPath("/html/body/div[1]/form/div[2]/div[3]/div[2]/div[1]/input[2]");
    
    public CardPage(IWebDriver driver) : base(driver)
    {
    }
    
    public void CompleteCardInformation(string cardNumber, string expirationMonth, string expirationYear,
        string securityCode)
    {
        try
        {
            // Create a dictionary to map field names to values
            var cardInfo = new Dictionary<string, string>
            {
                { "//*[@id=\"inputCard\"]", cardNumber },
                { "//*[@id=\"cad1\"]", expirationMonth },
                { "//*[@id=\"cad2\"]", expirationYear },
                { "//*[@id=\"codseg\"]", securityCode }
            };

            foreach (var field in cardInfo)
            {
                var element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(field.Key)));
                ClearAndSetInputValue(element, field.Value);
            }
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while entering card information: {ex.Message}");
        }
    }
    
    public PurchaseOkPage ClickPagarButton()
    {
        try
        {
            IWebElement pagarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(pagarBtnElement));
            pagarButton.Click(); 
            
            IWebElement enviarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(enviarBtnElement));
            enviarButton.Click(); 
            
            IWebElement continuarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(continuarBtnElement));
            continuarButton.Click(); 
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return new PurchaseOkPage(driver);
    }
}