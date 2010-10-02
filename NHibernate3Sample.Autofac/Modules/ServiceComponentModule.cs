using System.Diagnostics.Contracts;
using Autofac;
using AutofacContrib.DynamicProxy2;

namespace NHibernate3Sample.Autofac.Modules
{
    using Interceptor;
    using Repository;
    using Repository.Contract;

    public class ServiceComponentModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Contract.Assert(builder != null, "Builder container is null");

            builder.RegisterType<ExceptionInterceptor>()
                .As<ExceptionInterceptor>();

            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionInterceptor));

            builder.RegisterType<NewsRepository>()
                .As<INewsRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionInterceptor));

            builder.RegisterType<PollRepository>()
                .As<IPollRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionInterceptor));

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionInterceptor));
        }
    }
}