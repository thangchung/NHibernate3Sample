using System.Linq;
using NHibernate3Sample.Autofac;
using NHibernate3Sample.Autofac.Repository.Contract;
using NHibernate3Sample.Entity;
using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    [TestFixture]
    public class UserRepositoryFixture : FixtureBase
    {
        private IUserRepository _repository;

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            _repository = IoC.GetInstance<IUserRepository>();
        }

        [Test]
        public void Can_Get_User_From_Database()
        {
            var result = _repository.All();
            Assert.Greater(result.Count(), 0);
        }

        [Test]
        public void Can_Update_User()
        {
            var uow = _repository.UnitOfWork;

            var addr = new Address("newstreet", "newdistrict", "newward");
            var user = _repository.GetBy(x => x.Id == 1).FirstOrDefault();
            user.Password = "updatepassword";
            user.Address = addr;
            _repository.Update(user);
            var updateUser = _repository.GetBy(x => x.Id == 1).FirstOrDefault();

            uow.Commit();

            Assert.IsNotNull(updateUser);
            Assert.AreEqual(updateUser.Password, "updatepassword");
            Assert.IsTrue(addr.Equals(updateUser.Address));
        }
    }
}