using Bankapi.Exceptions;
using Bankapi.Pekao24.Pages;
using Should;
using Xunit;

namespace Bankapi.Pekao24Tests.Pages
{
    public class GivenPekao24MainPage : BasePageTest
    {
        private readonly MainPage _pekao24MainPage;

        public GivenPekao24MainPage()
        {
            var url = BaseUrl + "mainPage.html";
            WebDriver.Navigate().GoToUrl(url);
            _pekao24MainPage = new MainPage(WebDriver);
        }

        [Fact]
        public void ShouldLocateClientNumberInput()
        {
            var numberInput = _pekao24MainPage.GetCustomerNumberInput();
            numberInput.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldSetClientNumberOnMainPage()
        {
            _pekao24MainPage.CustomerNumberInputValue = "testValue";
            var value = _pekao24MainPage.CustomerNumberInputValue;

            value.ShouldEqual("testValue");
        }

        [Fact]
        public void ShouldLocateLoginButton()
        {
            var loginButtonText = _pekao24MainPage.LoginButtonText;
            loginButtonText.ShouldEqual("Dalej");
        }

        [Fact]
        public void ShouldThrowInvalidCredentialExceptionIfSettingNullCustomerNumber()
        {
            var exception = Record.Exception( 
                () => _pekao24MainPage.CustomerNumberInputValue = null
            );
            
            exception.ShouldBeType<InvalidCredentialsException>();
        }

        [Fact]
        public void ShouldThrowInvalidCredentialsExceptionIfSettingEmptyCustomerNumber()
        {
            var exception = Record.Exception(
                () => _pekao24MainPage.CustomerNumberInputValue = ""
            );

            exception.ShouldBeType<InvalidCredentialsException>();
        }
    }
}
