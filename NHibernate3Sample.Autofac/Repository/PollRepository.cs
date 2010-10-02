namespace NHibernate3Sample.Autofac.Repository
{
    using Contract;
    using Entity;

    public class PollRepository : GenericRepository<Poll>, IPollRepository
    {
    }
}