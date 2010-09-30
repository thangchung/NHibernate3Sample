using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate3Sample.Autofac.Repository
{
    using Contract;
    using Entity;
    using UoW;

    public class CategoryRepository : ICategoryRepository
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        public CategoryRepository()
            : this(IoC.GetInstance<IUnitOfWorkFactory>())
        { }

        internal CategoryRepository(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public virtual IEnumerable<Category> All()
        {
            using (var uow = UnitOfWorkFactory.GetNewUnitOfWork())
            {
                var result = uow.Session.QueryOver<Category>().List();
                uow.Commit();

                return result;
            }
        }

        public int Add(Category entity)
        {
            object result = null;

            using (var uow = UnitOfWorkFactory.GetNewUnitOfWork())
            {
                result = uow.Session.Save(entity);

                uow.Session.Flush();
                uow.Session.Clear();

                uow.Commit();
            }

            return (int)result;
        }

        public void Remove(Category entity)
        {
            using (var uow = UnitOfWorkFactory.GetNewUnitOfWork())
            {
                uow.Session.Delete(entity);
                uow.Commit();
            }
        }

        public void Update(Category entity)
        {
            using (var uow = UnitOfWorkFactory.GetNewUnitOfWork())
            {
                uow.Session.Update(entity);
                uow.Commit();
            }
        }

        public IEnumerable<Category> GetBy(Expression<Func<Category, bool>> condition)
        {
            using (var uow = UnitOfWorkFactory.GetNewUnitOfWork())
            {
                var result = uow.Session.QueryOver<Category>()
                    .Where(condition)
                    .List();
                uow.Commit();

                return result;
            }
        }
    }
}