namespace NHibernate3Sample.Autofac.UoW
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetNewUnitOfWork();
    }
}