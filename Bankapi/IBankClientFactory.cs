using Bankapi.Models;

namespace Bankapi
{
    public interface IBankClientFactory
    {
        string ClientName { get; }
        IBankClient Create(BankCredentials bankCredentials);
    }
}
