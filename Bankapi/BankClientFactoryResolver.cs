using System;
using System.Collections.Generic;
using System.Linq;
using Bankapi.Exceptions;

namespace Bankapi
{
    public class BankClientFactoryResolver
    {
        readonly IEnumerable<IBankClientFactory> _factories;
        public BankClientFactoryResolver(IEnumerable<IBankClientFactory> factories)
        {
            _factories = factories;
        }
        public IBankClientFactory Resolve(string bank)
        {
            IBankClientFactory foundFactory;
            try
            {
                foundFactory = _factories.Single(clientFactory => clientFactory.ClientName.ToLower() == bank.ToLower());
            }
            catch (Exception e)
            {
                throw new ClientFactoryNotFoundException("Bank name" + bank, e);
            }
            return foundFactory;
        }
    }
}
