using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class FiltersTest : BaseTest
{
    
    [Test, Order(1)]
    public void SelectAllFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on All Filters");
            currentStep = "Step ClickOnAllFilters";
            homePageSteps.ClickOnAllFilters();
            
            LogStep(Status.Info, "Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(2)]
    public void DeselectFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();
            
            LogStep(Status.Info, "Deselected All Filter");
            currentStep = "Step DeselectAllFilters";
            homePageSteps.DeselectAllFilters();
            
            LogStep(Status.Info, "Deselect Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(3)]
    public void ClickOnAllCountryFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Countries Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();

            LogStep(Status.Info, "Clicked on All Countries Filters");
            currentStep = "Step ClickOnAllFilters";
            homePage.ClickOnAllCountryFilters();
            
            LogStep(Status.Info, "Select All Countries Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(4)]
    public void DeselectAllCountryFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Countries Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();

            LogStep(Status.Info, "Deselected All Countries Filter");
            currentStep = "Step DeselectAllCountryFilters";
            homePage.DeselectAllCountryFilters();
            
            LogStep(Status.Info, "Deselect All Countries Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

}