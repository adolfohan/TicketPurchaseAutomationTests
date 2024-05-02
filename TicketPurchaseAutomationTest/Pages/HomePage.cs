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
            //"parqueatraccionesmadrid",
            //"acuariozaragoza"
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
        var sessionTickets = new List<string>
        {
            "atletico-de-madrid-tour-metropolitano", "campnou", "tourbernabeu"
        }; //"bioparcvalencia", "mestallaforevertour"
        var sessionTicket = sessionTickets[Random.Next(sessionTickets.Count)];
        return BaseUrl + sessionTicket;
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
        var meInteresaButtons = FluentWait.Until(driver => driver!.FindElements(meInteresaButton));
        if (meInteresaButtons.Any())
        {
            var buttonToClick = meInteresaButtons[Random.Next(meInteresaButtons.Count)];
            ScrollIntoView(buttonToClick);
            FluentWait.Until(ExpectedConditions.ElementToBeClickable(buttonToClick)).SendKeys(Keys.Enter);
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
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private void ClickOnCultureVisitsToursFilter()
    {
        ClickOnFilter(cultureVisitsToursElement);
    }

    private void ClickOnExcursionsTouristsMobilityFilter()
    {
        ClickOnFilter(excursionsTouristsMobilityElement);
    }

    private void ClickOnExperiencesRelaxFilter()
    {
        ClickOnFilter(experiencesRelaxElement);
    }

    private void ClickOnGastronomyWineTourismFilter()
    {
        ClickOnFilter(gastronomyWineTourismElement);
    }

    private void ClickOnMusicalsShowFilter()
    {
        ClickOnFilter(musicalsShowElement);
    }

    private void ClickOnSportsFilter()
    {
        ClickOnFilter(sportsElement);
    }

    private void ClickOnActiveTourismFilter()
    {
        ClickOnFilter(activeTourismElement);
    }

    private void ClickOnSnowFilter()
    {
        ClickOnFilter(snowElement);
    }

    private void ClickOnCinemaDriveInFilter()
    {
        ClickOnFilter(cinemaDriveInElement);
    }

    private void ClickOnHalloweenFilter()
    {
        ClickOnFilter(halloweenElement);
    }

    private void ClickOnEscapeRoomExperiencesFilter()
    {
        ClickOnFilter(escapeRoomExperiencesElement);
    }

    public void ClickOnAllLeisureFamiliesFilters()
    {
        var filters = new List<Action>
        {
            ClickOnLeisureParksFilter,
            ClickOnCultureVisitsToursFilter,
            ClickOnExcursionsTouristsMobilityFilter,
            ClickOnExperiencesRelaxFilter,
            ClickOnGastronomyWineTourismFilter,
            ClickOnMusicalsShowFilter,
            ClickOnSportsFilter,
            ClickOnActiveTourismFilter,
            ClickOnSnowFilter,
            ClickOnCinemaDriveInFilter,
            ClickOnHalloweenFilter,
            ClickOnEscapeRoomExperiencesFilter
        };

        foreach (var filter in filters)
        {
            try
            {
                filter();
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void DeselectAllLeisureFamiliesFilters()
    {
        var filters = new List<By>
        {
            leisureParksFilterElement,
            cultureVisitsToursElement,
            excursionsTouristsMobilityElement,
            experiencesRelaxElement,
            gastronomyWineTourismElement,
            musicalsShowElement,
            sportsElement,
            activeTourismElement,
            snowElement,
            cinemaDriveInElement,
            halloweenElement,
            escapeRoomExperiencesElement
        };

        ClickOnAllLeisureFamiliesFilters();

        foreach (var filterElement in filters)
        {
            try
            {
                var filter = FluentWait.Until(ExpectedConditions.ElementToBeClickable(filterElement));
                if (filter.Selected)
                {
                    filter.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    /*private void ClickOnSpainFilter()
    {
        ClickOnFilter(spainElement);
    }

    private void ClickOnAndorraFilter()
    {
        ClickOnFilter(andorraElement);
    }

    private void ClickOnFranceFilter()
    {
        ClickOnFilter(franceElement);
    }

    private void ClickOnGibraltarFilter()
    {
        ClickOnFilter(gibraltarElement);
    }

    private void ClickOnItalyFilter()
    {
        ClickOnFilter(italyElement);
    }

    private void ClickOnPortugalFilter()
    {
        ClickOnFilter(portugalElement);
    }

    private void ClickOnUnitedKingdomFilter()
    {
        ClickOnFilter(unitedKingdomElement);
    }*/

    public void ClickOnAllCountryFilters()
    {
        var filters = new List<By>
        {
            spainElement,
            andorraElement,
            franceElement,
            gibraltarElement,
            italyElement,
            portugalElement,
            unitedKingdomElement
        };

        foreach (var filter in filters)
        {
            ClickOnFilter(filter);
        }
    }

    public void DeselectAllCountryFilters()
    {
        var filters = new List<By>
        {
            spainElement,
            andorraElement,
            franceElement,
            gibraltarElement,
            italyElement,
            portugalElement,
            unitedKingdomElement
        };

        ClickOnAllCountryFilters();

        foreach (var filterElement in filters)
        {
            try
            {
                var filter = FluentWait.Until(ExpectedConditions.ElementToBeClickable(filterElement));
                if (filter.Selected)
                {
                    filter.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
    
    private void ClickOnFilter(By filterElement)
    {
        try
        {
            var filter = FluentWait.Until(ExpectedConditions.ElementToBeClickable(filterElement));
            filter.Click();
            Thread.Sleep(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}