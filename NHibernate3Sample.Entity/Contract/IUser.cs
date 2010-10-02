using Iesi.Collections.Generic;

namespace NHibernate3Sample.Entity.Contract
{
    public interface IUser : IEntity
    {
        string UserName { get; set; }

        string Password { get; set; }

        //IList<IPoll> Polls { get; set; }
        ISet<IPoll> Polls { get; set; }

        void AssignPoll(IPoll poll);
    }
}