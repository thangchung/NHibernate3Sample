using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernate3Sample.Mapping.Conventions
{
    public class PrimaryKeyNameConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}