using System;
using OpenQA.Selenium;

namespace Bankapi.Pekao24.Pages
{
    internal class ExportedTransactionListPage
    {
        private IWebDriver _webDriver;

        public ExportedTransactionListPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        internal object GetTransactionList()
        {
            throw new NotImplementedException();
        }
    }
}