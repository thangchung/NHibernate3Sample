using System;
using System.Collections.Generic;

namespace NHibernate3Sample.Entity.Contract
{
    public interface ICategory : IEntity
    {
        string Name { get; set; }

        DateTime CreatedDate { get; set; }

        string Description { get; set; }

        IList<INews> News { get; set; }

        void AssignNews(INews news);
    }
}