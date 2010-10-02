using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace NHibernate3Sample.Mapping.Conventions
{
    public class TableNameConvention : IClassConvention, IClassConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IClassInspector> criteria)
        {
            criteria.Expect(x => x.TableName, Is.Not.Set);
        }

        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}