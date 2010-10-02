namespace NHibernate3Sample.Autofac.Repository
{
    using Contract;
    using Entity;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    }
}