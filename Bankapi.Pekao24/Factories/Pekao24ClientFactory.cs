using Bankapi.Models;

namespace Bankapi.Pekao24.Factories
{
    public class Pekao24ClientFactory : IBankClientFactory
    {
        public string ClientName => "pekao24";

        public IBankClient Create(BankCredentials bankCredentials)
        {
            return new Pekao24BankClient(bankCredentials, new MainPageFactory());
        }
    }
}
