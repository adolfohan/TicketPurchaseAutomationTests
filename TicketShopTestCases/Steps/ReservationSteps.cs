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
    
    [When(@"does not completes personal information")]
    public void PersonalInformationInBlank()
    {
        reservationPage.CompletePersonalInformation("","","","","");
    }
    
    [When(@"completes with incorrect name and surname")]
    public void WrongNameAndSurname()
    {
        reservationPage.CompletePersonalInformation("%$&%&$%&","$%&$%&$%&","33511838A","test@test.com","123456789");
    }
    [When(@"completes with incorrect id")]
    public void WrongId()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","%&/%&/%&/%&/","atest@atest.com","123456789");
    }
    
    [When(@"completes with incorrect email")]
    public void WrongEmail()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","33511838A","test.kom","123456789");
    }
    
    [When(@"completes with incorrect phone number")]
    public void WrongPhoneNumber()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","33511838A","test@test.kom","%%/&%//()(/");
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
    
    [When(@"clicks on the ""Comprar"" button again")]
    public void ClicksOnComprarButtonAgain()
    {
        reservationPage.ClickOnComprarButtonAgain();
    }
    
    [Then(@"the user cannot proceed to the payment with fields in blank")]
    public void CheckBlankFields()
    {
        reservationPage.BlankFields();
    }

    [Then(@"the user cannot proceed to the payment with invalid name and surname")]
    public void CheckInvalidNameAndSurname()
    {
        reservationPage.InvalidNameAndSurname();
    }

    public void CheckCardPage()
    {
        reservationPage.IsCardPageDisplayed();
    }
    
    [Then(@"the user cannot proceed to the payment with invalid id")]
    public void CheckInvalidId()
    {
        reservationPage.InvalidId();
    }
    
    [Then(@"the user cannot proceed to the payment with invalid email")]
    public void CheckInvalidEmail()
    {
        reservationPage.InvalidEmail();
    }
    
    [Then(@"the user cannot proceed to the payment with invalid phone number")]
    public void CheckInvalidPhoneNumber()
    {
        reservationPage.InvalidPhone();
    }

    [Then(@"the user cannot proceed to the payment without checking the checkboxes")]

    public void CheckCheckboxesSelected()
    {
        reservationPage.AreCheckboxesSelected();
    }
    
}