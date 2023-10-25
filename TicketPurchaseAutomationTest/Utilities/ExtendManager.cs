using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TicketPurchaseAutomationTest.Utilities;

public abstract class ExtentManager
{
    private static ExtentReports extent;
    private static readonly string baseReportDirectory = "Reports";

    //private static readonly string baseReportDirectory =
    //    @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Reports";
    //Environment.GetEnvironmentVariable("REPORT_PATH");

    public static string GetReportPath(string testName)
    {
        var workingDirectory = Environment.GetEnvironmentVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        var reportDirectory = Path.Combine(workingDirectory, baseReportDirectory);
        if (!Directory.Exists(reportDirectory))
        {
            Directory.CreateDirectory(reportDirectory);
        }

        var reportFileName = $"report_{testName}_{DateTime.Now:yyyyMMddHHmmss}.html";
        return Path.Combine(reportDirectory, reportFileName);
    }

    public static ExtentReports? GetExtent(string testName)
    {
        if (extent != null) return extent;

        var reportPath = GetReportPath(testName);

        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);

        extent.AddSystemInfo("Tester", "Adolfo");
        extent.AddSystemInfo("Environment", "Pre-Producción");
        return extent;
    }


    /*public static ExtentReports? GetExtent(string testName)
    {
        if (extent != null) return extent;
        var reportDirectory =
            baseReportDirectory; //Path.Combine(baseReportDirectory, DateTime.Now.ToString("yyyyMMdd"));
        if (!Directory.Exists(reportDirectory))
        {
            Directory.CreateDirectory(reportDirectory);
        }

        var reportFileName = $"report_{testName}_{DateTime.Now:yyyyMMddHHmmss}.html";
        var reportPath = Path.Combine(reportDirectory, reportFileName);

        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);

        extent.AddSystemInfo("Tester", "Adolfo");
        extent.AddSystemInfo("Environment", "Pre-Producción");
        return extent;
    }*/
    
    
}