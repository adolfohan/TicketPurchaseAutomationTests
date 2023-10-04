using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class ReservationSteps
{
    private readonly ReservationPage reservationPage;
    
    public ReservationSteps(IWebDriver driver)
    {
        reservationPage = new ReservationPage(driver);
    }
    
    [When(@"completes personal information")]
    public void CompletePersonalInformation()
    {
        reservationPage.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com",
            "123456789");
    }
    
    [When(@"checks the Conditions checkbox")]
    public void CheckTheConditionsCheckbox()
    {
        reservationPage.CheckConditions();
    }

    [When(@"checks the Privacy checkbox")]
    public void CheckThePrivacyCheckbox()
    {
        reservationPage.CheckPrivacy();
    }
    
    [When(@"clicks the ""Comprar"" button again")]
    public void ClicksComprarButtonAgain()
    {
        reservationPage.ClickComprarButtonAgain();
    }
    
}