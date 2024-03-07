﻿using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class CardPage(IWebDriver? driver) : BasePage(driver)
{
    private readonly By pagarBtnElement = By.XPath("/html/body/div[1]/div[2]/div[3]/form/div/div[2]/div[8]/button[2]");
    private readonly By enviarBtnElement = By.Id("boton");
    private readonly By continuarBtnElement = By.XPath("/html/body/div[1]/form/div[2]/div[3]/div[2]/div[1]/input[2]");

    public void CompleteCardInformation(string cardNumber, string expirationMonth, string expirationYear, string securityCode)
{
    var cardInfo = new Dictionary<By, string>
    {
        { By.XPath("//*[@id=\"inputCard\"]"), cardNumber },
        { By.XPath("//*[@id=\"cad1\"]"), expirationMonth },
        { By.XPath("//*[@id=\"cad2\"]"), expirationYear },
        { By.XPath("//*[@id=\"codseg\"]"), securityCode }
    };

    foreach (var field in cardInfo)
    {
        try
        {
            var element = FluentWait.Until(ExpectedConditions.ElementIsVisible(field.Key));
            ClearAndSetInputValue(element, field.Value);
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
}
    
    public void ClickOnPagarButton()
    {
        try
        {
            var pagarButton = FluentWait.Until(ExpectedConditions.ElementToBeClickable(pagarBtnElement));
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
            var enviarButton = FluentWait.Until(ExpectedConditions.ElementToBeClickable(enviarBtnElement));
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
    
    public void ClickOnContinuarButton()
    {
        try
        {
            var continuarButton = FluentWait.Until(ExpectedConditions.ElementToBeClickable(continuarBtnElement));
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
    }

    public bool IsPurchaseUnsuccessful()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.AlertIsPresent());

            var alert = Driver!.SwitchTo().Alert();

            var text = alert.Text;

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