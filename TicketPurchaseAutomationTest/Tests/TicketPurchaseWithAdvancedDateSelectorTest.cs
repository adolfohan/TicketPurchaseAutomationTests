using AventStack.ExtentReports;
using NUnit.Framework;
using TicketPurchaseAutomationTest.Base;

namespace TicketPurchaseAutomationTest.Tests;

[TestFixture]
public class TicketPurchaseWithAdvancedDateSelectorTest : BaseTest
{
    [Test]
    public void AdvancedDateSelectorTest()
    {
        try
        {
            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Completed personal information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com",
                "ahan@test.com",
                "123456789");

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked on Comprar button");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Completed card information");
            CurrentStep = "Step CompleteTheCardInformation";
            CardPage!.CompleteCardInformation("4548810000000003", "12", "49", "123");

            LogStep(Status.Info, "Clicked on Pagar button");
            CurrentStep = "Step ClickPagarButton";
            CardPage!.ClickOnPagarButton();

            LogStep(Status.Info, "Clicked on Enviar button");
            CurrentStep = "Step ClickOnEnviarButton";
            CardPage!.ClickOnEnviarButton();

            LogStep(Status.Info, "Clicked on Continuar button");
            CurrentStep = "Step ClickOnContinuarButton";
            CardPage!.ClickOnContinuarButton();

            LogStep(Status.Info, "Purchase completed");
            CurrentStep = "PurchaseOKMessage";
            PurchaseOkPage!.PurchaseOkVerificationMessage();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Personal Information in Blank");
            CurrentStep = "Step CompletePersonalInformationInBlankPersonalInformation";
            ReservationPage!.CompletePersonalInformation("", "", "", "", "", "");

            LogStep(Status.Info, "Checked conditions checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked privacy checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked on Comprar button again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Check Blank Fields");
            CurrentStep = "Step CheckBlankFields";
            ReservationPage!.BlankFields();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

