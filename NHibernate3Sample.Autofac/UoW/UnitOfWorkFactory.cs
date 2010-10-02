using System.Diagnostics;

namespace NHibernate3Sample.Autofac.UoW
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        [DebuggerStepThrough]
        public IUnitOfWork GetNewUnitOfWork()
        {
            return IoC.GetInstance<IUnitOfWork>();
            //return new UnitOfWork(BootStrapperWrapper.GetInstance<ISessionFactory>());
        }
    }
}