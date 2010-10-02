using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate3Sample.Autofac.UoW;
using NHibernate3Sample.Entity.Contract;

namespace NHibernate3Sample.Autofac.Repository.Contract
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IUnitOfWork UnitOfWork { get; set; }

        IEnumerable<TEntity> All();

        int Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> condition);
    }
}