using System.Configuration;
using Autofac;
using AutofacContrib.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;

namespace NHibernate3Sample.Autofac
{
    using Mapping;
    using Modules;

    public class BootStrapper
    {
        private static IContainer _container;

        public BootStrapper()
        {
            _container = GetContainer();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(_container));
        }

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new NHibernateComponentModule()
            {
                // TODO: should wrap the ConfigurationManager for unit testing
                ConnectionString = ConfigurationManager.ConnectionStrings["NHibernate3Sample"].ConnectionString,
                AssemblyMapper = typeof(CategoryMapping).Assembly
            });

            builder.RegisterModule(new ServiceComponentModule());

            return builder.Build();
        }
    }
}