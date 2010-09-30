using AutofacContrib.DynamicProxy2;
using NHibernate3Sample.Autofac.Interceptor;

namespace NHibernate3Sample.Autofac.Repository.Contract
{
    using Entity;

    [Intercept(typeof(ExceptionInterceptor))]
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}