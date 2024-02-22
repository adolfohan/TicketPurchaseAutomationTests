using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class PurchaseOkSteps(IWebDriver? driver)
{
    private readonly PurchaseOkPage purchaseOkPage = new(driver);


    public void PurchaseOkMessage()
    {
        purchaseOkPage.PurchaseOkVerificationMessage();
    }

}