using System;
using System.Collections.Generic;
using Bankapi.Models;
using Bankapi.Pekao24.Factories;
using Bankapi.Pekao24.Pages;

namespace Bankapi.Pekao24
{
    internal class Pekao24BankClient : BankClient, IDisposable
    {
        private MainPage MainPage => _mainPage.Value;

        private readonly Lazy<MainPage> _mainPage;
        private readonly IMainPageFactory _mainPageFactory;

        public Pekao24BankClient(
            BankCredentials bankCredentials,
            IMainPageFactory mainPageFactory
            ) 
            : base(bankCredentials)
        {
            _mainPageFactory = mainPageFactory;
            _mainPage = new Lazy<MainPage>(LoadMainPage);
        }

        private MainPage LoadMainPage()
        {
            return _mainPageFactory.Create();
        }

        public override IEnumerable<Transaction> GetTransactionsHistory(DateTime @from)
        {
            MainPage.CustomerNumberInputValue = BankCredentials.Login;
            var enterPasswordPage = MainPage.SubmitMainForm();
            enterPasswordPage.Password = BankCredentials.Password;
            var accountPage = enterPasswordPage.ClickLoginButton();
            var concreteAccountPage = accountPage.ClickAccount(BankCredentials.AccountNumber);
            return concreteAccountPage.TransactionsFrom(@from);
        }

        public void Dispose()
        {
            MainPage.Dispose();
        }
    }
}
