using System;
using OpenQA.Selenium;

namespace Bankapi.Pekao24.Pages
{
    internal class AccountsListPage
    {
        private readonly IWebDriver _webDriver;

        public AccountsListPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ConcreteAccountOverviewPage ClickAccount(string bankAccount)
        {
            //....
            //click
            return new ConcreteAccountOverviewPage(_webDriver);
        }

        internal object GetAccountList()
        {
            throw new NotImplementedException();
        }
    }
}