using Bankapi.Exceptions;
using Bankapi.Pekao24.Pages;
using Should;
using Xunit;

namespace Bankapi.Pekao24Tests.Pages
{
    public class GivenAccountsListPage : BasePageTest
    {
        AccountsListPage _accountsListPage;

        public void AccountsListPageTest()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl + "pekaoAccountPage_1.html");
            _accountsListPage = new AccountsListPage(WebDriver);
        }

        [Fact]
        public void ShouldExtractAccountList()
        {
            var accountList = _accountsListPage.GetAccountList();
            accountList.ShouldEqual(new string[] {});
        }

        [Fact]
        public void ShouldThrowAccountNotFoundForNotPresentNumber()
        {
            var testValue = "doesntexistsforsure";
            var exception = Record.Exception(
                () => _accountsListPage.ClickAccount(testValue)
            );
            exception.ShouldBeType<AccountNotFoundException>();
        }
    }
}