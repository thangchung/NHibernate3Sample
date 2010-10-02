namespace NHibernate3Sample.Entity.Contract
{
    public interface INews : IEntity
    {
        string Title { get; set; }

        string ShortDescription { get; set; }

        string Content { get; set; }

        ICategory Category { get; set; }

        IPoll Poll { get; set; }

        void AssignPoll(IPoll poll);

        void AssignCategory(ICategory cat);
    }
}