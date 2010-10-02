#region imports

using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using Autofac;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = NHibernate.Cfg.Environment;
using Module = Autofac.Module;

#endregion imports

namespace NHibernate3Sample.Autofac.Modules
{
    using Mapping.Conventions;
    using UoW;

    public class NHibernateComponentModule : Module
    {
        public string ConnectionString { get; set; }

        public Assembly AssemblyMapper { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            Contract.Assert(builder != null, "Builder container is null");
            Contract.Assert(!string.IsNullOrEmpty(ConnectionString), "Cannot find connection string in config file");
            Contract.Assert(AssemblyMapper != null, "AssemblyMapper is null");

            var cfg = BuildConfiguration();

            var persistenceModel = BuildPersistenceModel();
            persistenceModel.Configure(cfg);

            var sessionFactory = BuildSessionFactory(cfg);

            RegisterConponents(builder, cfg, sessionFactory);
        }

        public Configuration BuildConfiguration()
        {
            var config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(ConnectionString))
                .ExposeConfiguration(c => c.SetProperty(Environment.ReleaseConnections, "on_close"))
                .ExposeConfiguration(c => c.SetProperty(Environment.ProxyFactoryFactoryClass, typeof(NHibernate.ByteCode.Castle.ProxyFactoryFactory).AssemblyQualifiedName))
                .ExposeConfiguration(c => c.SetProperty(Environment.Hbm2ddlAuto, "create"))
                .ExposeConfiguration(c => c.SetProperty(Environment.ShowSql, "true"))
                //.Mappings(x => x.HbmMappings.AddFromAssembly(Assembly.Load("NHibernate3Sample.Entity")))
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration();

            if (config == null)
                throw new Exception("Cannot build NHibernate configuration");

            return config;
        }

        public AutoPersistenceModel BuildPersistenceModel()
        {
            var persistenceModel = new AutoPersistenceModel();

            persistenceModel.Conventions.Setup(c =>
            {
                c.Add(typeof(ForeignKeyNameConvention));
                c.Add(typeof(ReferenceConvention));
                c.Add(typeof(PrimaryKeyNameConvention));
                c.Add(typeof(TableNameConvention));
            });

            persistenceModel.AddMappingsFromAssembly(AssemblyMapper);

            persistenceModel.WriteMappingsTo(@"./");

            return persistenceModel;
        }

        public ISessionFactory BuildSessionFactory(Configuration config)
        {
            var sessionFactory = config.BuildSessionFactory();

            if (sessionFactory == null)
                throw new Exception("Cannot build NHibernate Session Factory");

            return sessionFactory;
        }

        public void RegisterConponents(ContainerBuilder builder, Configuration config, ISessionFactory sessionFactory)
        {
            builder.RegisterInstance(config).As<Configuration>().SingleInstance();
            builder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
            builder.Register(x => new UnitOfWork(x.Resolve<ISessionFactory>())).As<IUnitOfWork>();
            builder.Register(x => new UnitOfWorkFactory()).As<IUnitOfWorkFactory>().SingleInstance();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).SetOutputFile(@"./Schema.sql").Create(true, true);
        }
    }
}