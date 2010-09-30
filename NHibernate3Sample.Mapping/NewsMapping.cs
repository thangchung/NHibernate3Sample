using FluentNHibernate.Mapping;
using NHibernate3Sample.Entity;

namespace NHibernate3Sample.Mapping
{
    public class NewsMapping : ClassMap<News>
    {
        public NewsMapping()
        {
            LazyLoad();
            Table("[NHibernate3Sample].[dbo].[News]");
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.Title, "Title").Nullable().Length(500);
            Map(x => x.ShortDescription, "ShortDescription").Nullable();
            Map(x => x.Content, "Content").Nullable();
            References(x => (Category)x.Category)
                .Nullable()
                .Cascade.None();
            HasOne<Poll>(x => x.Poll)
                .Constrained()
                .PropertyRef(x => x.News)
                .Cascade.Delete();
        }
    }
}