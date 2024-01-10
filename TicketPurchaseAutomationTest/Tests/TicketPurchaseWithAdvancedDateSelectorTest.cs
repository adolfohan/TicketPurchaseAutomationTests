using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class TicketPurchaseWithAdvancedDateSelectorTest : BaseTest
{
    [Test]
    public void AdvancedDateSelectorTest()
    {
        try
        {
            LogStep(Status.Info, "Navigating to URL");
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToAdvancedDateSelectorUrl();
        
            CommonAdvancedDateSelectorPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
}