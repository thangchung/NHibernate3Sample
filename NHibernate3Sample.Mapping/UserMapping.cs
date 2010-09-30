using FluentNHibernate.Mapping;
using NHibernate3Sample.Entity;

namespace NHibernate3Sample.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.UserName, "UserName").Not.Nullable().Length(30);
            Map(x => x.Password, "Password").Not.Nullable().Length(1000);
            Component(x => x.Address, m =>
            {
                m.Map(x => x.Street, "Street").Length(30);
                m.Map(x => x.Ward, "Ward").Length(20);
                m.Map(x => x.District, "District").Length(20);
            });
            HasManyToMany<Poll>(x => x.Polls)
                .Table("PollUsers")
                .ParentKeyColumn("UserId").Cascade.SaveUpdate()
                .ChildKeyColumn("PollId").Cascade.None()
                .Generic()
                .Inverse()
                .LazyLoad()
                //.Cascade.AllDeleteOrphan()
                .AsSet();
        }
    }
}