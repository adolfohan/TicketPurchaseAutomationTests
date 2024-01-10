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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            CommonNormalPurchaseSteps();
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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Me Interesa button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected desired ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Date confirmed");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Personal Information in Blank");
            CurrentStep = "Step CompletePersonalInformationInBlankPersonalInformation";
            ReservationSteps.PersonalInformationInBlank();

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked on Comprar button again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Check Blank Fields");
            CurrentStep = "Step CheckBlankFields";
            ReservationSteps.CheckBlankFields();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationSteps.CheckCardPage();

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
            homePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
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
            homePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected Desired Ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Email");
            CurrentStep = "Step WrongEmail";
            ReservationSteps.WrongEmail();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Email");
            CurrentStep = "Step CheckInvalidEmail";
            ReservationSteps.CheckInvalidEmail();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationSteps.CheckCardPage();

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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected Desired Ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Confirmation Email");
            CurrentStep = "Step WrongEmail";
            ReservationSteps.WrongConfirmationEmail();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Confirmation Email");
            CurrentStep = "Step CheckInvalidEmail";
            ReservationSteps.CheckInvalidConfirmationEmail();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationSteps.CheckCardPage();

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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected Desired Ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Entered Wrong Phone Number");
            CurrentStep = "Step WrongPhoneNumber";
            ReservationSteps.WrongPhoneNumber();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Phone Number");
            CurrentStep = "Step CheckInvalidPhoneNumber";
            ReservationSteps.CheckInvalidPhoneNumber();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationSteps.CheckCardPage();

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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected Desired Ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed Personal Information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Checkboxes");
            CurrentStep = "Step CheckCheckboxesSelected";
            ReservationSteps.CheckCheckboxesSelected();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationSteps.CheckCardPage();

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
            CurrentStep = "Step GoToURL";
            HomePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Random 'Me Interesa' Button");
            currentStep = "Step ClickRandomMeInteresaButton";
            homePageSteps.ClickOnRandomMeInteresaButton();*/

            LogStep(Status.Info, "Selected Desired Ticket");
            CurrentStep = "Step SelectDesiredTicket";
            TicketsSelectionSteps.SelectDesiredTicket();

            LogStep(Status.Info, "Confirmed Date");
            CurrentStep = "Step ConfirmDate";
            TicketsSelectionSteps.ConfirmDate();

            LogStep(Status.Info, "Clicked on 'Comprar' Button");
            CurrentStep = "Step ClickComprarButton";
            TicketsSelectionSteps.ClickOnComprarButton();

            LogStep(Status.Info, "Completed Personal Information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationSteps.CompletePersonalInformation();

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationSteps.CheckTheConditionsCheckbox();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationSteps.CheckThePrivacyCheckbox();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationSteps.ClicksOnComprarButtonAgain();

            LogStep(Status.Info, "Completed Card Information With Wrong Details");
            CurrentStep = "Step CompleteTheCardWithWrongInformation";
            CardSteps.CompleteTheCardWithWrongInformation();

            LogStep(Status.Info, "Clicked 'Pagar' Button");
            CurrentStep = "Step ClickPagarButton";
            CardSteps.ClickOnPagarButton();

            LogStep(Status.Info, "Checking for Invalid Card Message");
            CurrentStep = "Step ThenTheTicketPurchaseShouldBeUnsuccessful";
            CardSteps.ThenTheTicketPurchaseShouldBeUnsuccessful();

            LogStep(Status.Info, "Ticket Purchase With Wrong Card Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    /*[Test, Order(10)]
    public void RandomNavBarTicketPurchaseTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Random NavBar Purchase Ticket Test");
            
            LogStep(Status.Info, "Navigated to URL");
            currentStep = "Step GoToURL";
            homePage.NavigateToNormalUrl();

            /*LogStep(Status.Info, "Clicked on Me Interesa button");
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
    }*/
}