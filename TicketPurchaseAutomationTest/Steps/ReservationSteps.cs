using OpenQA.Selenium;
using TicketPurchaseAutomationTest.Pages;

namespace TicketPurchaseAutomationTest.Steps;

public class ReservationSteps(IWebDriver? driver)
{
    private readonly ReservationPage reservationPage = new(driver);

    public void CompletePersonalInformation()
    {
        reservationPage.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com", "ahan@test.com",
            "123456789");
    }

    public void PersonalInformationInBlank()
    {
        reservationPage.CompletePersonalInformation("","","","","", "");
    }

    public void WrongNameAndSurname()
    {
        reservationPage.CompletePersonalInformation("%$&%&$%&","$%&$%&$%&","33511838A","test@test.com", "test@test.com", "123456789");
    }

    public void WrongId()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","%&/%&/%&/%&/","atest@atest.com", "atest@atest.com","123456789");
    }
    
    public void WrongEmail()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","33511838A","test.kom", "test.kom", "123456789");
    }

    public void WrongConfirmationEmail()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","33511838A","test@test.com", "test1@test.com", "123456789");
    }

    public void WrongPhoneNumber()
    {
        reservationPage.CompletePersonalInformation("Adolfo","Test","33511838A","test@test.kom", "test@test.kom", "%%/&%//()(/");
    }

    public void CheckTheConditionsCheckbox()
    {
        reservationPage.CheckConditions();
    }

    public void CheckThePrivacyCheckbox()
    {
        reservationPage.CheckPrivacy();
    }

    public void ClicksOnComprarButtonAgain()
    {
        reservationPage.ClickOnComprarButtonAgain();
    }
    
    public void CheckBlankFields()
    {
        reservationPage.BlankFields();
    }

    public void CheckInvalidNameAndSurname()
    {
        reservationPage.InvalidNameAndSurname();
    }

    public void CheckCardPage()
    {
        reservationPage.IsCardPageDisplayed();
    }
    
    public void CheckInvalidId()
    {
        reservationPage.InvalidId();
    }
    
    public void CheckInvalidEmail()
    {
        reservationPage.InvalidEmail();
    }

    public void CheckInvalidConfirmationEmail()
    {
        reservationPage.InvalidConfirmationEmail();
    }

    public void CheckInvalidPhoneNumber()
    {
        reservationPage.InvalidPhone();
    }
    
    public void CheckCheckboxesSelected()
    {
        reservationPage.AreCheckboxesSelected();
    }
    
}