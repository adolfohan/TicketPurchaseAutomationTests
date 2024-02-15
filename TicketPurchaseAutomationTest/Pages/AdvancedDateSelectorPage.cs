﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class AdvancedDateSelectorPage : BasePage
{
    private readonly Random random;
    
    private readonly By sessionMessageElement = By.XPath("//span[text()=' Selecciona la sesión ']");
    private readonly By chosenDateElement = By.XPath("//label[text()='Fecha elegida']");
    private readonly By comprarButtonElement = By.XPath(
        "//button[@class='sv-button sv-button--type-contained sv-button--color-primary sv-button--size-lg sv-button--buy j-button-buy']");
    private readonly By radioButtonElement = By.XPath("//span[contains(text(),'Hemisfèric')]/following::input[@type='radio'][1]");
    private readonly By sessionDropdownElement = By.XPath("//span[contains(text(),'Hemisfèric')]/following::select[@class='form-select form-select-sm' and not(@disabled)]");
    private readonly By advancedDateSelectorElement = By.ClassName("sv-tickets__actions");
    private const string ExpectedSessionMessage = "Selecciona la sesión";
    private const string ExpectedChosenDateMessage = "Fecha elegida";

    public AdvancedDateSelectorPage(IWebDriver driver) : base(driver)
    {
        random = new Random();
    }
    
    public void HasAdvancedDateSelector()
    {
        IWebElement element = FluentWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='sv-tickets__actions']")));
        try
        {
            /*string needsAdvancedDateSelectorValue = element.GetAttribute("productname");
            Console.WriteLine($"Valor de 'needsadvanceddateselector': {needsAdvancedDateSelectorValue}");
            Console.WriteLine($"HTML del elemento: {element.GetAttribute("productname")}");*/
            var script = "return arguments[0].getAttribute('productname');";
            var attribute = (string)((IJavaScriptExecutor)Driver).ExecuteScript(script, element);
            Console.WriteLine($"Valor del atributo: {attribute}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el atributo. Detalles: {ex.Message}");
        }
    }
    public bool VerifyAdvancedSelectorMessage()
    {
        Thread.Sleep(2000);
        IWebElement sessionMessage = FluentWait.Until(ExpectedConditions.ElementIsVisible(sessionMessageElement));
        //IWebElement choseDateMessage = FluentWait.Until(ExpectedConditions.ElementIsVisible(chosenDateElement));
        string message = sessionMessage.Text;
        //string dateMessage = choseDateMessage.Text;
        Assert.That(message.Equals(ExpectedSessionMessage), "The messages do not match the expected messages"); //dateMessage.Equals(ExpectedChosenDateMessage) && 
        return true;
    }

    public void SelectTitle()
    {
        try
        {
            //Thread.Sleep(2000);
            IList<IWebElement> radioButtons = FluentWait.Until(webDriver => webDriver.FindElements(radioButtonElement));

            if (radioButtons.Count > 0)
            {
                var randomRadioIndex = random.Next(0, radioButtons.Count);
                var randomRadio = radioButtons[randomRadioIndex];
                randomRadio.SendKeys(Keys.Space);
            }
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
    
    public void SelectSessionHour()
    {
        try
        {
            //Thread.Sleep(2000);
            IWebElement dropdown = FluentWait.Until(ExpectedConditions.ElementToBeClickable(sessionDropdownElement));

            var select = new SelectElement(dropdown);
            IList<IWebElement> options = select.Options;

            if (options.Count <= 0) return;

            var randomIndex = random.Next(1, options.Count);

            select.SelectByIndex(randomIndex);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
    }
    
    public void ClickOnComprarButton()
    {
        try
        {
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButtonElement)).Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking on 'Comprar' button in Advanced Date Selector Page: {ex.Message}");
        }
    }
}