using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace TicketPurchaseAutomationTest.Utilities;

public abstract class ExtentManager
{
    private static ExtentReports? _extent;
    
    private static readonly string BaseReportDirectory = Path.Combine(Environment.GetEnvironmentVariable("SourceDirectory") ?? @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\", "Reports");
    public static ExtentReports GetExtent(string testName)
    {
        if (_extent != null) return _extent;
        
        if (!Directory.Exists(BaseReportDirectory))
        {
            Directory.CreateDirectory(BaseReportDirectory);
        }

        var reportFileName = $"report_{testName}_{DateTime.Now:yyyy-MM-dd-HHmmss}.html";
        var reportPath = Path.Combine(BaseReportDirectory, reportFileName);

        var htmlReporter = new ExtentSparkReporter(reportPath);
        _extent = new ExtentReports();
        _extent.AttachReporter(htmlReporter);

        _extent.AddSystemInfo("Tester", "Adolfo");
        _extent.AddSystemInfo("Environment", "Pre-Producción");
        
        htmlReporter.Config.Theme = Theme.Dark;
        htmlReporter.Config.DocumentTitle = testName + " Report";
        htmlReporter.Config.ReportName = testName + " Test Report";

        CleanUpOldSReports();
            
        return _extent;
    }
    
    private static void CleanUpOldSReports()
    {
        const string reportsDirectory = @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Reports";
        var screenshotFiles = Directory.GetFiles(reportsDirectory, "report*.html");

        const int maxReportsToKeep = 10;

        if (screenshotFiles.Length <= maxReportsToKeep) return;
        Array.Sort(screenshotFiles);
        for (var i = 0; i < screenshotFiles.Length - maxReportsToKeep; i++)
        {
            File.Delete(screenshotFiles[i]);
        }
    }
}    