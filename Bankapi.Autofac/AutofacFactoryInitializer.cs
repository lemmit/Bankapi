using System;
using Autofac;

namespace Bankapi.Autofac
{
    public static class AutofacFactoryInitializer
    {
        public static void InitializeClientFactories(this ContainerBuilder appContainer)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                appContainer.RegisterAssemblyTypes(assembly)
                        .Where(t => t.IsAssignableFrom(typeof(IBankClientFactory)))
                        .AsImplementedInterfaces();
                appContainer.RegisterType<BankClientFactoryResolver>();
            }
        }
    }
}
