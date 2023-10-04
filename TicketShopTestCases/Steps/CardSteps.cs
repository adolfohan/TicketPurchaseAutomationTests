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

    [When(@"clicks the ""Pagar"" button")]
    public void ClickPagarButton()
    {
        cardPage.ClickPagarButton();
    }
/*
    [When(@"clicks the ""Enviar"" button")]
    public void ClickThEnviarButton()
    {
        cardPage.ClickEnviarButton();
    }

    [When(@"clicks the ""Continuar"" button")]
    public void ClickThContinuarButton()
    {
        cardPage.ClickContinuarButton();
    }*/
}