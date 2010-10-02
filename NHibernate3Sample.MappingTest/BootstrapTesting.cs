using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    using Autofac;
    using Autofac.UoW;

    [TestFixture]
    public class BootstrapTesting
    {
        public BootstrapTesting()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test]
        public void Can_Get_Container()
        {
            var container = BootStrapper.GetContainer();
            Assert.IsNotNull(container);
        }

        [Test]
        public void Can_Resolve_Unit_Of_Work()
        {
            var uow = IoC.GetInstance<IUnitOfWork>();
            Assert.IsNotNull(uow);
        }
    }
}