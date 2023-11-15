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
            homePage.ClickOnAllLeisureFamiliesFilters();
            
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
            homePage.DeselectAllLeisureFamiliesFilters();
            
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
    
    /*[Test, Order(11)]
    public void LeisureParksTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Leisure Parks Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Leisure Parks Filter");
            currentStep = "Step ClickOnLeisureParksFilter";
            homePage.ClickOnLeisureParksFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(12)]
    public void CultureVisitsToursTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Culture Visits and Tours Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Culture Visits and Tours Filter");
            currentStep = "Step ClickOnCultureVisitsToursFilter";
            homePage.ClickOnCultureVisitsToursFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(13)]
    public void ExcursionsAndTouristsMobilityTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Excursions and Tourists Mobility Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Excursions and Tourists Mobility Filter");
            currentStep = "Step ClickOnExcursionsTouristsMobilityFilter";
            homePage.ClickOnExcursionsTouristsMobilityFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(14)]
    public void ExperiencesAndRelaxTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Experiences and Relax Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Experiences and Relax Filter");
            currentStep = "Step ClickOnExperiencesRelaxFilter";
            homePage.ClickOnExperiencesRelaxFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(15)]
    public void GastronomyAndWineTourismTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Gastronomy and Wine Tourism Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Gastronomy and Wine Tourism Filter");
            currentStep = "Step ClickOnGastronomyWineTourismFilter";
            homePage.ClickOnGastronomyWineTourismFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(16)]
    public void MusicalsAndShowsTicketHanPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Musicals and Shows Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Musicals and Shows Filter");
            currentStep = "Step ClickOnMusicalsShowFilter";
            homePage.ClickOnMusicalsShowFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(17)]
    public void SportsTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Sports Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Sports Filter");
            currentStep = "Step ClickOnSportsFilter";
            homePage.ClickOnSportsFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(18)]
    public void ActiveTourismTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Active Tourism Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Active Tourism Filter");
            currentStep = "Step ClickOnActiveTourismFilter";
            homePage.ClickOnActiveTourismFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(19)]
    public void SnowTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Snow Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Snow Filter");
            currentStep = "Step ClickOnSnowFilter";
            homePage.ClickOnSnowFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(20)]
    public void CinemaAndDriveInTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Cinema and Drive-in Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Cinema and Drive-in Filter");
            currentStep = "Step ClickOnCinemaDriveInFilter";
            homePage.ClickOnCinemaDriveInFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(21)]
    public void HalloweenTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Halloween Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Halloween Filter");
            currentStep = "Step ClickOnHalloweenFilter";
            homePage.ClickOnHalloweenFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(22)]
    public void EscapeRoomExperiencesTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Escape Room Experiences Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Escape Room Experiences Filter");
            currentStep = "Step ClickOnEscapeRoomExperiencesFilter";
            homePage.ClickOnEscapeRoomExperiencesFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(23)]
    public void SpainFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Spain Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Spain Filter");
            currentStep = "Step ClickOnSpainFilter";
            homePage.ClickOnSpainFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(24)]
    public void AndorraFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Andorra Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Andorra Filter");
            currentStep = "Step ClickOnAndorraFilter";
            homePage.ClickOnAndorraFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(25)]
    public void FranceFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting France Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On France Filter");
            currentStep = "Step ClickOnFranceFilter";
            homePage.ClickOnFranceFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(26)]
    public void GibraltarFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Gibraltar Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Gibraltar Filter");
            currentStep = "Step ClickOnGibraltarFilter";
            homePage.ClickOnGibraltarFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(27)]
    public void ItalyFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Italy Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Italy Filter");
            currentStep = "Step ClickOnItalyFilter";
            homePage.ClickOnItalyFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(28)]
    public void PortugalFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Portugal Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On Portugal Filter");
            currentStep = "Step ClickOnPortugalFilter";
            homePage.ClickOnPortugalFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(29)]
    public void UnitedKingdomFilterTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting United Kingdom Filter Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();
            
            LogStep(Status.Info, "Clicked On United Kingdom Filter");
            currentStep = "Step ClickOnUnitedKingdomFilter";
            homePage.ClickOnUnitedKingdomFilter();

            CommonNormalPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }*/

}