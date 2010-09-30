using NHibernate3Sample.Entity.Contract;

namespace NHibernate3Sample.Entity
{
    public class News : EntityBase, INews
    {
        public virtual string Title { get; set; }

        public virtual string ShortDescription { get; set; }

        public virtual string Content { get; set; }

        public virtual ICategory Category { get; set; }

        public virtual IPoll Poll { get; set; }

        public virtual void AssignPoll(IPoll poll)
        {
            Poll = poll;
        }

        public virtual void AssignCategory(ICategory cat)
        {
            cat.News.Add(this);
            Category = cat;
        }
    }
}