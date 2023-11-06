using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class HomePageSteps
{
    private readonly HomePage homePage;

    public HomePageSteps(IWebDriver driver)
    {
        homePage = new HomePage(driver);
    }
    
    public void GoToURL()
    {
        homePage.NavigateToUrl();
    }

    public void Press20Size()
    {
        homePage.PressPageSize20();
    }
    
    public void ClickOnRandomMeInteresaButton()
    {
        homePage.ClickOnRandomMeInteresaButton();
    }

    public void ClickOnLeisureParksFilter()
    {
        homePage.ClickOnLeisureParksFilter();
    }
    
    public void ClickOnCultureVisitsToursFilter()
    {
        homePage.ClickOnCultureVisitsToursFilter();
    }
    
    public void ClickOnExcursionsTouristsMobilityFilter()
    {
        homePage.ClickOnExcursionsTouristsMobilityFilter();
    }
    
    public void ClickOnExperiencesRelaxFilter()
    {
        homePage.ClickOnExperiencesRelaxFilter();
    }
    
    public void ClickOnGastronomyWineTourismFilter()
    {
        homePage.ClickOnGastronomyWineTourismFilter();
    }
    
    public void ClickOnMusicalsShowFilter()
    {
        homePage.ClickOnMusicalsShowFilter();
    }
    
    public void ClickOnSportsFilter()
    {
        homePage.ClickOnSportsFilter();
    }
    
    public void ClickOnActiveTourismFilter()
    {
        homePage.ClickOnActiveTourismFilter();
    }
    
    public void ClickOnSnowFilter()
    {
        homePage.ClickOnSnowFilter();
    }
    
    public void ClickOnCinemaDriveInFilter()
    {
        homePage.ClickOnCinemaDriveInFilter();
    }
    
    public void ClickOnHalloweenFilter()
    {
        homePage.ClickOnHalloweenFilter();
    }
    
    public void ClickOnEscapeRoomExperiencesFilter()
    {
        homePage.ClickOnEscapeRoomExperiencesFilter();
    }
    
    public void ClickOnAllFilters()
    {
        homePage.ClickOnAllFilters();
    }
    
    public void DeselectAllFilters()
    {
        homePage.DeselectAllFilters();
    }
}