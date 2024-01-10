using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Pages;

public class SeatingPage : BasePage
{
    private readonly By calendarDay = By.XPath("//div[@class='calendar-day' and text()='23']");
    private readonly By comprarBtnElement = By.CssSelector("a[href='/test-seating?s=bx9xm3jcqmtkg&c=14u4bx8o76goc']");
    private readonly By seatMapFrameElement = By.Id("seatmap");
    private readonly By availableSectorElement = By.CssSelector("[fill='#ffe100']");
    private readonly By availableSeatElement = By.XPath("//*[name()='svg']//*[local-name()='g' and @id='seats']//*[local-name()='circle' and not(contains(@class, 'no-hover-unavailable'))]");//By.CssSelector("circle.s:not(.no-hover-unavailable)"); 
    private readonly By comprarButtonElement = By.CssSelector(
        "a.sv-button.sv-button--type-contained.sv-button--color-primary.sv-button--size-lg.sv-button--buy");
    
    public SeatingPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickOnCalendarDay()
    {
        FluentWait.Until(ExpectedConditions.ElementToBeClickable(calendarDay)).Click();
    }

    public void ClickOnComprarBtn()
    {
        /*Thread.Sleep(TimeSpan.FromSeconds(2));
        var comprarBtn = fluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarBtnElement));
        Thread.Sleep(TimeSpan.FromSeconds(2));
        ScrollIntoView(comprarBtn);
        comprarBtn.Click();*/
        Driver.Navigate().GoToUrl("https://pre-tixalia.publicticketshop.experticket.com/test-seating/test-seating?s=bx9xm3jcqmtkg&c=14u4bx8o76goc");
    }

    public void SelectRandomAvailableSector()
    {
        var seatMapFrame = FluentWait.Until(ExpectedConditions.ElementIsVisible(seatMapFrameElement));
        Driver.SwitchTo().Frame(seatMapFrame);
        Thread.Sleep(TimeSpan.FromSeconds(2));
        
        IList<IWebElement> sectors = FluentWait.Until(webDriver => webDriver.FindElements(availableSectorElement));

        if (sectors.Count > 0)
        {
            var random = new Random();
            var randomSector = sectors[random.Next(sectors.Count)];
            
            randomSector.Click();
        }
    }

    public void SelectRandomAvailableSeat()
    {
        /*IList<IWebElement> seats = fluentWait.Until(webDriver => webDriver.FindElements(availableSeatElement));

        if (seats.Count > 0)
        {
            var random = new Random();
            var randomSeat = seats[random.Next(seats.Count)];
            
            randomSeat.Click();
            randomSeat.Click();
        }*/
        Thread.Sleep(TimeSpan.FromSeconds(2));
        var availableSeat = FluentWait.Until(ExpectedConditions.ElementToBeClickable(availableSeatElement));
        ScrollIntoView(availableSeat);
        availableSeat.Click();
    }

    public void SwitchToDefaultContent()
    {
        Driver.SwitchTo().DefaultContent();
    }
    
    public void ClickOnComprarButton()
    {
        try
        {
            IWebElement comprarButton = FluentWait.Until(ExpectedConditions.ElementToBeClickable(comprarButtonElement));
            Thread.Sleep(TimeSpan.FromSeconds(2));
            comprarButton.Click();
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine($"Element not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while clicking on 'Comprar' button in Session Page: {ex.Message}");
        }
    }
}