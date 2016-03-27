using System;
using System.Linq;
using Bankapi.Exceptions;
using Bankapi.Models;
using Bankapi.Pekao24;
using Bankapi.Pekao24.Factories;
using Xunit;
using BankApi.Pekao24IntegrationTests;
using Should;

namespace Bankapi.Pekao24IntegrationTests
{
    public class GivenPekao24Client : IDisposable
    {
        private readonly IMainPageFactory _mainPageFactory;
        private Pekao24BankClient _pekaoClient;
        public GivenPekao24Client()
        {
            _mainPageFactory = new MainPageFactory();
        }
        
        [Fact]
        public void ShouldThrowExceptionIfClientNumberIsEmpty()
        {
            _pekaoClient = CreatePekao24BankClient("", "randomPassword", "34 43 43 24 234 ");
            var exception = Record.Exception(
                () => _pekaoClient.GetTransactionsHistory(DateTime.Now)
            );
            exception.ShouldBeType<InvalidCredentialsException>();
        }

        [Fact]
        public void ShouldThrowExceptionIfClientNumberIsNull()
        {
            _pekaoClient = CreatePekao24BankClient(null, "randomPassword", "34 43 43 24 234 ");
        var exception = Record.Exception(
                () => CreatePekao24BankClient(null, "randomPassword", "34 43 43 24 234 ")
            );
            exception.ShouldBeType<InvalidCredentialsException>();
        }

        [Fact]
        public void ShouldThrowInvalidCredentialsExceptionIfWrongCredentials()
        {
            _pekaoClient = CreatePekao24BankClient("123123123", "randomPassword", "34 43 43 24 234 ");
            
            var exception = Record.Exception(
                () => _pekaoClient.GetTransactionsHistory(DateTime.Now.AddDays(-1))
            );
            exception.ShouldBeType<InvalidCredentialsException>();
        }

        public void ShouldLoginSuccessfullyIfGoodCredentials()
        {
            _pekaoClient = CreatePekao24BankClientWithGoodCredentials();
            var transactions = _pekaoClient.GetTransactionsHistory(DateTime.MinValue);

            transactions.ShouldNotBeEmpty();
        }

        [Fact]
        public void ShouldReturnTransactionHistoryFromGivenDate()
        {
            _pekaoClient = CreatePekao24BankClientWithGoodCredentials();
            var transactions = _pekaoClient.GetTransactionsHistory(DateTime.Parse("2016-03-22"));

            transactions.Count().ShouldEqual(1);
        }

        [Fact]
        public void ShouldReturnTransactionHistoryFromVeryBeginning()
        {
            _pekaoClient = CreatePekao24BankClientWithGoodCredentials();
            var transactions = _pekaoClient.GetTransactionsHistory(DateTime.MinValue);

            transactions.Count().ShouldEqual(2);
        }

        private Pekao24BankClient CreatePekao24BankClientWithGoodCredentials()
        {
            return new Pekao24BankClient(
                new SamplePekao24BankCredentials(), 
                _mainPageFactory);
        }

        private Pekao24BankClient CreatePekao24BankClient(string login, string password, string accountNumber)
        {
            return new Pekao24BankClient(
                new BankCredentials(login, password, accountNumber),
                _mainPageFactory);
        }

        public void Dispose()
        {
            _pekaoClient.Dispose();
        }

    }
}
