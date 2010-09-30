using System;
using Microsoft.Practices.ServiceLocation;

namespace NHibernate3Sample.Autofac
{
    public static class IoC
    {
        static IoC()
        {
            new BootStrapper();
        }

        public static TService GetInstance<TService>()
        {
            return ServiceLocator.Current.GetInstance<TService>();
        }

        public static object GetInstance(Type serviceType)
        {
            return ServiceLocator.Current.GetInstance(serviceType);
        }
    }
}