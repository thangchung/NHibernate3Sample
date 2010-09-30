using System;
using System.Linq;
using NHibernate3Sample.Autofac;
using NHibernate3Sample.Autofac.UoW;
using NHibernate3Sample.Entity;
using NUnit.Framework;

namespace NHibernate3Sample.MappingTest
{
    [TestFixture]
    public class FixtureBase
    {
        protected IUnitOfWork UoW { get; private set; }

        private DataHelper _dataHelper = new DataHelper();

        [SetUp]
        public void SetupContext()
        {
            UoW = IoC.GetInstance<IUnitOfWork>();

            BeforeEachTest();
        }

        [TearDown]
        public void TearDownContext()
        {
            AfterEachTest(UoW);
        }

        protected virtual void BeforeEachTest()
        {
            CreateInitialData(UoW);
        }

        protected virtual void AfterEachTest(IUnitOfWork uow)
        {
            _dataHelper.ClearData();
        }

        protected virtual void CreateInitialData(IUnitOfWork uow)
        {
            _dataHelper.InitData();
        }
    }

    public class DataHelper
    {
        private Category _category;
        private News _news;
        private Poll _poll;
        private User _user;

        public void InitData()
        {
            _category = new Category
                            {
                                Name = "test name",
                                CreatedDate = DateTime.Now,
                                Description = "test description"
                            };
            _news = new News
                        {
                            Title = "test title",
                            ShortDescription = "test short description",
                            Content = "test content"
                        };
            _poll = new Poll
                        {
                            Value = 0,
                            VoteDate = DateTime.Now,
                            WhoVote = "test user"
                        };
            _user = new User
                        {
                            UserName = "username",
                            Password = "password",
                            Address = new Address("street", "ward", "district")
                        };

            // --------------------------------

            _poll.AssignUser(_user);
            _user.AssignPoll(_poll);
            _poll.AssignNews(_news);
            _news.AssignPoll(_poll);
            _category.AssignNews(_news);

            using (var uow = IoC.GetInstance<IUnitOfWork>())
            {
                uow.Session.SaveOrUpdate(_category);
                uow.Session.SaveOrUpdate(_news);
                uow.Session.SaveOrUpdate(_poll);
                uow.Session.SaveOrUpdate(_user);

                // --------------------------------

                //var result = uow.Session.QueryOver<News>()
                //    .Where(x => x.Id == 1)
                //    .List();

                //var poll = uow.Session.QueryOver<Poll>()
                //    .Where(x => x.Id == 1)
                //    .List();
                ////result.FirstOrDefault().AssignPoll(_poll);
                ////_poll.AssignNews(result.FirstOrDefault());
                ////uow.Session.Save(result.FirstOrDefault());
                ////uow.Session.Save(_poll);

                // --------------------------------

                uow.Commit();
            }
        }

        public void ClearData()
        {
            using (var uow = IoC.GetInstance<IUnitOfWork>())
            {
                var poll = uow.Session.QueryOver<Poll>().List().FirstOrDefault();

                uow.Session.Delete(poll);

                var user = uow.Session.QueryOver<User>().List().FirstOrDefault();
                uow.Session.Delete(user);

                var news = uow.Session.QueryOver<News>().List().FirstOrDefault();
                uow.Session.Delete(news);

                var cat = uow.Session.QueryOver<Category>().List().FirstOrDefault();
                uow.Session.Delete(cat);

                uow.Commit();
            }
        }
    }
}