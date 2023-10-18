using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class PurchaseOkSteps
{
    private readonly PurchaseOkPage purchaseOkPage;

    public PurchaseOkSteps(IWebDriver driver)
    {
        purchaseOkPage = new PurchaseOkPage(driver);
    }
    

    public void PurchaseOkMessage()
    {
        purchaseOkPage.PurchaseOkVerificationMessage();
    }

}