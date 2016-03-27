using System;
using System.Collections.Generic;
using Bankapi.Models;

namespace Bankapi
{
    public interface IBankClient
    {
        IEnumerable<Transaction> GetTransactionsHistory(DateTime @from);
    }
}