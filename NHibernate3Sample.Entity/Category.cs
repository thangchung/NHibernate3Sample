using System;
using System.Collections.Generic;
using NHibernate3Sample.Entity.Contract;

namespace NHibernate3Sample.Entity
{
    public class Category : EntityBase, ICategory
    {
        public virtual string Name { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<INews> News { get; set; }

        public Category()
        {
            News = new List<INews>();
        }

        public virtual void AssignNews(INews news)
        {
            news.Category = this;
            News.Add(news);
        }
    }
}