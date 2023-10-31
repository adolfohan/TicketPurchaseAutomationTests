using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TicketPurchaseAutomationTest.Utilities;

public abstract class ExtentManager
{
    private static ExtentReports? _extent;
    //private static readonly string baseReportDirectory = @"$(Build.ArtifactStagingDirectory)\TicketPurchaseAutomationTest\Reports";

    private const string BaseReportDirectory = @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Reports";


    public static ExtentReports GetExtent(string testName)
    {
        if (_extent != null) return _extent;

        //var reportDirectory = GetReportDirectory(); //Path.Combine(baseReportDirectory, DateTime.Now.ToString("yyyyMMdd"));
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
        return _extent;
    }

    private static string GetReportDirectory()
    {
        var artifactStagingDirectory = Environment.GetEnvironmentVariable("REPORT_PATH");

        return string.IsNullOrEmpty(artifactStagingDirectory) ? BaseReportDirectory : artifactStagingDirectory;
    }
}    