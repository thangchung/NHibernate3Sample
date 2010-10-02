using System;
using Iesi.Collections.Generic;
using NHibernate3Sample.Entity.Contract;

namespace NHibernate3Sample.Entity
{
    public class Poll : EntityBase, IPoll
    {
        //public virtual int PollId { get; set; }

        public virtual int Value { get; set; }

        public virtual DateTime VoteDate { get; set; }

        public virtual string WhoVote { get; set; }

        public virtual INews News { get; set; }

        //public virtual IList<IUser> Users { get; set; }
        public virtual ISet<IUser> Users { get; set; }

        public Poll()
        {
            Users = new Iesi.Collections.Generic.HashedSet<IUser>();
        }

        public virtual void AssignNews(INews news)
        {
            News = news;
        }

        public virtual void AssignUser(IUser user)
        {
            user.Polls.Add(this);
            Users.Add(user);
        }

        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    if (ReferenceEquals(this, obj)) return true;
        //    if (obj.GetType() != typeof (Poll)) return false;
        //    return Equals((Poll) obj);
        //}

        //public bool Equals(Poll other)
        //{
        //    if (ReferenceEquals(null, other)) return false;
        //    if (ReferenceEquals(this, other)) return true;
        //    return other.PollId == PollId && other.Value == Value && other.VoteDate.Equals(VoteDate) && Equals(other.WhoVote, WhoVote) && Equals(other.News, News) && Equals(other.Users, Users);
        //}

        //public override int GetHashCode()
        //{
        //    unchecked
        //    {
        //        int result = PollId;
        //        result = (result*397) ^ Value;
        //        result = (result*397) ^ VoteDate.GetHashCode();
        //        result = (result*397) ^ (WhoVote != null ? WhoVote.GetHashCode() : 0);
        //        result = (result*397) ^ (News != null ? News.GetHashCode() : 0);
        //        result = (result*397) ^ (Users != null ? Users.GetHashCode() : 0);
        //        return result;
        //    }
        //}
    }
}