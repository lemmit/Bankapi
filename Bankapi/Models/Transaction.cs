using System;

namespace Bankapi.Models
{
    public class Transaction
    {
        public string Id { get; }
        public string Title { get; }
        public decimal Value { get; }
        public DateTime TransactionDateTime { get; }

        public Transaction(string id, string title, decimal value, DateTime transactionDateTime)
        {
            Id = id;
            Title = title;
            Value = value;
            TransactionDateTime = transactionDateTime;
        }
    }
}