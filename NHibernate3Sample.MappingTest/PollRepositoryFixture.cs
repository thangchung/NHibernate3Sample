using System.Linq;
using NHibernate3Sample.Autofac;
using NHibernate3Sample.Autofac.Repository.Contract;
using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    [TestFixture]
    public class PollRepositoryFixture : FixtureBase
    {
        private IPollRepository _repository;

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            _repository = IoC.GetInstance<IPollRepository>();
        }

        [Test]
        public void Can_Get_Poll_From_Database()
        {
            var result = _repository.All();
            Assert.Greater(result.Count(), 0);
        }

        [Test]
        public void Can_Update_Poll()
        {
            var uow = _repository.UnitOfWork;

            var poll = _repository.GetBy(x => x.Id == 1).FirstOrDefault();
            poll.Value = 1;
            poll.WhoVote = "thangchung";
            _repository.Update(poll);
            var updatePoll = _repository.GetBy(x => x.Id == 1).FirstOrDefault();

            uow.Commit();

            Assert.IsNotNull(updatePoll);
            Assert.AreEqual(updatePoll.Value, 1);
            Assert.AreEqual(updatePoll.WhoVote, "thangchung");
        }
    }
}