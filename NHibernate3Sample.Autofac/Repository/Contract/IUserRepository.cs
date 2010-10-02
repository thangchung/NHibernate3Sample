using AutofacContrib.DynamicProxy2;

namespace NHibernate3Sample.Autofac.Repository.Contract
{
    using Entity;
    using Interceptor;

    [Intercept(typeof(ExceptionInterceptor))]
    public interface IUserRepository : IRepository<User>
    {
    }
}