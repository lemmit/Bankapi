using System;
using Bankapi.Exceptions;
using Bankapi.Pekao24.Pages;
using Should;
using Xunit;

namespace Bankapi.Pekao24Tests.Pages
{
    public class GivenEnterPasswordPage : BasePageTest
    {
        readonly EnterPasswordPage _enterPasswordPage;

        public GivenEnterPasswordPage()
        {
            var url = BaseUrl + "enterPassword.html";
            WebDriver.Navigate().GoToUrl(url);
            _enterPasswordPage = 
                new EnterPasswordPage(WebDriver);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionForNulledPassword()
        {
            var exception = Record.Exception(
                () => _enterPasswordPage.Password = null
            );
            exception.ShouldBeType<ArgumentNullException>();
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionForEmptyPassword()
        {
            var exception = Record.Exception(
                () => _enterPasswordPage.Password = ""
            );
            exception.ShouldBeType<ArgumentException>();
        }


        [Fact]
        public void WhenInputsCountHigherThanPasswordLength_ShouldThrowPasswordLengthException()
        {
            var exception = Record.Exception(
                () => _enterPasswordPage.Password = "123456789"
            );
            exception.ShouldBeType<PasswordLengthException>();
        }

        [Fact]
        public void WhenInputsCountLowerThanPasswordLength_ShouldThrowPasswordLengthException()
        {
            var exception = Record.Exception(
                () => _enterPasswordPage.Password = "1234567891012312323423423"
            );
            exception.ShouldBeType<PasswordLengthException>();
        }

        [Fact]
        public void ShouldLocatePasswordFields()
        {
            true.ShouldBeFalse();
        }

        [Fact]
        public void ShouldFillPasswordField()
        {
            var goodPassword = "123456789abcdeg";
            _enterPasswordPage.Password = goodPassword; //pass lenght = 15
            var password = _enterPasswordPage.Password;
            var maskedPassword = CreateMaskedPassword(password, goodPassword);

            password.ShouldBeSameAs(maskedPassword);
        }

        private static string CreateMaskedPassword(string readPassword, string goodPassword)
        {
            var maskedPassword = "";
            for (int letterPosition = 0; letterPosition < readPassword.Length; letterPosition++)
            {
                var letter = readPassword[letterPosition];
                var letterToAdd = letter == '*' ? '*' : goodPassword[letterPosition];
                maskedPassword += letterToAdd;
            }
            return maskedPassword;
        }
    }
}