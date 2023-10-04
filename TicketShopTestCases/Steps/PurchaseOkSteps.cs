using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class PurchaseOkSteps
{
    private readonly PurchaseOkPage purchaseOkPage;

    public PurchaseOkSteps(IWebDriver driver)
    {
        purchaseOkPage = new PurchaseOkPage(driver);
    }
    
    [Then(@"should be able to see a 'Gracias por tu compra' message")]

    public void PurchaseOkMessage()
    {
        purchaseOkPage.PurchaseOkVerificationMessage();
    }

}