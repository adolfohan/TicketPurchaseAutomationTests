﻿using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

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
    
    public void ClickOnPagarButton()
    {
        try
        {
            IWebElement pagarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(pagarBtnElement));
            pagarButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public void ClickOnEnviarButton()
    {
        try
        {
            IWebElement enviarButton = fluentWait.Until(ExpectedConditions.ElementToBeClickable(enviarBtnElement));
            enviarButton.Click(); 
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public PurchaseOkPage ClickOnContinuarButton()
    {
        try
        {
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

    public bool IsPurchaseUnsuccessful()
    {
        try
        {
            fluentWait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alert = driver.SwitchTo().Alert();

            string text = alert.Text;

            if (!text.Contains("Debe Introducir un número de tarjeta válido (sin espacios ni guiones).")) return false;
            alert.Accept();
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}