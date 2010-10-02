using System;
using NHibernate;

namespace NHibernate3Sample.Autofac.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }

        void Commit();
    }
}