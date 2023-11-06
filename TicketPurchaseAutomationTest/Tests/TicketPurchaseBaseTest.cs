using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class TicketPurchaseBaseTest : BaseTest
{
    [Test, Order(1)]
    public void TicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Purchase Normal Ticket Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked Me Interesa button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected desired ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed personal information");
            currentStep = "Step CompletePersonalInformation";
            reservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked conditions checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed card information");
            currentStep = "Step CompleteTheCardInformation";
            cardSteps.CompleteTheCardInformation();

            LogStep(Status.Info, "Clicked on Pagar button");
            currentStep = "Step ClickPagarButton";
            cardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Clicked on Enviar button");
            currentStep = "Step ClickOnEnviarButton";
            cardSteps.ClickOnEnviarButton();

            LogStep(Status.Info, "Clicked on Continuar button");
            currentStep = "Step ClickOnContinuarButton";
            cardSteps.ClickOnContinuarButton();

            LogStep(Status.Info, "Purchase completed");
            currentStep = "PurchaseOKMessage";
            purchaseOkSteps.PurchaseOkMessage();
            
            LogStep(Status.Info, "Ticket Purchase Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(2)]
    public void TicketPurchasePersonaInformationInBlankTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Purchase with Personal Information in Blank Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Me Interesa button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected desired ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Personal Information in Blank");
            currentStep = "Step CompletePersonalInformationInBlankPersonalInformation";
            reservationSteps.PersonalInformationInBlank();

            LogStep(Status.Info, "Checked conditions checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Check Blank Fields");
            currentStep = "Step CheckBlankFields";
            reservationSteps.CheckBlankFields();
            
            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase unsuccessful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    /*
    [Test, Order(3)]
    public void TicketPurchaseWithWrongNameAndSurnameTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Name And Surname");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Name And Surname");
            currentStep = "Step WrongNameAndSurname";
            reservationSteps.WrongNameAndSurname();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            // LogStep(Status.Info, "Checking Invalid Name And Surname");
            // currentStep = "Step CheckInvalidNameAndSurname";
            // reservationSteps.CheckInvalidNameAndSurname();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase With Wrong Name And Surname Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(4)]
    public void TicketPurchaseWithWrongIdTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong ID");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong ID");
            currentStep = "Step WrongId";
            reservationSteps.WrongId();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            // LogStep(Status.Info, "Checking Invalid ID");
            // currentStep = "Step CheckInvalidId";
            // reservationSteps.CheckInvalidId();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase With Wrong ID Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }*/

    [Test, Order(5)]
    public void TicketPurchaseWithWrongEmailTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Email");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Email");
            currentStep = "Step WrongEmail";
            reservationSteps.WrongEmail();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Email");
            currentStep = "Step CheckInvalidEmail";
            reservationSteps.CheckInvalidEmail();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase With Wrong Email Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(6)]
    public void TicketPurchaseWithWrongPhone()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Phone");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Phone Number");
            currentStep = "Step WrongPhoneNumber";
            reservationSteps.WrongPhoneNumber();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Phone Number");
            currentStep = "Step CheckInvalidPhoneNumber";
            reservationSteps.CheckInvalidPhoneNumber();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase With Wrong Phone Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(7)]
    public void TicketPurchaseWithoutCheckingTheCheckboxes()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase Without Checking the Checkboxes");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed Personal Information");
            currentStep = "Step CompletePersonalInformation";
            reservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Checkboxes");
            currentStep = "Step CheckCheckboxesSelected";
            reservationSteps.CheckCheckboxesSelected();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase Without Checking the Checkboxes Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(8)]
    public void TicketPurchaseWrongCardTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Card");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();

            LogStep(Status.Info, "Selected Desired Ticket");
            currentStep = "Step SelectDesiredTicket";
            ticketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            currentStep = "Step ConfirmDate";
            ticketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            currentStep = "Step ClickComprarButton";
            ticketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed Personal Information");
            currentStep = "Step CompletePersonalInformation";
            reservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed Card Information With Wrong Details");
            currentStep = "Step CompleteTheCardWithWrongInformation";
            cardSteps.CompleteTheCardWithWrongInformation();

            LogStep(Status.Info, "Clicked 'Pagar' Button");
            currentStep = "Step ClickPagarButton";
            cardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Checking for Invalid Card Message");
            currentStep = "Step ThenTheTicketPurchaseShouldBeUnsuccessful";
            cardSteps.ThenTheTicketPurchaseShouldBeUnsuccessful();

            LogStep(Status.Info, "Ticket Purchase With Wrong Card Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(9)]
    public void SelectAllFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePageSteps.GoToURL();

            LogStep(Status.Info, "Clicked Leisure Parks Filter");
            currentStep = "Step ClickOnLeisureParksFilter";
            homePageSteps.ClickOnLeisureParksFilter();

            LogStep(Status.Info, "Clicked Culture, Visits and Tours Filter");
            currentStep = "Step ClickOnCultureVisitsToursFilter";
            homePageSteps.ClickOnCultureVisitsToursFilter();
            
            LogStep(Status.Info, "Clicked Excursions and Tourist Mobility Filter");
            currentStep = "Step ClickOnExcursionsTouristsMobilityFilter";
            homePageSteps.ClickOnExcursionsTouristsMobilityFilter();
            
            LogStep(Status.Info, "Clicked Experiences and Relax Filter");
            currentStep = "Step ClickOnExperiencesRelaxFilter";
            homePageSteps.ClickOnExperiencesRelaxFilter();
            
            LogStep(Status.Info, "Clicked Gastronomy and Wine Tourism Filter");
            currentStep = "Step ClickOnGastronomyWineTourismFilter";
            homePageSteps.ClickOnGastronomyWineTourismFilter();
            
            LogStep(Status.Info, "Clicked Musicals and Shows Filter");
            currentStep = "Step ClickOnMusicalsShowFilter";
            homePageSteps.ClickOnMusicalsShowFilter();
            
            LogStep(Status.Info, "Clicked Sports Filter");
            currentStep = "Step ClickOnSportsFilter";
            homePageSteps.ClickOnSportsFilter();
            
            LogStep(Status.Info, "Clicked Active Tourism Filter");
            currentStep = "Step ClickOnActiveTourismFilter";
            homePageSteps.ClickOnActiveTourismFilter();
            
            LogStep(Status.Info, "Clicked Snow Filter");
            currentStep = "Step ClickOnSnowFilter";
            homePageSteps.ClickOnSnowFilter();
            
            LogStep(Status.Info, "Clicked Cinema and Drive-in Filter");
            currentStep = "Step ClickOnCinemaDriveInFilter";
            homePageSteps.ClickOnCinemaDriveInFilter();
            
            LogStep(Status.Info, "Clicked Escape Room Experiences Filter");
            currentStep = "Step ClickOnEscapeRoomExperiencesFilter";
            homePageSteps.ClickOnEscapeRoomExperiencesFilter();
            
            LogStep(Status.Info, "Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(10)]
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
    
    [Test, Order(11)]
    public void ClickOnAllCountryFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Country Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();

            LogStep(Status.Info, "Clicked on Spain Filter");
            currentStep = "Step ClickOnSpainFilter";
            homePage.ClickOnSpainFilter();
            
            LogStep(Status.Info, "Clicked on Spain Filter");
            currentStep = "Step ClickOnSpainFilter";
            homePage.ClickOnSpainFilter();
            
            LogStep(Status.Info, "Clicked on Andorra Filter");
            currentStep = "Step ClickOnAndorraFilter";
            homePage.ClickOnAndorraFilter();
            
            LogStep(Status.Info, "Clicked on France Filter");
            currentStep = "Step ClickOnFranceFilter";
            homePage.ClickOnFranceFilter();
            
            LogStep(Status.Info, "Clicked on Gibraltar Filter");
            currentStep = "Step ClickOnGibraltarFilter";
            homePage.ClickOnGibraltarFilter();
            
            LogStep(Status.Info, "Clicked on Italy Filter");
            currentStep = "Step ClickOnItalyFilter";
            homePage.ClickOnItalyFilter();
            
            LogStep(Status.Info, "Clicked on Portugal Filter");
            currentStep = "Step ClickOnPortugalFilter";
            homePage.ClickOnPortugalFilter();
            
            LogStep(Status.Info, "Clicked on United Kingdom Filter");
            currentStep = "Step ClickOnUnitedKingdomFilter";
            homePage.ClickOnUnitedKingdomFilter();
            
            LogStep(Status.Info, "Deselect Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(12)]
    public void DeselectAllCountryFiltersTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Home Page Country Filters Test");

            LogStep(Status.Info, "Navigating to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();

            LogStep(Status.Info, "Deselected All Country Filter");
            currentStep = "Step DeselectAllCountryFilters";
            homePage.DeselectAllCountryFilters();
            
            LogStep(Status.Info, "Deselect All Country Filters Tests Successful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
}