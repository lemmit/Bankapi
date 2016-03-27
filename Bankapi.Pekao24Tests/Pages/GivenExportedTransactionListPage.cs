using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankapi.Pekao24.Pages;
using Should;
using Xunit;

namespace Bankapi.Pekao24Tests.Pages
{
    public class GivenExportedTransactionListPage : BasePageTest
    {
        private readonly ExportedTransactionListPage _exportedTransactionListPage;
        public GivenExportedTransactionListPage()
        {
            var url = BaseUrl + "exportedTransactionList.html";
            WebDriver.Navigate().GoToUrl(url);
            _exportedTransactionListPage =
                new ExportedTransactionListPage(WebDriver);
        }

        [Fact]
        public void ShouldReturnTransactionList()
        {
            var transactions = _exportedTransactionListPage.GetTransactionList();
            transactions.ShouldEqual(null);
        }
    }
}
