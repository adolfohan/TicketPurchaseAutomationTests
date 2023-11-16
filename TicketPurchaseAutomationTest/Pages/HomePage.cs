using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {

    }

    private By pageSize20Element = By.XPath("//a[contains(text(), '20')]");
    private By meInteresaButton =>
        By.XPath(
            "//a[contains(@class, 'sv-button sv-button--type-contained sv-button--size-sm sv-button--color-primary') and contains(text(), 'Me interesa')]");
    private By leisureParksFilterElement => By.Id("c12");
    private By cultureVisitsToursElement => By.Id("c132");
    private By excursionsTouristsMobilityElement => By.Id("c142");
    private By experiencesRelaxElement => By.Id("c181");
    private By gastronomyWineTourismElement => By.Id("c174");
    private By musicalsShowElement => By.Id("c158");
    private By sportsElement => By.Id("c185");
    private By activeTourismElement => By.Id("c152");
    private By snowElement => By.Id("c192");
    private By cinemaDriveInElement => By.Id("c166");
    private By halloweenElement => By.Id("c310");
    private By escapeRoomExperiencesElement => By.Id("c313");
    private By spainElement => By.Id("c201");
    private By andorraElement => By.Id("c309");
    private By franceElement => By.Id("c202");
    private By gibraltarElement => By.Id("c321");
    private By italyElement => By.Id("c319");
    private By portugalElement => By.Id("c203");
    private By unitedKingdomElement => By.Id("c323");
    
    
    public void NavigateToUrl()
    {
        try
        {
            driver.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/");
            driver.Manage().Window.Maximize();
            /*fluentWait.Until(webDriver =>
                ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(TimeSpan.FromSeconds(5));*/
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void NavigateToSessionUrl()
    {
        try
        {
            driver.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/espectaculo-flamenco-consumicion");
            driver.Manage().Window.Maximize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }
    
    public void NavigateToAdvancedDateSelectorUrl()
    {
        try
        {
            driver.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/ciudadartesyciencias-hemisferic");
            driver.Manage().Window.Maximize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while navigating to the URL: {ex.Message}");
        }
    }

    public void PressPageSize20()
    {
        IWebElement pageSize20 = fluentWait.Until(ExpectedConditions.ElementIsVisible(pageSize20Element));
        ScrollIntoView(pageSize20);
        pageSize20.Click();
    }
    
    public void ClickOnRandomMeInteresaButton()
    {
        IList<IWebElement> meInteresaButtons = fluentWait.Until(webDriver => webDriver.FindElements(meInteresaButton));

        if (meInteresaButtons.Count > 0)
        {
            var randomIndex = new Random().Next(0, meInteresaButtons.Count);
            var buttonToClick = meInteresaButtons[randomIndex];

            ScrollIntoView(buttonToClick);

            fluentWait.Until(ExpectedConditions.ElementToBeClickable(buttonToClick));
            
            //TestUtil.DrawBorder(buttonToClick);

            buttonToClick.SendKeys(Keys.Enter);
            //buttonToClick.Click();
        }
        else
        {
            throw new NoSuchElementException("No 'Me interesa' buttons found on the page.");
        }
    }

    public void ClickOnLeisureParksFilter()
    {
        try
        {
            IWebElement leisureParksFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(leisureParksFilterElement));
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
    
    public void ClickOnCultureVisitsToursFilter()
    {
        try
        {
            IWebElement cultureVisitsTour =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(cultureVisitsToursElement));
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
    
    public void ClickOnExcursionsTouristsMobilityFilter()
    {
        try
        {
            IWebElement excursionsTouristsMobility =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(excursionsTouristsMobilityElement));
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
    
    public void ClickOnExperiencesRelaxFilter()
    {
        try
        {
            IWebElement experiencesRelax =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(experiencesRelaxElement));
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
    
    public void ClickOnGastronomyWineTourismFilter()
    {
        try
        {
            IWebElement gastronomyWineTourism =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(gastronomyWineTourismElement));
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
    
    public void ClickOnMusicalsShowFilter()
    {
        try
        {
            IWebElement musicalsShow =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(musicalsShowElement));
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
    
    public void ClickOnSportsFilter()
    {
        try
        {
            IWebElement sports =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(sportsElement));
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
    
    public void ClickOnActiveTourismFilter()
    {
        try
        {
            IWebElement activeTourism =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(activeTourismElement));
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
    
    public void ClickOnSnowFilter()
    {
        try
        {
            IWebElement snow =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(snowElement));
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
    
    public void ClickOnCinemaDriveInFilter()
    {
        try
        {
            IWebElement cinemaDriveIn =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(cinemaDriveInElement));
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
    
    public void ClickOnHalloweenFilter()
    {
        try
        {
            IWebElement halloween =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(halloweenElement));
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
    
    public void ClickOnEscapeRoomExperiencesFilter()
    {
        try
        {
            IWebElement escapeRoomExperiences =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(escapeRoomExperiencesElement));
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
            IWebElement leisureParksFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(leisureParksFilterElement));
            IWebElement cultureVisitsTour =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(cultureVisitsToursElement));
            IWebElement excursionsTouristsMobility =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(excursionsTouristsMobilityElement));
            IWebElement experiencesRelax =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(experiencesRelaxElement));
            IWebElement gastronomyWineTourism =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(gastronomyWineTourismElement));
            IWebElement musicalsShow =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(musicalsShowElement));
            IWebElement sports =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(sportsElement));
            IWebElement activeTourism =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(activeTourismElement));
            IWebElement snow =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(snowElement));
            IWebElement cinemaDriveIn =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(cinemaDriveInElement));
            IWebElement halloween =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(halloweenElement));
            IWebElement escapeRoomExperiences =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(escapeRoomExperiencesElement));
            
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
    
    public void ClickOnSpainFilter()
    {
        try
        {
            IWebElement spainFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(spainElement));
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
    
    public void ClickOnAndorraFilter()
    {
        try
        {
            IWebElement andorraFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(andorraElement));
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
    
    public void ClickOnFranceFilter()
    {
        try
        {
            IWebElement franceFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(franceElement));
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
    
    public void ClickOnGibraltarFilter()
    {
        try
        {
            IWebElement gibraltarFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(gibraltarElement));
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
    
    public void ClickOnItalyFilter()
    {
        try
        {
            IWebElement italyFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(italyElement));
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
    
    public void ClickOnPortugalFilter()
    {
        try
        {
            IWebElement portugalFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(portugalElement));
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
    
    public void ClickOnUnitedKingdomFilter()
    {
        try
        {
            IWebElement unitedKingdomFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(unitedKingdomElement));
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
            IWebElement spainFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(spainElement));
            IWebElement andorraFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(andorraElement));
            IWebElement franceFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(franceElement));
            IWebElement gibraltarFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(gibraltarElement));
            IWebElement italyFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(italyElement));
            IWebElement portugalFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(portugalElement));
            IWebElement unitedKingdomFilter =
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(unitedKingdomElement));
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