            LogStep(Status.Info, "Ticket Purchase unsuccessful");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(3)]
    public void TicketPurchaseWithWrongNameAndSurnameTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Name And Surname");

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Entered Wrong Name And Surname");
            CurrentStep = "Step WrongNameAndSurname";
            ReservationPage!.CompletePersonalInformation("2165!", "15646456!", "33511838A", "ahan@test.com",
                "ahan@test.com",
                "123456789");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            /*LogStep(Status.Info, "Checking Invalid Name And Surname");
            CurrentStep = "Step CheckInvalidNameAndSurname";
            ReservationPage!.InvalidNameAndSurname();*/

            LogStep(Status.Info, "Clicked on 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Entered Wrong ID");
            CurrentStep = "Step WrongId";
            ReservationPage!.CompletePersonalInformation("2165!", "15646456!", "@@@@@@@@", "ahan@test.com",
                "ahan@test.com",
                "123456789");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid ID");
            CurrentStep = "Step CheckInvalidId";
            ReservationPage!.InvalidId();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

            LogStep(Status.Info, "Ticket Purchase With Wrong ID Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(5)]
    public void TicketPurchaseWithWrongEmailTest()
    {
        try
        {
            LogStep(Status.Info, "Starting Ticket Purchase With Wrong Email");

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Entered Wrong Email");
            CurrentStep = "Step WrongEmail";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "test.kom", "test.kom",
                "123456789");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Email");
            CurrentStep = "Step CheckInvalidEmail";
            ReservationPage!.InvalidEmail();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Entered Wrong Confirmation Email");
            CurrentStep = "Step WrongEmail";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "test@test.com",
                "test1@test.com", "123456789");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Confirmation Email");
            CurrentStep = "Step CheckInvalidEmail";
            ReservationPage!.InvalidConfirmationEmail();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Entered Wrong Phone Number");
            CurrentStep = "Step WrongPhoneNumber";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "test@test.kom",
                "test@test.kom", "%%/&%//()(/");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Invalid Phone Number");
            CurrentStep = "Step CheckInvalidPhoneNumber";
            ReservationPage!.InvalidPhone();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Completed Personal Information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com",
                "ahan@test.com",
                "123456789");

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Checking Checkboxes");
            CurrentStep = "Step CheckCheckboxesSelected";
            ReservationPage!.AreCheckboxesSelected();

            LogStep(Status.Info, "Checking Card Page");
            CurrentStep = "Step CheckCardPage";
            ReservationPage!.IsCardPageDisplayed();

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

            CommonAdvancedDateSelectorPurchaseSteps();

            LogStep(Status.Info, "Completed Personal Information");
            CurrentStep = "Step CompletePersonalInformation";
            ReservationPage!.CompletePersonalInformation("Adolfo", "Test", "33511838A", "ahan@test.com",
                "ahan@test.com",
                "123456789");

            LogStep(Status.Info, "Checked Conditions Checkbox");
            CurrentStep = "Step CheckTheConditionsCheckbox";
            ReservationPage!.CheckConditions();

            LogStep(Status.Info, "Checked Privacy Checkbox");
            CurrentStep = "Step CheckThePrivacyCheckbox";
            ReservationPage!.CheckPrivacy();

            LogStep(Status.Info, "Clicked 'Comprar' Button Again");
            CurrentStep = "Step ClicksComprarButtonAgain";
            ReservationPage!.ClickOnComprarButtonAgain();

            LogStep(Status.Info, "Completed Card Information With Wrong Details");
            CurrentStep = "Step CompleteTheCardWithWrongInformation";
            CardPage!.CompleteCardInformation("99", "12", "49", "123");

            LogStep(Status.Info, "Clicked 'Pagar' Button");
            CurrentStep = "Step ClickPagarButton";
            CardPage!.ClickOnPagarButton();

            LogStep(Status.Info, "Checking for Invalid Card Message");
            CurrentStep = "Step ThenTheTicketPurchaseShouldBeUnsuccessful";
            CardPage!.ThenTheTicketPurchaseShouldBeUnsuccessful();

            LogStep(Status.Info, "Ticket Purchase With Wrong Card Test Completed Successfully");
        }
        catch (Exception ex)
        {
            HandleTestFailure(ex);
            throw;
        }
    }

    [Test, Order(10)]
    public void TicketPurchaseUnsuccessfulWithoutOceanograficSession()
    {
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToAdvancedDateSelectorUrl();
        
        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Confirm date");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Advanced Date Selector Message Displayed");
        CurrentStep = "Step VerifyAdvancedSelectorMessage";
        AdvancedDateSelectorPage!.VerifyAdvancedSelectorMessage();

        LogStep(Status.Info, "Selected Title Option");
        CurrentStep = "Step SelectHemisfericTitle";
        AdvancedDateSelectorPage!.SelectHemisfericTitle();

        LogStep(Status.Info, "Selected Session Option");
        CurrentStep = "Step SelectHemisfericSessionHour";
        AdvancedDateSelectorPage!.SelectHemisfericSessionHour();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        AdvancedDateSelectorPage!.ClickOnComprarButton();
        
        LogStep(Status.Info, "Verify if pending data message is displayed");
        CurrentStep = "Step VerifyPendingDataMessage";
        SessionPage!.VerifyPendingDataMessage();
    }
    
    [Test, Order(11)]
    public void TicketPurchaseUnsuccessfulWithoutHemisfericSession()
    {
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToAdvancedDateSelectorUrl();
        
        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Confirm date");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Advanced Date Selector Message Displayed");
        CurrentStep = "Step VerifyAdvancedSelectorMessage";
        AdvancedDateSelectorPage!.VerifyAdvancedSelectorMessage();

        LogStep(Status.Info, "Selected Oceanografic Session Option");
        CurrentStep = "Step SelectOceanograficSessionHour";
        AdvancedDateSelectorPage!.SelectOceanograficSessionHour();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        AdvancedDateSelectorPage!.ClickOnComprarButton();
        
        LogStep(Status.Info, "Verify if pending data message is displayed");
        CurrentStep = "Step VerifyPendingDataMessage";
        SessionPage!.VerifyPendingDataMessage();
    }
    
    [Test, Order(11)]
    public void TicketPurchaseUnsuccessfulWithoutSessions()
    {
        LogStep(Status.Info, "Navigating to URL");
        CurrentStep = "Step GoToURL";
        HomePage!.NavigateToAdvancedDateSelectorUrl();
        
        LogStep(Status.Info, "Selected desired ticket");
        CurrentStep = "Step SelectDesiredTicket";
        TicketsSelectionPage!.SelectNumberOfTickets();

        LogStep(Status.Info, "Confirm date");
        CurrentStep = "Step ConfirmDate";
        TicketsSelectionPage!.ConfirmDate();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        TicketsSelectionPage!.ClickOnComprarButton();

        LogStep(Status.Info, "Advanced Date Selector Message Displayed");
        CurrentStep = "Step VerifyAdvancedSelectorMessage";
        AdvancedDateSelectorPage!.VerifyAdvancedSelectorMessage();

        LogStep(Status.Info, "Clicked on Comprar button");
        CurrentStep = "Step ClickComprarButton";
        AdvancedDateSelectorPage!.ClickOnComprarButton();
        
        LogStep(Status.Info, "Verify if pending data message is displayed");
        CurrentStep = "Step VerifyPendingDataMessage";
        SessionPage!.VerifyPendingDataMessage();
    }
}