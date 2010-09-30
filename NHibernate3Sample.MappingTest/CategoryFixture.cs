using System.Linq;
using NHibernate3Sample.Entity;
using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    [TestFixture]
    public class CategoryFixture : FixtureBase
    {
        [Test]
        public void Num_Of_Category_Is_Larger_Zero()
        {
            var result = UoW.Session.QueryOver<Category>().List();
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Can_Update_Category()
        {
            var cat = UoW.Session.QueryOver<Category>().List().FirstOrDefault();
            cat.Name = "test update name";
            cat.Description = "test update description";
            UoW.Session.Update(cat);

            var updateCat = UoW.Session.QueryOver<Category>().List().FirstOrDefault();
            Assert.IsNotNull(updateCat);
            Assert.AreEqual(updateCat.Name, "test update name");
            Assert.AreEqual(updateCat.Description, "test update description");
        }

        [Test]
        public void Can_Delete_Category()
        {
            var cat = UoW.Session.QueryOver<Category>().List().FirstOrDefault();

            UoW.Session.Delete(cat);

            var nullCat = UoW.Session.QueryOver<Category>().List();

            //Assert.IsNull(nullCat);
        }
    }
}