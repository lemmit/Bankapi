using System;
using System.Collections.Generic;
using Autofac;
using Bankapi.Autofac;
using Bankapi.Models;

namespace Bankapi.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!CredentialsProvided(args))
            {
                ShowSampleUsage();
                return;
            }
            try
            {
                var bankName = ParseBankName(args);
                var credentials = ParseCredentials(args);
                var client = CreateClient(credentials, bankName);
                var transactions = client.GetTransactionsHistory(DateTime.MinValue);
                PrintOutTransactions(transactions);
            }
            catch (Exception e)
            {
                LogException(e);
            }
            Console.ReadLine();
        }

        private static string ParseBankName(string[] args)
        {
            return args[0];
        }

        private static void LogException(Exception e)
        {
            Console.WriteLine(e);
        }

        private static void PrintOutTransactions(IEnumerable<Transaction> transactions)
        {
            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.Id}\t{t.Title}\t{t.TransactionDateTime.Date}\t{t.Value}");
            }
        }

        private static IBankClient CreateClient(BankCredentials credentials, string bankName)
        {
            var client = GetClientFactoryResolver();
            var factory = client.Resolve(bankName);
            return factory.Create(credentials);
        }

        private static BankClientFactoryResolver GetClientFactoryResolver()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.InitializeClientFactories();
            var container = containerBuilder.Build();
            var client = container.Resolve<BankClientFactoryResolver>();
            return client;
        }

        private static BankCredentials ParseCredentials(string[] args)
        {
            var credentials = new BankCredentials(args[1], args[2], args[3]);
            return credentials;
        }

        private static void ShowSampleUsage()
        {
            Console.WriteLine("Sample usage:\n" +
                              "bankapi <bankName> <login> <password> <accountNumber>\n" +
                              "bankapi pekao24 2342343 frfrefe 3255343453535342352324\n");
        }

        private static bool CredentialsProvided(string[] args)
        {
            return args.Length >= 4;
        }
    }
}
