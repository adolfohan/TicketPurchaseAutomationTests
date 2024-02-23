using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class HomePage(IWebDriver? driver) : BasePage(driver)
{
    private readonly By pageSize20Element = By.XPath("//a[contains(text(), '20')]");
    private static By meInteresaButton =>
        By.XPath(
            "//a[contains(@class, 'sv-button sv-button--type-contained sv-button--size-sm sv-button--color-primary') and contains(text(), 'Me interesa')]");
    private static By leisureParksFilterElement => By.Id("c124");
    private static By cultureVisitsToursElement => By.Id("c132");
    private static By excursionsTouristsMobilityElement => By.Id("c142");
    private static By experiencesRelaxElement => By.Id("c181");
    private static By gastronomyWineTourismElement => By.Id("c174");
    private static By musicalsShowElement => By.Id("c158");
    private static By sportsElement => By.Id("c185");
    private static By activeTourismElement => By.Id("c152");
    private static By snowElement => By.Id("c192");
    private static By cinemaDriveInElement => By.Id("c166");
    private static By halloweenElement => By.Id("c310");
    private static By escapeRoomExperiencesElement => By.Id("c313");
    private static By spainElement => By.Id("c201");
    private static By andorraElement => By.Id("c309");
    private static By franceElement => By.Id("c202");
    private static By gibraltarElement => By.Id("c321");
    private static By italyElement => By.Id("c319");
    private static By portugalElement => By.Id("c203");
    private static By unitedKingdomElement => By.Id("c323");
    private const string BaseUrl = "https://pre-tixalia.publicticketshop.experticket.com/";

    private string RandomNormalUrl()
    {
        
        List<string> normalTickets =
        [
            "Entradas-PortAventura-Park",
            //"Puy-du-Fou-Combinada-Parque-Sueno-Toledo",
            "Entradas-Isla-Magica",
            "Entradas-Cabarceno",
            "parqueatraccionesmadrid",
            "acuariozaragoza"
        ];
        
        var normalTicket = normalTickets[Random.Next(normalTickets.Count)];
        var completeUrl = BaseUrl + normalTicket;

        return completeUrl;
    }
    
    public void NavigateToUrl()
    {
        Driver!.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/");
        Driver!.Manage().Window.Maximize();
    }
    
    public void NavigateToNormalUrl()
    {
        Driver!.Navigate().GoToUrl(RandomNormalUrl());
        Driver!.Manage().Window.Maximize();
    }
    
    private string RandomSessionUrl()
    {
        
        List<string> sessionTickets =
        [
            //"bioparcvalencia",
            "atletico-de-madrid-tour-metropolitano",
            "campnou",
            "tourbernabeu"
            //"mestallaforevertour"
        ];

        var sessionTicket = sessionTickets[Random.Next(sessionTickets.Count)];
        var completeUrl = BaseUrl + sessionTicket;

        return completeUrl;
    }
    
    public void NavigateToSessionUrl()
    {
        Driver!.Navigate().GoToUrl(RandomSessionUrl());
        Driver!.Manage().Window.Maximize();

    }
    
    private string RandomAdvancedDateSelectorUrl()
    {
        
        List<string> advancedDateSelectorTickets =
        [
            //"ciudadartesyciencias-hemisferic",
            //"ciudadartesyciencias-oceanografic",
            "ciudadartesyciencias-combinadas"
        ];

        var advancedDateSelectorTicket = advancedDateSelectorTickets[Random.Next(advancedDateSelectorTickets.Count)];
        var completeUrl = BaseUrl + advancedDateSelectorTicket;

        return completeUrl;
    }
    
    public void NavigateToSeatingUrl()
    {
        Driver!.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/test-seating");
        Driver!.Manage().Window.Maximize();
    }
    public void NavigateToAdvancedDateSelectorUrl()
    {
        Driver!.Navigate().GoToUrl(RandomAdvancedDateSelectorUrl());
        Driver!.Manage().Window.Maximize();
    }

    public void PressPageSize20()
    {
        var pageSize20 = FluentWait.Until(ExpectedConditions.ElementIsVisible(pageSize20Element));
        ScrollIntoView(pageSize20);
        pageSize20.Click();
    }
    
    public void ClickOnRandomMeInteresaButton()
    {
        IList<IWebElement> meInteresaButtons = FluentWait.Until(webDriver => webDriver!.FindElements(meInteresaButton));

        if (meInteresaButtons.Count > 0)
        {
            var randomIndex = new Random().Next(0, meInteresaButtons.Count);
            var buttonToClick = meInteresaButtons[randomIndex];

            ScrollIntoView(buttonToClick);

            FluentWait.Until(ExpectedConditions.ElementToBeClickable(buttonToClick));
            
            //TestUtil.DrawBorder(buttonToClick);

            buttonToClick.SendKeys(Keys.Enter);
            //buttonToClick.Click();
        }
        else
        {
            throw new NoSuchElementException("No 'Me interesa' buttons found on the page.");
        }
    }

    private void ClickOnLeisureParksFilter()
    {
        try
        {
            var leisureParksFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(leisureParksFilterElement));
            leisureParksFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnCultureVisitsToursFilter()
    {
        try
        {
            var cultureVisitsTour =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(cultureVisitsToursElement));
            cultureVisitsTour.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnExcursionsTouristsMobilityFilter()
    {
        try
        {
            var excursionsTouristsMobility =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(excursionsTouristsMobilityElement));
            excursionsTouristsMobility.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnExperiencesRelaxFilter()
    {
        try
        {
            var experiencesRelax =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(experiencesRelaxElement));
            experiencesRelax.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnGastronomyWineTourismFilter()
    {
        try
        {
            var gastronomyWineTourism =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(gastronomyWineTourismElement));
            gastronomyWineTourism.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnMusicalsShowFilter()
    {
        try
        {
            var musicalsShow =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(musicalsShowElement));
            musicalsShow.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnSportsFilter()
    {
        try
        {
            var sports =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(sportsElement));
            sports.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnActiveTourismFilter()
    {
        try
        {
            var activeTourism =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(activeTourismElement));
            activeTourism.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnSnowFilter()
    {
        try
        {
            var snow =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(snowElement));
            snow.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnCinemaDriveInFilter()
    {
        try
        {
            var cinemaDriveIn =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(cinemaDriveInElement));
            cinemaDriveIn.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnHalloweenFilter()
    {
        try
        {
            var halloween =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(halloweenElement));
            halloween.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    private void ClickOnEscapeRoomExperiencesFilter()
    {
        try
        {
            var escapeRoomExperiences =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(escapeRoomExperiencesElement));
            escapeRoomExperiences.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void ClickOnAllLeisureFamiliesFilters()
    {
        try
        {
            ClickOnLeisureParksFilter();
            Thread.Sleep(500);
            ClickOnCultureVisitsToursFilter();
            Thread.Sleep(500);
            ClickOnExcursionsTouristsMobilityFilter();
            Thread.Sleep(500);
            ClickOnExperiencesRelaxFilter();
            Thread.Sleep(500);
            ClickOnGastronomyWineTourismFilter();
            Thread.Sleep(500);
            ClickOnMusicalsShowFilter();
            Thread.Sleep(500);
            ClickOnSportsFilter();
            Thread.Sleep(500);
            ClickOnActiveTourismFilter();
            Thread.Sleep(500);
            ClickOnSnowFilter();
            Thread.Sleep(500);
            ClickOnCinemaDriveInFilter();
            Thread.Sleep(500);
            ClickOnHalloweenFilter();
            Thread.Sleep(500);
            ClickOnEscapeRoomExperiencesFilter();
            Thread.Sleep(500);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void DeselectAllLeisureFamiliesFilters()
    {
        try
        {
            var leisureParksFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(leisureParksFilterElement));
            var cultureVisitsTour =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(cultureVisitsToursElement));
            var excursionsTouristsMobility =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(excursionsTouristsMobilityElement));
            var experiencesRelax =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(experiencesRelaxElement));
            var gastronomyWineTourism =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(gastronomyWineTourismElement));
            var musicalsShow =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(musicalsShowElement));
            var sports =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(sportsElement));
            var activeTourism =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(activeTourismElement));
            var snow =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(snowElement));
            var cinemaDriveIn =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(cinemaDriveInElement));
            var halloween =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(halloweenElement));
            var escapeRoomExperiences =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(escapeRoomExperiencesElement));
            
            ClickOnAllLeisureFamiliesFilters();

            if (!leisureParksFilter.Selected || !cultureVisitsTour.Selected || !excursionsTouristsMobility.Selected ||
                !experiencesRelax.Selected || !gastronomyWineTourism.Selected || !musicalsShow.Selected ||
                !sports.Selected || !activeTourism.Selected || !snow.Selected || !cinemaDriveIn.Selected ||
                !halloween.Selected || !escapeRoomExperiences.Selected) return;
            leisureParksFilter.Click();
            cultureVisitsTour.Click();
            excursionsTouristsMobility.Click();
            experiencesRelax.Click();
            gastronomyWineTourism.Click();
            musicalsShow.Click();
            sports.Click();
            activeTourism.Click();
            snow.Click();
            cinemaDriveIn.Click();
            halloween.Click();
            escapeRoomExperiences.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnSpainFilter()
    {
        try
        {
            var spainFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(spainElement));
            spainFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnAndorraFilter()
    {
        try
        {
            var andorraFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(andorraElement));
            andorraFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnFranceFilter()
    {
        try
        {
            var franceFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(franceElement));
            franceFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnGibraltarFilter()
    {
        try
        {
            var gibraltarFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(gibraltarElement));
            gibraltarFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnItalyFilter()
    {
        try
        {
            var italyFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(italyElement));
            italyFilter.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnPortugalFilter()
    {
        try
        {
            var portugalFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(portugalElement));
            portugalFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    private void ClickOnUnitedKingdomFilter()
    {
        try
        {
            var unitedKingdomFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(unitedKingdomElement));
            unitedKingdomFilter.Click();
            Thread.Sleep(2000);
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void ClickOnAllCountryFilters()
    {
        try
        {
            ClickOnSpainFilter();
            ClickOnAndorraFilter();
            ClickOnFranceFilter();
            ClickOnGibraltarFilter();
            ClickOnItalyFilter();
            ClickOnPortugalFilter();
            ClickOnUnitedKingdomFilter();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void DeselectAllCountryFilters()
    {
        try
        {
            var spainFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(spainElement));
            var andorraFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(andorraElement));
            var franceFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(franceElement));
            var gibraltarFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(gibraltarElement));
            var italyFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(italyElement));
            var portugalFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(portugalElement));
            var unitedKingdomFilter =
                FluentWait.Until(ExpectedConditions.ElementToBeClickable(unitedKingdomElement));
            ClickOnSpainFilter();
            ClickOnAndorraFilter();
            ClickOnFranceFilter();
            ClickOnGibraltarFilter();
            ClickOnItalyFilter();
            ClickOnPortugalFilter();
            ClickOnUnitedKingdomFilter();

            if (!spainFilter.Selected || !andorraFilter.Selected || !franceFilter.Selected ||
                !gibraltarFilter.Selected ||
                !italyFilter.Selected || !portugalFilter.Selected || !unitedKingdomFilter.Selected) return;
            ClickOnSpainFilter();
            ClickOnAndorraFilter();
            ClickOnFranceFilter();
            ClickOnGibraltarFilter();
            ClickOnItalyFilter();
            ClickOnPortugalFilter();
            ClickOnUnitedKingdomFilter();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
}