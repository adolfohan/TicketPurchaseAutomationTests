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

            CommonPurchaseSteps();
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
    public void TicketPurchaseWithWrongConfirmationEmailTest()
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

            LogStep(Status.Info, "Entered Wrong Confirmation Email");
            currentStep = "Step WrongEmail";
            reservationSteps.WrongConfirmationEmail();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            currentStep = "Step CheckTheConditionsCheckbox";
            reservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            currentStep = "Step CheckThePrivacyCheckbox";
            reservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            currentStep = "Step ClicksComprarButtonAgain";
            reservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Confirmation Email");
            currentStep = "Step CheckInvalidEmail";
            reservationSteps.CheckInvalidConfirmationEmail();

            LogStep(Status.Info, "Checking Card Page");
            currentStep = "Step CheckCardPage";
            reservationSteps.CheckCardPage();

            LogStep(Status.Info, "Ticket Purchase With Wrong Confirmation Email Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test, Order(7)]
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

    [Test, Order(8)]
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

    [Test, Order(9)]
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

    [Test, Order(10)]
    public void RandomNavBarTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Random NavBar Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToUrl();

            LogStep(Status.Info, "Clicked on Me Interesa button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePage.ClickOnRandomMeInteresaButton();
            
            LogStep(Status.Info, "Clicked on Random NavBar Item");
            currentStep = "Step SelectRandomNavBar";
            ticketsSelectionPage.SelectRandomNavBar();

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
    
    [Test, Order(11)]
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
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

            CommonPurchaseSteps();
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }
    
    [Test]
    public void WrapperTest()
    {
        homePage.NavigateToSessionUrl();
        ticketsSelectionPage.ClickOnPanelWrapper();
        ticketsSelectionPage.SelectNumberOfTickets("1");
        ticketsSelectionPage.ConfirmDate();
        ticketsSelectionPage.ClickOnComprarButton();
        reservationSteps.CompletePersonalInformation();
    }

    [Test]
    public void SessionTest()
    {
        homePage.NavigateToSessionUrl();
        ticketsSelectionPage.SelectNumberOfTickets("2");
        ticketsSelectionPage.ConfirmDate();
        ticketsSelectionPage.ClickOnComprarButton();
        /*sessionPage.SessionMessageDisplayed();
        sessionPage.SelectSession();
        sessionPage.ClickOnComprarButton();*/
        reservationSteps.CompletePersonalInformation();
    }

    [Test]
    public void AdvancedSelectorTest()
    {
        homePage.NavigateToAdvancedSelectorUrl();
        ticketsSelectionPage.SelectNumberOfTickets("2");
        ticketsSelectionPage.ConfirmDate();
        ticketsSelectionPage.ClickOnComprarButton();
        /*advancedSelectorPage.VerifyAdvancedSelectorMessage();
        advancedSelectorPage.SelectTitle();
        advancedSelectorPage.SelectSessionHour();
        advancedSelectorPage.ClickOnComprarButton();*/
        reservationSteps.CompletePersonalInformation();
    }
}