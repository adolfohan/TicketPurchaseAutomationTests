using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCases.Pages;

namespace TestCases.Steps;

[Binding]
public class CancellationSteps
{
    private readonly CancellationPage cancellationPage;
    private IWebDriver driver;

    public CancellationSteps(IWebDriver driver)
    {
        this.driver = driver;
        cancellationPage = new CancellationPage(driver);
    }

    [When(@"selects ""Cancelar"" button")]
    public void ClickCancelarButton()
    {
        cancellationPage.ClickCancelarButton();
    }

    [When(@"selects ""Continuar"" button")]
    public void ClickContinuarButton()
    {
        cancellationPage.ClickContinuarButton();
    }

    [Then(@"the cancellation should be successful")]
    public void CancellationSuccessful(string expectedMessage)
    {
        var messageElement = cancellationPage.MessageElement;
        var actualMessage = messageElement.Text;

        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }
}