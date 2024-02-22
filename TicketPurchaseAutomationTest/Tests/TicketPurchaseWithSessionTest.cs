using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class TicketPurchaseWithSessionTest : BaseTest
{
    [Test]
    public void SessionTest()
    {
        try
        {
            LogStep(Status.Info, "Navigating to URL");
            CurrentStep = "Step GoToURL";
            HomePage!.NavigateToSessionUrl();
            
            CommonSessionPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

}