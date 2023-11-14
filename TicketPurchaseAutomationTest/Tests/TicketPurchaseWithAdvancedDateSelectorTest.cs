using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

public class TicketPurchaseWithAdvancedDateSelectorTest : BaseTest
{
    [Test]
    public void AdvancedDateSelectorTest()
    {
        try
        {
            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToAdvancedDateSelectorUrl();
        
            CommonAdvacedDateSelectorPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
}