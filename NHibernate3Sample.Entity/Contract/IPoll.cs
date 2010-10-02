using System;
using Iesi.Collections.Generic;

namespace NHibernate3Sample.Entity.Contract
{
    public interface IPoll : IEntity
    {
        //int PollId { get; set; }

        int Value { get; set; }

        DateTime VoteDate { get; set; }

        string WhoVote { get; set; }

        INews News { get; set; }

        //IList<IUser> Users { get; set; }
        ISet<IUser> Users { get; set; }

        void AssignNews(INews news);

        void AssignUser(IUser user);
    }
}