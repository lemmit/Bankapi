using System;
using System.Collections.Generic;
using Bankapi.Models;

namespace Bankapi
{
    public abstract class BankClient : IBankClient
    {
        protected readonly BankCredentials BankCredentials;

        protected BankClient(BankCredentials bankCredentials)
        {
            BankCredentials = bankCredentials;
        }

        public abstract IEnumerable<Transaction> GetTransactionsHistory(DateTime @from);
    }
}