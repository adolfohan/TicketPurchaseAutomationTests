using NUnit.Framework;
using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;
public class CardSteps
{
    private readonly CardPage cardPage;

    public CardSteps(IWebDriver driver)
    {
        cardPage = new CardPage(driver);
    }
    public void CompleteTheCardInformation()
    {
        cardPage.CompleteCardInformation("4548810000000003", "12", "49", "123");
    }
    
    public void ClickOnPagarButton()
    {
        cardPage.ClickOnPagarButton();
    }
    
    public void ClickOnEnviarButton()
    {
        cardPage.ClickOnEnviarButton();
    }
    
    public void ClickOnContinuarButton()
    {
        cardPage.ClickOnContinuarButton();
    }
    
    public void CompleteTheCardWithWrongInformation()
    {
        cardPage.CompleteCardInformation("123456789", "12", "49", "123");
    }
    
    public void ThenTheTicketPurchaseShouldBeUnsuccessful()
    {
        bool isPurchaseUnsuccessful = cardPage.IsPurchaseUnsuccessful();
        
        Assert.That(isPurchaseUnsuccessful, Is.True, "The ticket purchase should be unsuccessful.");
    }
}
