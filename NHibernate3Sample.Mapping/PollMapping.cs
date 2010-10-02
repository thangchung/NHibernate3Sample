/*
 * One to one mapping
 * http://ayende.com/Blog/archive/2009/04/19/nhibernate-mapping-ltone-to-onegt.aspx
 */

using FluentNHibernate.Mapping;
using NHibernate3Sample.Entity;

namespace NHibernate3Sample.Mapping
{
    public class PollMapping : ClassMap<Poll>
    {
        public PollMapping()
        {
            Id(x => x.Id, "Id").GeneratedBy.Identity();

            Map(x => x.Value, "Value");
            Map(x => x.VoteDate, "VoteDate");
            Map(x => x.WhoVote, "WhoVote").Length(30);

            References<News>(x => x.News)
                .Column("NewsId")
                .Unique()
                .Cascade.None();

            //References<News>(x => x.News).Unique().Column("News");//.Cascade.SaveUpdate().ForeignKey();

            HasManyToMany<User>(x => x.Users)
                .Table("PollUsers")
                .ParentKeyColumn("PollId").Cascade.SaveUpdate()
                .ChildKeyColumn("UserId").Cascade.None()
                .Generic()
                .Cascade.SaveUpdate()
                .AsSet();
        }
    }
}