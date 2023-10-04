using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class CardSteps
{
    private readonly CardPage cardPage;

    public CardSteps(IWebDriver driver)
    {
        cardPage = new CardPage(driver);
    }
    
    [When(@"completes the card information")]
    public void CompleteTheCardInformation()
    {
        cardPage.CompleteCardInformation("4548810000000003", "12", "49", "123");
    }
    
    [When(@"clicks on the ""Pagar"" button")]
    public void ClickOnPagarButton()
    {
        cardPage.ClickOnPagarButton();
    }

    [When(@"clicks on the ""Enviar"" button")]
    public void ClickOnEnviarButton()
    {
        cardPage.ClickOnEnviarButton();
    }

    [When(@"clicks on the ""Continuar"" button")]
    public void ClickOnContinuarButton()
    {
        cardPage.ClickOnContinuarButton();
    }
    
    [When(@"completes with wrong card number")]
    public void CompleteTheCardWithWrongInformation()
    {
        cardPage.CompleteCardInformation("123456789", "12", "49", "123");
    }
    
    [Then(@"the ticket purchase should be unsuccessful")]
    public void ThenTheTicketPurchaseShouldBeUnsuccessful()
    {
        bool isPurchaseUnsuccessful = cardPage.IsPurchaseUnsuccessful();
        
        Assert.That(isPurchaseUnsuccessful, Is.True, "The ticket purchase should be unsuccessful.");
    }
}
