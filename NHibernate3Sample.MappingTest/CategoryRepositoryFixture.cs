using System.Linq;
using NHibernate3Sample.Autofac;
using NHibernate3Sample.Autofac.Repository.Contract;
using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    [TestFixture]
    public class CategoryRepositoryFixture : FixtureBase
    {
        private ICategoryRepository _repository;

        protected override void BeforeEachTest()
        {
            base.BeforeEachTest();
            _repository = IoC.GetInstance<ICategoryRepository>();
        }

        [Test]
        public void Num_Of_Category_Is_Larger_Zero()
        {
            var result = _repository.All();
            
            Assert.Greater(result.Count(), 0);
        }

        [Test]
        public void Can_Update_Category()
        {
            var uow = _repository.UnitOfWork;

            var cat = _repository.GetBy(x => x.Id == 1).FirstOrDefault();
            cat.Name = "test update name";
            cat.Description = "test update description";
            _repository.Update(cat);
            var updateCat = _repository.GetBy(x => x.Id == 1).FirstOrDefault();

            uow.Commit();

            Assert.IsNotNull(updateCat);
            Assert.AreEqual(updateCat.Name, "test update name");
            Assert.AreEqual(updateCat.Description, "test update description");
        }
    }
}