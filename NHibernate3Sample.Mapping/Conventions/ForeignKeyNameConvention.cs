using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernate3Sample.Mapping.Conventions
{
    public class ForeignKeyNameConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
        }
    }
}