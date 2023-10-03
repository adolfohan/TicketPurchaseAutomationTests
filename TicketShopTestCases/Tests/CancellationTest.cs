using NUnit.Framework;
using OpenQA.Selenium;
using TestCases.Steps;
using TestCases.Utilities;

namespace TestCases.Tests;

[TestFixture]
public class CancellationTest
{
    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.CreateWebDriver();
        testSteps = new TestSteps(driver);
        cancellationSteps = new CancellationSteps(driver);
    }

    private IWebDriver driver;
    private TestSteps testSteps;
    private CancellationSteps cancellationSteps;

    [Test]
    public void TestCancellation()
    {
        testSteps.GoToURL();
        testSteps.SelectMeInteresaButton();
        testSteps.SelectDesiredDate();
        testSteps.SelectDesiredTicket();
        testSteps.ClickComprarButton();
        testSteps.CompletePersonalInformation();
        testSteps.SelectCreditCard();
        testSteps.CheckTheConditionsCheckbox();
        testSteps.CheckThePrivacyCheckbox();
        testSteps.ClicksComprarButtonAgain();
        cancellationSteps.ClickCancelarButton();
        cancellationSteps.ClickContinuarButton();
        cancellationSteps.CancellationSuccessful("Venta cancelada");
    }

    //[TearDown]
    //public void TearDown() => driver.Quit();
}