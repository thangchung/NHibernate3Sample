using Iesi.Collections.Generic;
using NHibernate3Sample.Entity.Contract;

namespace NHibernate3Sample.Entity
{
    public class User : EntityBase, IUser
    {
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual Address Address { get; set; }

        public virtual ISet<IPoll> Polls { get; set; }

        public User()
        {
            Polls = new Iesi.Collections.Generic.HashedSet<IPoll>();
        }

        public virtual void AssignPoll(IPoll poll)
        {
            poll.Users.Add(this);
            Polls.Add(poll);
        }
    }
}