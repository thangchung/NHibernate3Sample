using FluentNHibernate.Mapping;

namespace NHibernate3Sample.Mapping
{
    using Entity;

    public class CategoryMapping : ClassMap<Category>
    {
        public CategoryMapping()
        {
            Table("[NHibernate3Sample].[dbo].[Categories]");
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.Name, "Name").Nullable().Length(50);
            Map(x => x.CreatedDate, "CreatedDate").Nullable();
            Map(x => x.Description, "Description").Nullable();

            HasMany<News>(x => x.News)
                .Key(key => key.Nullable())
                .Inverse()
                .LazyLoad()
                .Cascade.AllDeleteOrphan();
        }
    }
}