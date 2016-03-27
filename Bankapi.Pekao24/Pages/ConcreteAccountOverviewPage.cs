using System;
using System.Collections.Generic;
using Bankapi.Models;
using OpenQA.Selenium;

namespace Bankapi.Pekao24.Pages
{
    internal class ConcreteAccountOverviewPage
    {
        private IWebDriver _webDriver;

        public ConcreteAccountOverviewPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public DateTime ReportDateFrom { get; internal set; }

        public IEnumerable<Transaction> TransactionsFrom(DateTime from)
        {
            throw new NotImplementedException();
        }
    }
}