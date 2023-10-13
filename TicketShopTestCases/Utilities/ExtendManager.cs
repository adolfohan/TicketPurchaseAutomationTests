﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestCases.Utilities;

public abstract class ExtentManager
{
    private static ExtentReports extent;

    private static readonly string baseReportDirectory =
        @"C:\Projects\Repositories\Git\TestCases\TicketShopTestCases\Reports";

    public static ExtentReports GetExtent(string testName)
    {
        if (extent != null) return extent;
        var reportDirectory = baseReportDirectory;//Path.Combine(baseReportDirectory, DateTime.Now.ToString("yyyyMMdd"));
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
    }
    
    
}